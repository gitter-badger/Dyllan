using Douban.Dal;
using Douban.Model;
using Dyllan.Common.Web;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;
using HtmlAgilityPack;

namespace Douban.Spider
{
    public class BookSpider : SpiderDirector<BookInfo>
    {
        private DoubanManager _douBanManger = new DoubanManager();
        private int _minUrlValue = 10000000;
        private int _maxUrlValue = 100000000;
        private int _interval = 1000;
        private const string BookUrlFormat = "https://book.douban.com/subject/{0}/";

        private int _currentUrlValue = 0;
        private Dictionary<int, HttpHelper> httpHelpers = new Dictionary<int, HttpHelper>();
        private Dictionary<int, Cookie> cookies = new Dictionary<int, Cookie>();
        public int Interval
        {
            get
            {
                return _interval;
            }
        }

        public BookSpider(int minUrlValue, int maxUrlValue, int interval)
        {
            _minUrlValue = minUrlValue;
            _maxUrlValue = maxUrlValue;
            _currentUrlValue = _minUrlValue;
            _interval = interval;
        }

        protected override void DoneWork(IList<BookInfo> books)
        {
            _douBanManger.InsertOrUpdateBooks(books);
        }

        protected override void DoingWork(BookInfo book)
        {
            int retry = 1;
            WebException lastError = null;
            do
            {
                try
                {
                    lastError = null;
                    HttpHelper httpHelper = GetHttpHelper();
                    var response = httpHelper.GetResponse(book.WebUrl);
                    book.HttpStatus = response.StatusCode.ToString();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string content = httpHelper.GetString(response);
                        ParseBookHtml(book, content);
                    }
                    else
                    {
                        response.Close();
                        response.Dispose();
                    }
                    break;
                }
                catch (WebException webEx)
                {
                    HttpWebResponse response = webEx.Response as HttpWebResponse;
                    if (response != null)
                    {
                        book.HttpStatus = response.StatusCode.ToString();
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            break;
                    }
                    lastError = webEx;
                    Thread.Sleep(1000);
                }
            }
            while (retry++ < 3);

            if (lastError != null)
                throw lastError;
        }

        protected override IList<BookInfo> GetAvailableTasks()
        {
            if (_currentUrlValue >= _maxUrlValue)
                return null;

            if (_currentUrlValue == _minUrlValue)
            {
                int maxDownloadedNo = _douBanManger.GetMaxDownloadedNumer();
                _currentUrlValue = maxDownloadedNo == -1 ? _minUrlValue : maxDownloadedNo;
            }

            IList<BookInfo> books = new List<BookInfo>();
            int objectNum = _currentUrlValue + _interval;
            for (int i = _currentUrlValue; i < objectNum; i++)
            {
                books.Add(new BookInfo() { WebUrl = string.Format(BookUrlFormat, i), ID = Guid.NewGuid(), UrlNumber = i });
            }
            _currentUrlValue += _interval;

            return books;
        }

        #region Private methods

        private void ParseBookHtml(BookInfo bookInfo, string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            #region BookName
            var nodeList = doc.DocumentNode.SelectNodes("//span[@property='v:itemreviewed']");

            if (nodeList != null && nodeList.Count < 1)
                return;

            bookInfo.BookName = nodeList[0].InnerText;
            #endregion

            #region Info
            nodeList = doc.DocumentNode.SelectNodes("//div[@id='info']");
            HtmlNodeCollection infoes = null;
            if (nodeList != null && nodeList.Count >= 1)
                infoes = nodeList[0].SelectNodes("//span[@class='pl']");

            if (infoes != null && infoes.Count > 0)
            {
                foreach (var info in infoes)
                {
                    string key = info.InnerText.Trim();
                    string value = string.Empty;

                    HtmlNode nextNode = info.NextSibling;
                    while (nextNode != null && !infoes.Contains(nextNode))
                    {
                        string innerContent = nextNode.InnerText.Trim();
                        if (!string.IsNullOrEmpty(innerContent))
                        {
                            if (string.IsNullOrEmpty(value))
                                value = innerContent;
                            else
                                value = string.Format("{0}{1}", value, innerContent);
                        }
                        nextNode = nextNode.NextSibling;
                    }

                    switch (key)
                    {
                        case "作者":
                            bookInfo.Author = value.TrimStart(':');
                            break;
                        case "出版社:":
                            bookInfo.Publisher = value;
                            break;
                        case "原作名:":
                            if (string.IsNullOrEmpty(bookInfo.Author))
                                bookInfo.Author = value;
                            break;
                        case "译者":
                            break;
                        case "出版年:":
                            bookInfo.PublishDate = value;
                            break;
                        case "页数:":
                            bookInfo.PageNum = value;
                            break;
                        case "定价:":
                            bookInfo.Price = value;
                            break;
                        case "ISBN:":
                            bookInfo.ISBN = value;
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region Score
            HtmlNode averageNode = doc.DocumentNode.SelectSingleNode("//strong[@property='v:average']");
            if (averageNode != null)
            {
                float average;
                if (float.TryParse(averageNode.InnerText, out average))
                    bookInfo.AverageScore = average;
            }

            HtmlNode voteNode = doc.DocumentNode.SelectSingleNode("//span[@property='v:votes']");
            if (voteNode != null)
            {
                int vote;
                if (int.TryParse(voteNode.InnerText, out vote))
                    bookInfo.RatingNum = vote;
            }

            var starNodeList = doc.DocumentNode.SelectNodes("//span[@class='rating_per']");
            int starNum = 0;
            if (starNodeList != null)
            {
                foreach (HtmlNode starNode in starNodeList)
                {
                    if (starNum >= 5)
                        break;

                    string star = starNode.InnerText.TrimEnd('%');

                    float dStar;
                    if (float.TryParse(star, out dStar))
                        SetStar(bookInfo, starNum, dStar / 100f);
                    starNum++;
                }
            }
            #endregion

            #region Intro
            var introNodeList = doc.DocumentNode.SelectNodes("//div[@class='intro']");
            if (introNodeList != null && introNodeList.Count >= 2)
            {
                bookInfo.ContentDescription = introNodeList[0].InnerText;
                bookInfo.AuthorDescription = introNodeList[1].InnerText;
            }
            #endregion

            #region Tag

            HtmlNodeCollection tagNodeLists = doc.DocumentNode.SelectNodes("//a[@class='  tag']");
            StringBuilder tagStringBuilder = new StringBuilder();
            if (tagNodeLists != null)
            {
                foreach (var tagNode in tagNodeLists)
                {
                    string tag = tagNode.InnerText.Trim();

                    if (!string.IsNullOrEmpty(tag))
                    {
                        tagStringBuilder.AppendFormat("{0},", tag);
                    }
                }
            }
            bookInfo.Tags = tagStringBuilder.ToString().TrimEnd(',');
            #endregion
        }

        private void SetStar(BookInfo bookInfo, int index, float score)
        {
            switch (index)
            {
                case 4:
                    bookInfo.OneStar = score;
                    break;
                case 3:
                    bookInfo.TwoStar = score;
                    break;
                case 2:
                    bookInfo.ThreeStar = score;
                    break;
                case 1:
                    bookInfo.FourStar = score;
                    break;
                case 0:
                    bookInfo.FiveStar = score;
                    break;
                default:
                    break;
            }
        }

        private HttpHelper GetHttpHelper()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            lock (httpHelpers)
            {
                if (!httpHelpers.ContainsKey(threadId))
                {
                    HttpHelper httpHelper = new HttpHelper(_interval);
                    httpHelpers.Add(threadId, httpHelper);
                    CookieContainer cookieContainer = new CookieContainer();
                    Cookie bidCookie = new Cookie("bid", Guid.NewGuid().ToString("N"), "/", ".douban.com");
                    cookieContainer.Add(bidCookie);
                    httpHelper.Cookie = cookieContainer;
                    cookies.Add(threadId, bidCookie);
                }
            }

            HttpHelper helper = httpHelpers[threadId];
            Cookie cookie = cookies[threadId];
            cookie.Value = Guid.NewGuid().ToString("N");
            return helper;
        }

        #endregion
    }
}
