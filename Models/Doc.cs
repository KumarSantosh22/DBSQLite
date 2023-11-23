using System.Text.Json.Serialization;
namespace DBSQLite.Models
{
    public class Doc
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("journal")]
        public string Journal { get; set; }


        [JsonPropertyName("eissn")]
        public string Eissn { get; set; }


        [JsonPropertyName("publication_date")]
        public DateTime PublicationDate { get; set; }


        [JsonPropertyName("article_type")]
        public string ArticleType { get; set; }


        [JsonPropertyName("author_display")]
        public List<string> AuthorDisplay { get; set; }


        [JsonPropertyName("abstract")]
        public List<string> Abstract { get; set; }


        [JsonPropertyName("title_display")]
        public string TitleDisplay { get; set; }


        [JsonPropertyName("score")]
        public double Score { get; set; }

        public Doc() { }

        public Doc(Data.Doc doc)
        {
            Id = doc.Id;
            Journal = doc.Journal;
            Eissn = doc.Eissn;
            PublicationDate = doc.PublicationDate;
            ArticleType = doc.ArticleType;
            AuthorDisplay = doc.AuthorDisplay.Split(",").ToList();
            Abstract = doc.Abstract.Split(",").ToList();
            TitleDisplay = doc.TitleDisplay;
            Score = doc.Score;
        }

        public Data.Doc MapToDataModel() =>
            new()
            {
                Id = Id,
                Journal = Journal,
                Eissn = Eissn,
                PublicationDate = PublicationDate,
                ArticleType = ArticleType,
                AuthorDisplay = string.Join(',', AuthorDisplay),
                Abstract = string.Join(',', Abstract),
                TitleDisplay = TitleDisplay,
                Score = Score
            };

    }
}
