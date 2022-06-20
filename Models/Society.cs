using System.ComponentModel.DataAnnotations;

namespace RealEstate1.Models
{
    public class Society
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Society Name")]
        public string SocietyName { get; set; }
        public string? ImgSrc { get; set; }
        [Required(ErrorMessage ="Please Mark a Location...")]
        public float Longitude { get; set; }
        [Required(ErrorMessage = "Please Mark a Location...")]
        public float Latitude { get; set; }
        [Required]
        public string City { get; set; }
        public string? Description { get; set; }
    }
}
