using System.ComponentModel.DataAnnotations;

namespace BigWord.Data.Models
{
    public class Word
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Value { get; set; }
    }
}
