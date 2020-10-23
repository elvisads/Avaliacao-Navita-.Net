namespace Navita.Avaliacao.Modelos
{
    public class Patrimonio
    {
        public int NroTombo{ get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
    } 
}
