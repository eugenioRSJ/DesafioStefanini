using Example.Domain;

namespace Example.Application.CidadeService.Models.Dtos
{
    public class CidadeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public static explicit operator CidadeDTO(Cidade c)
        {
            return new CidadeDTO()
            {
                Id = c.Id,
                Nome = c.Nome,
                UF = c.UF
            };
        }
    }
}