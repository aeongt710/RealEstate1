using Microsoft.AspNetCore.Http;
using RealEstate1.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace RealEstate1.Models.ViewModels
{
    public class SocietyCreateVM
    {
        public Society Society { get; set; }
        [Required]
        [FileExtens(".png",".jpg")]
        public IFormFile Image { get; set; }
    }
}
