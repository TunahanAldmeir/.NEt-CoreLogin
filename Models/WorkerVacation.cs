using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace İnsanKaynaklarıPT.Models
{
	public class WorkerVacation
	{
		[Key]
        public int İzinId { get; set; }
        public string? İzinAcıklama { get; set; }
        public DateTime İzinBaslangıcTarihi { get; set; }
        public DateTime İzinBitisTarihi { get; set; }

		[ForeignKey("Worker")]
		public int WorkerId { get; set; }
		public Worker Worker { get; set; }

	}
}
