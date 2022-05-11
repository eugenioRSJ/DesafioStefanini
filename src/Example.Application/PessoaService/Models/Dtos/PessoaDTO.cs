using Example.Domain;

namespace Example.Application.PessoaService.Models.Dtos
{
    public class PessoaDTO
    {
        public  int Id { get; set; }
        public string Nome { get; set; }
        public  string CPF { get; set; }
        public  int Idade { get; set; }
        public int CidadeId { get; set; }

        public static explicit operator PessoaDTO(Pessoa p)
        {
            return new PessoaDTO()
            {
                Id = p.Id,
                Nome = p.Nome,
                CPF = p.CPF,
                Idade = p.Idade,
                CidadeId = p.CidadeId
            };
        }
    }
}