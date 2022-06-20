using System.ComponentModel.DataAnnotations;

namespace RealEstate1.Models
{
    public class Block
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Block Name")]
        public string BlockName { get; set; }
        public int SocietyId { get; set; }
        public Society Society { get; set; }

    }
}
