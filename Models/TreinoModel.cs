
namespace SiteAcademia.Models
{
    public class TreinoModel
    {

        public int Id { get; set; }
        public int? ClienteId { get; set; }
        public string? Exercicios { get; set; }
        public DateTime? Data { get; set; }
        public string? Observacoes { get; set; }

        public ClienteModel? Cliente { get; set; }  // Relacionamento com Cliente
    }
}
