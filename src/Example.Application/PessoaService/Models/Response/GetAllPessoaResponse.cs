using Example.Application.Common;
using Example.Application.PessoaService.Models.Dtos;

namespace Example.Application.PessoaService.Models.Response
{
    public class GetAllPessoaResponse : BaseResponse
    {
        public List<PessoaDTO> Pessoas { get; set; }
    }
}