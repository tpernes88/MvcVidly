using System.ComponentModel.DataAnnotations;

namespace VidlyMvc.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string GenreName { get; set; }
    }
}