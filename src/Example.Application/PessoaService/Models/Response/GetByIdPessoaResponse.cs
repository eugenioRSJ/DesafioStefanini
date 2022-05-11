using Example.Application.Common;
using Example.Application.PessoaService.Models.Dtos;

namespace Example.Application.PessoaService.Models.Response
{
    public class GetByIdPessoaResponse : BaseResponse
    {
        public PessoaDTO Pessoa { get; set; }
    }
}