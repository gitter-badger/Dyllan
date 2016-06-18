using System;
using Dyllan.Common;

namespace Douban.Model
{
    public class SimpleBookInfo
    {
        public Guid ID { get; set; }
        public string WebUrl { get; set; }
        public string ISBN { get; set; }
        public string AverageScore { get; set; }
        public int RatingNum { get; set; }
        public float FiveStar { get; set; }
        public float FourStar { get; set; }
        public float ThreeStar { get; set; }
        public float TwoStar { get; set; }
        public float OneStar { get; set; }
        public string Tags { get; set; }
    }

    [TableType("dbo.[BookInfoType]")]
    public class BookInfo
    {
        [Column("ID")]
        public Guid ID { get; set; }
        [Column("WebUrl")]
        public string WebUrl { get; set; }
        [Column("UrlNumber")]
        public int UrlNumber { get; set; }
        [Column("BookName")]
        public string BookName { get; set; }
        [Column("Author")]
        public string Author { get; set; }
        [Column("Publisher")]
        public string Publisher { get; set; }
        [Column("PublishDate")]
        public string PublishDate { get; set; }
        [Column("PageNum")]
        public string PageNum { get; set; }
        [Column("Price")]
        public string Price { get; set; }
        [Column("ISBN")]
        public string ISBN { get; set; }
        [Column("AverageScore")]
        public float AverageScore { get; set; }
        [Column("RatingNum")]
        public int RatingNum { get; set; }
        [Column("FiveStar")]
        public float FiveStar { get; set; }
        [Column("FourStar")]
        public float FourStar { get; set; }
        [Column("ThreeStar")]
        public float ThreeStar { get; set; }
        [Column("TwoStar")]
        public float TwoStar { get; set; }
        [Column("OneStar")]
        public float OneStar { get; set; }
        [Column("ContentDescription")]
        public string ContentDescription { get; set; }
        [Column("AuthorDescription")]
        public string AuthorDescription { get; set; }
        [Column("Tags")]
        public string Tags { get; set; }
        [Column("HttpStatus")]
        public string HttpStatus { get; set; }

        public override string ToString()
        {
            return WebUrl;
        }
    }
}
