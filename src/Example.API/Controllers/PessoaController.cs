using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Application.PessoaService.Models.Request;
using Example.Application.PessoaService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : BaseController
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service) : base()
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var action = await _service.GetAllAsync();
                return Ok(action);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var action = await _service.GetByIdAsync(id);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePessoaRequest request)
        {
            try
            {
                var action = await _service.CreateAsync(request);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePessoaRequest request)
        {
            try
            {
                var action = await _service.UpdateAsync(id, request);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var action = await _service.DeleteAsync(id);
                return Ok(action);
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }
    }
}