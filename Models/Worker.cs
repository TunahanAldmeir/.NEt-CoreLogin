using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace İnsanKaynaklarıPT.Models
{
	public class Worker
	{
		[Key]
        public int WorkerId { get; set; }
        public string? WorkerName { get; set; }
        public string? WorkerLastName { get; set; }
        public string? WorkerAge { get; set; }
        public DateTime WorkerStartDay { get; set; }
        public string? WorkerAdress { get; set; }


        [ForeignKey("Depart")]
		public int DepartId { get; set; }
		public Depart? Depart { get; set; }
		public ICollection<WorkerVacation>? Vacations { get; set; }
	}
}
