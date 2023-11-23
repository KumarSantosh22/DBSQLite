using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBSQLite.Data
{
    [Table("Doc")]
    public class Doc
    {
        [Key]
        public string Id { get; set; }

        public string Journal { get; set; }


        public string Eissn { get; set; }


        public DateTime PublicationDate { get; set; }


        public string ArticleType { get; set; }

        public string AuthorDisplay { get; set; }


        public string Abstract { get; set; }


        public string TitleDisplay { get; set; }


        public double Score { get; set; }

    }
}
