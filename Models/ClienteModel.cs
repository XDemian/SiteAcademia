namespace SiteAcademia.Models
{
    public class ClienteModel
    {

        public int Id { get; set; }
        public string? Nome   { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public decimal? Altura { get; set; }
        public decimal? Peso { get; set; }
    }
}
