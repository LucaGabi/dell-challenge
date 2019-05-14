using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D1.Api.Dto
{
    public class NewProductDto
    {
        [Required]
        [RegularExpression("[A-Za-z ,.]+")]
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
