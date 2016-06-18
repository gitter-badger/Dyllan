using Dyllan.Common;
using Dyllan.Common.Utility;
using Dyllan.Common.Web;
using HtmlAgilityPack;
using ImpossibleMission.Contract;
using ImpossibleMission.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonConstant = Dyllan.Common.Constant;
using IOFile = System.IO.File;

namespace ImpossibleMission.Controller
{
    public class GetBooksTransaction : Transaction
    {
        private const string UrlFormat = "http://it-ebooks.info/book/{0}/";
        private Logger _logger = new Logger("GetBook.log");
        private HttpHelper _httpHelper = new HttpHelper();
        private int _tempIndex = 1;
        private ParallelOptions _parallelOption = new ParallelOptions();
        private const string HTTPSTATE_NOTFOUND = "http://it-ebooks.info/404/";
        public override void Execute()
        {
        }

        public void Start()
        {
            try
            {
                _tempIndex = _startIndex;
                while (!NeedCancel() && _tempIndex < 10000)
                {
                    Parallel.For(_tempIndex, _tempIndex + 20, InitialData, DoJobOfStart, WriteToDB);
                    _tempIndex += 20;
                }
                _logger.Log(string.Format("Index: {0}", _tempIndex));
                AddMessage("Finished getting books", MessageType.Success);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }
        }

        public void DownloadMissedBooks()
        {
            try
            {
                _missedUrlNumbers = BookManager.GetMissedUrlNumbers(_includeNotFound);
                if (_missedUrlNumbers != null && _missedUrlNumbers.Count > 0)
                    Parallel.For(0, _missedUrlNumbers.Count, InitialData, DoJobOfDownload, WriteToDB);
                AddMessage("Finished download missed books", MessageType.Success);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message, MessageType.Error);
                _logger.Log(ex);
            }
        }

        public void GetRealDownloadUrls()
        {
            _allBasicBooksWithoutRealUrl = BookManager.GetBasicBooksWithoutDownloadUrl(StartNum, EndNum);
            Parallel.For(0, _allBasicBooksWithoutRealUrl.Count, InitialDataOfRealUrl, DoJobOfRealUrl, WriteToMemoOfRealUrl);
            StringBuilder urls = new StringBuilder();
            urls.AppendLine(string.Format("{0}-{1}:", StartNum, EndNum));
            foreach (var book in _allBasicBooksWithoutRealUrl)
            {
                if (book.RealDownloadUrl != null)
                {
                    urls.AppendLine(book.RealDownloadUrl);
                }
            }

            _logger.Log(urls.ToString());
            AddMessage("Get urls done!", MessageType.Success);
        }
        private char[] _additionChars = new char[] { ' ', ',' };
        public void UpdateDownloaded()
        {
            try
            {
                _allBasicBooksWithoutRealUrl = BookManager.GetBasicBooksWithoutDownloadUrl(StartNum, EndNum);
                if (!string.IsNullOrEmpty(Folder) && Directory.Exists(Folder))
                {
                    DirectoryInfo directory = new DirectoryInfo(Folder);
                    foreach (var book in _allBasicBooksWithoutRealUrl)
                    {
                        string name = book.Name;
                        foreach (var ch in CommonConstant.InvalidFileNameCharacters)
                            if (ch != '*' && name.Contains(ch))
                            {
                                name = name.Replace(ch, '*');
                            }
                        if (IsFileExist(directory, name))
                        {
                            book.Downloaded = true;
                        }
                        else if (IsFileExist(directory, name.Replace("&", "&amp;")))
                        {
                            book.Downloaded = true;
                        }
                        else if (IsFileExist(directory, string.Format("*{0}", name)))
                        {
                            book.Downloaded = true;
                        }
                        else
                        {
                            name = name.Replace("&", "&amp;");
                            name = string.Format("*{0}", name);
                            foreach (char addC in _additionChars)
                                name = name.Replace(addC, '*');
                            book.Downloaded = IsFileExist(directory, name);
                        }
                    }

                    BookManager.UpdateBasicBooksInfo(_allBasicBooksWithoutRealUrl);
                    AddMessage("Updated Successed!", MessageType.Success);
                }
                else
                {
                    AddMessage("Invalid Folder!", MessageType.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "UpdateDownloaded failed");
                _logger.Log(ex);
            }
        }

        private bool IsFileExist(DirectoryInfo directory, string namePattern)
        {
            if (directory.GetFiles(string.Format("{0}.pdf", namePattern)).Length > 0
                            || directory.GetFiles(string.Format("{0}_*.pdf", namePattern)).Length > 0)
                return true;
            return false;
        }

        #region Update Local files
        public void UpdateLocalFiles()
        {
            try
            {
                StringBuilder logResult = new StringBuilder();
                _allBasicBooksWithoutRealUrl = BookManager.GetBasicBooksWithoutDownloadUrl(StartNum, EndNum);
                var mapping = GetFileMapping();
                if (!string.IsNullOrEmpty(Folder) && Directory.Exists(Folder))
                {
                    DirectoryInfo directory = new DirectoryInfo(Folder);
                    FileInfo[] fileInfos = directory.GetFiles();
                    foreach (var fileInfo in fileInfos)
                    {
                        if (string.Equals(fileInfo.Extension, ".html", StringComparison.OrdinalIgnoreCase) 
                            && fileInfo.Length < 1024 * 1024)
                        {
                            fileInfo.Delete();
                            continue;
                        }
                        string fileNameWithoutExtension = fileInfo.Name;
                        if (!string.IsNullOrEmpty(fileInfo.Extension))
                        {
                            fileNameWithoutExtension = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.'));
                        }

                        string key = fileNameWithoutExtension.ToUpper();
                        if (mapping.ContainsKey(key))
                        {
                            logResult.AppendLine(string.Format("Rename: {0} -> {1}", fileInfo.Name, mapping[key]));
                            IOFile.Move(fileInfo.FullName, GetFileName(Path.Combine(Folder, mapping[key])));
                        }
                        else if (!string.Equals(fileInfo.Extension, ".pdf", StringComparison.OrdinalIgnoreCase))
                        {
                            logResult.AppendLine(string.Format("Adjust Extension: {0}", fileInfo.Name));
                            string destinationFilePath = GetFileName(Path.Combine(Folder, string.Format("{0}.pdf", fileNameWithoutExtension)));
                            IOFile.Move(fileInfo.FullName, destinationFilePath);
                        }
                    }

                    _logger.Log(logResult.ToString());
                    //BookManager.UpdateBasicBooksInfo(_allBasicBooksWithoutRealUrl);
                    AddMessage("Updated Successed!", MessageType.Success);
                }
                else
                {
                    AddMessage("Invalid Folder!", MessageType.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Update local files failed");
                _logger.Log(ex);
            }
        }

        private string GetFileName(string filePath, int i = 0)
        {
            string originalfilePath = filePath;
            if (i != 0)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                if (!string.IsNullOrEmpty(fileInfo.Extension))
                    filePath = string.Format("{0}_{1}{2}", fileInfo.FullName.Substring(0, fileInfo.Name.LastIndexOf('.')), i , fileInfo.Extension);
                else
                    filePath = string.Format("{0}_{1}", fileInfo.FullName, i);
            }
            if (IOFile.Exists(filePath))
            {
                return GetFileName(originalfilePath, ++i);
            }
            else
                return filePath;
        }

        private Dictionary<string, string> GetFileMapping()
        {
            Dictionary<string, string> fileMappings = new Dictionary<string, string>();
            foreach (var book in _allBasicBooksWithoutRealUrl)
            {
                string mappingName = book.DownloadUrl.Substring(book.DownloadUrl.LastIndexOf('/') + 1);
                var key = mappingName.ToUpper();
                if (!fileMappings.ContainsKey(key))
                    fileMappings.Add(mappingName.ToUpper(), AdjustFileName(book.Name));
            }
            return fileMappings;
        }

        private string AdjustFileName(string bookName)
        {
            string fileName = bookName;

            foreach (var invalidChar in CommonConstant.InvalidFileNameCharacters)
            {
                if (fileName.Contains(invalidChar))
                {
                    fileName = fileName.Replace(invalidChar, '_');
                }
            }
            fileName = string.Format("{0}.pdf", fileName);
            return fileName;
        }

        #endregion

        private IBookManager _bookManager;
        private IBookManager BookManager
        {
            get
            {
                if (_bookManager == null)
                {
                    _bookManager = ManagerFactory.GetBookManager();
                }
                return _bookManager;
            }
        }

        #region Parallel Start

        public int _startIndex = 1;
        public int StartIndex
        {
            get
            {
                return _startIndex;
            }
            set
            {
                _startIndex = value;
            }
        }

        private int _notFoundCount = 0;

        private List<Book> InitialData()
        {
            return new List<Book>();
        }

        private List<Book> DoJobOfStart(int index, ParallelLoopState state, List<Book> books)
        {
            string url = string.Format(UrlFormat, index);
            try
            {
                Book book = GetBook(url);
                if (book.HttpStatus == HttpStatusCode.NotFound.ToString())
                    Interlocked.Increment(ref _notFoundCount);
                //if (NeedCancel())
                //    state.Break();
                books.Add(book);
            }
            catch (Exception ex)
            {
                AddMessage(string.Format("Get {0} failed, error: {1}", url, ex.Message), MessageType.Error);
                _logger.Log(url);
                _logger.Log(ex);
            }
            return books;
        }

        private void WriteToDB(List<Book> books)
        {
            try
            {
                BookManager.InsertBooks(books);
                //AddMessage(string.Format("Get {0} books, and updated to DB", books.Count), MessageType.Success);
            }
            catch (Exception ex)
            {
                AddMessage(ex.Message, MessageType.Error);
                foreach (Book book in books)
                {
                    _logger.Log(book.ToString());
                }
                _logger.Log(ex);
            }
        }

        private bool NeedCancel()
        {
            return _notFoundCount > 100;
        }

        #endregion

        #region Parallel DownloadMissedBooks

        private bool _includeNotFound = false;

        public bool IncludeNotFound
        {
            get
            {
                return _includeNotFound;
            }
            set
            {
                _includeNotFound = value;
            }
        }

        private List<int> _missedUrlNumbers = new List<int>();
        private List<Book> DoJobOfDownload(int index, ParallelLoopState state, List<Book> books)
        {
            string url = string.Format(UrlFormat, _missedUrlNumbers[index]);
            try
            {

                Book book = GetBook(url);
                if (book.HttpStatus == HttpStatusCode.NotFound.ToString())
                    Interlocked.Increment(ref _notFoundCount);
                //if (NeedCancel())
                //    state.Break();
                books.Add(book);
            }
            catch (Exception ex)
            {
                AddMessage(string.Format("Get {0} failed, error: {1}", url, ex.Message), MessageType.Error);
                _logger.Log(url);
                _logger.Log(ex);
            }
            return books;
        }

        #endregion

        #region Parallel Get Real Download Urls

        public int StartNum { get; set; }
        public int EndNum { get; set; }

        private List<BasicBook> _allBasicBooksWithoutRealUrl;
        private List<BasicBook> InitialDataOfRealUrl()
        {
            return new List<BasicBook>();
        }

        private List<BasicBook> DoJobOfRealUrl(int index, ParallelLoopState state, List<BasicBook> books)
        {
            BasicBook book = _allBasicBooksWithoutRealUrl[index];
            try
            {
                HttpHelper httpHelper = new HttpHelper();
                httpHelper.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                httpHelper.Referer = book.WebUrl;
                httpHelper.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.87 Safari/537.36";
                using (var responseHearder = httpHelper.GetResponseHeader(book.DownloadUrl))
                {
                    if (responseHearder.StatusCode == HttpStatusCode.OK)
                    {
                        book.RealDownloadUrl = responseHearder.ResponseUri.AbsoluteUri;
                        books.Add(book);
                    }
                    else
                    {
                        _logger.Log(string.Format("Get real download url failed: {0}, Error Code: {1}", book.WebUrl, responseHearder.StatusCode));
                    }
                    responseHearder.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = string.Format("Get {0} failed for real download url, error: {1}", book.WebUrl, ex.Message);
                AddMessage(errorMsg, MessageType.Error);
                _logger.Log(LogLevel.Error, errorMsg);
                _logger.Log(ex);
            }
            return books;
        }

        private void WriteToMemoOfRealUrl(List<BasicBook> books)
        {
            //try
            //{
            //}
            //catch (Exception ex)
            //{
            //    AddMessage(ex.Message, MessageType.Error);
            //    foreach (BasicBook book in books)
            //    {
            //        _logger.Log(book.ToString());
            //    }
            //    _logger.Log(ex);
            //}
        }

        public string Folder { get; set; }

        #endregion

        private Book GetBook(string url)
        {
            Book book = new Book();
            book.WebUrl = url;
            int retry = 1;
            Exception lastError = null;
            do
            {
                try
                {
                    var response = _httpHelper.GetResponse(url);
                    book.HttpStatus = response.StatusCode.ToString();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (response.ResponseUri.OriginalString == HTTPSTATE_NOTFOUND)
                        {
                            book.HttpStatus = HttpStatusCode.NotFound.ToString();
                        }
                        else
                        {
                            string content = _httpHelper.GetString(response);
                            var fields = AnalyzeFieldsNeeded(content);
                            Mapping(book, fields);
                        }
                    }
                    else
                    {
                        response.Close();
                    }
                    Thread.Sleep(1000);
                    break;
                }
                catch (WebException webEx)
                {
                    Thread.Sleep(60000);
                    lastError = webEx;
                }
                catch (Exception ex)
                {
                    book.HttpStatus = ex.Message;
                    _logger.Log(LogLevel.Error, string.Format("GetBook error failed, URL:{0}, Exception: {1},", url, ex.ToString()));
                    break;
                }
            }
            while (retry++ < 3);
            if (lastError != null)
            {
                book.HttpStatus = lastError.Message;
                _logger.Log(LogLevel.Error, string.Format("GetBook error failed after retried, URL:{0}, Exception: {1},", url, lastError.ToString()));
            }
            return book;
        }

        private static Dictionary<string, string> AnalyzeFieldsNeeded(string str)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(str);
            HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//*[@itemprop]");
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            foreach (var node in collection)
            {
                if (node.Attributes.Contains("itemprop"))
                    keyValue.Add(node.Attributes["itemprop"].Value, node.InnerText);
            }
            string fileSize = string.Empty;
            HtmlNodeCollection fileSizeCollection = doc.DocumentNode.SelectNodes("//td[text() = 'File size:']");
            if (fileSizeCollection != null && fileSizeCollection.Count > 0)
            {
                HtmlNode node = fileSizeCollection[0].NextSibling;
                if (node != null && node.FirstChild != null)
                    fileSize = node.FirstChild.InnerText;
            }
            keyValue.Add("fileSize", fileSize);

            string downloadUrl = string.Empty;
            HtmlNodeCollection downloadedCollection = doc.DocumentNode.SelectNodes("//td[text() = 'Download:']");
            if (downloadedCollection != null && downloadedCollection.Count > 0)
            {
                HtmlNode node = downloadedCollection[0].NextSibling;
                if (node != null && node.FirstChild != null && node.FirstChild.Attributes["href"] != null)
                    downloadUrl = node.FirstChild.Attributes["href"].Value;
            }
            keyValue.Add("downloadUrl", downloadUrl);
            return keyValue;
        }

        private static void Mapping(Book book, Dictionary<string, string> dic)
        {
            foreach (var keyValue in dic)
            {
                if (Equals(keyValue.Key, "name"))
                    book.Name = keyValue.Value;
                else if (Equals(keyValue.Key, "description"))
                    book.Description = keyValue.Value;
                else if (Equals(keyValue.Key, "publisher"))
                    book.Publisher = keyValue.Value;
                else if (Equals(keyValue.Key, "author"))
                    book.Author = keyValue.Value;
                else if (Equals(keyValue.Key, "isbn"))
                    book.ISBN = keyValue.Value;
                else if (Equals(keyValue.Key, "datePublished"))
                    book.PublishTime = keyValue.Value;
                else if (Equals(keyValue.Key, "numberOfPages"))
                    book.Page = keyValue.Value;
                else if (Equals(keyValue.Key, "inLanguage"))
                    book.Laguage = keyValue.Value;
                else if (Equals(keyValue.Key, "bookFormat"))
                    book.FileFormat = keyValue.Value;
                else if (Equals(keyValue.Key, "fileSize"))
                    book.FileSize = keyValue.Value;
                else if (Equals(keyValue.Key, "downloadUrl"))
                    book.DownloadUrl = keyValue.Value;
            }
        }

        private static bool Equals(string str1, string str2)
        {
            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        public int LastValidNumber
        {
            get
            {
                return BookManager.GetLastValidNumber();
            }
        }
    }
}
