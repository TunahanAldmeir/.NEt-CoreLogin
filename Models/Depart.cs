using System.ComponentModel.DataAnnotations;

namespace İnsanKaynaklarıPT.Models
{
    public class Depart
    {
        [Key]
        public int DepartId { get; set; }
        public string? DepartName { get; set;}
    }
}
