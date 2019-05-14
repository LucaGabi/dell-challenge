using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D2.Web.Models
{
    public class NewProductModel
    {
        [Required]
        [RegularExpression("[A-Za-z ,.]+")]
        public string Name { get; set; }
        [RegularExpression("[A-Za-z ,.]+")]
        public string Category { get; set; }
    }
}
