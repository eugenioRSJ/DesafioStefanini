using Example.Application.CidadeService.Models.Dtos;
using Example.Application.Common;

namespace Example.Application.CidadeService.Models.Response
{
    public class GetAllCidadeResponse : BaseResponse
    {
        public List<CidadeDTO> Cidades { get; set; }
    }
}