namespace Example.Application.PessoaService.Models.Request
{
    public class UpdatePessoaRequest
    {
        public string Nome { get; set; }
        public  string CPF { get; set; }
        public  int Idade { get; set; }
        public int CidadeId { get; set; }
    }
}