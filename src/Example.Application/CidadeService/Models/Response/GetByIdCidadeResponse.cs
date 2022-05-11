using Example.Application.CidadeService.Models.Dtos;
using Example.Application.Common;

namespace Example.Application.CidadeService.Models.Response
{
    public class GetByIdCidadeResponse : BaseResponse
    {
        public CidadeDTO Cidade { get; set; }
    }
}