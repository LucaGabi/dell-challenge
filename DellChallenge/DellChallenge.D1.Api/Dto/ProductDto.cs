using System.ComponentModel.DataAnnotations;

namespace DellChallenge.D1.Api.Dto
{
    public class ProductDto : NewProductDto
    {
        [Required]
        public string Id { get; set; }
    }
}
