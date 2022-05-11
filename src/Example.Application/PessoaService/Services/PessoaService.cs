using Example.Application.CidadeService.Service;
using Example.Application.Common;
using Example.Application.PessoaService.Models.Dtos;
using Example.Application.PessoaService.Models.Request;
using Example.Application.PessoaService.Models.Response;
using Example.Domain;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.PessoaService.Services
{
    public class PessoaService : BaseService<PessoaService>, IPessoaService
    {
        private readonly ExampleContext _db;
        private readonly ICidadeService _cidadeService;
        public PessoaService(ILogger<PessoaService> logger, Infra.Data.ExampleContext db, ICidadeService cidadeService) : base(logger)
        {
            _db = db;
            _cidadeService = cidadeService;
        }

        public async Task<GetAllPessoaResponse> GetAllAsync()
        {
            var entity = await _db.Pessoas.ToListAsync();
            return new GetAllPessoaResponse()
            {
                Pessoas = entity != null ? entity.Select(a => (PessoaDTO)a).ToList() : new List<PessoaDTO>()
            };
        }

        public async Task<GetByIdPessoaResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdPessoaResponse();

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Pessoa = (PessoaDTO)entity;
            else
            {
                throw new ArgumentNullException("PessoaId","Pessoa não cadastrada na base de dados");
            }

            return response;
        }

        public async Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");
            
            await _cidadeService.GetByIdAsync(request.CidadeId);

            var newPessoa = Pessoa.Create(request.Nome, request.CPF, request.Idade, request.CidadeId);

            _db.Pessoas.Add(newPessoa);

            await _db.SaveChangesAsync();

            return new CreatePessoaResponse() { Id = newPessoa.Id };
        }

        public async Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            var cidade = await _cidadeService.GetByIdAsync(request.CidadeId); 
            if(!cidade.Success)
                throw new ArgumentException("A cidade informada não está cadastrada na base de dados");

            if (entity != null)
            {
                entity.Update(request.Nome, request.CPF, request.Idade, request.CidadeId);
                await _db.SaveChangesAsync();
            }

            return new UpdatePessoaResponse();
        }

        public async Task<DeletePessoaResponse> DeleteAsync(int id)
        {

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePessoaResponse();
        }
    }
}