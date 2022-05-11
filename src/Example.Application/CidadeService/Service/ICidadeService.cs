using Example.Application.CidadeService.Models.Request;
using Example.Application.CidadeService.Models.Response;

namespace Example.Application.CidadeService.Service
{
    public interface ICidadeService
    {
        Task<GetAllCidadeResponse> GetAllAsync();
        Task<GetByIdCidadeResponse> GetByIdAsync(int id);
        Task<CreateCidadeResponse> CreateAsync(CreateCidadeRequest request);
        Task<UpdateCidadeResponse> UpdateAsync(int id, UpdateCidadeRequest request);
        Task<DeleteCidadeResponse> DeleteAsync(int id);
    }
}