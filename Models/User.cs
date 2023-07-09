using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace İnsanKaynaklarıPT.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool KeepLogged { get; set; }
        public bool İsActtive  { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }

        [ForeignKey("Depart")]
        public int DepartId { get; set; }
        public Depart? Depart { get; set; }
    }
}
