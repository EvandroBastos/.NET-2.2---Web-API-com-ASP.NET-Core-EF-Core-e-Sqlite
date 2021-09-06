using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAgil.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebApi.Data;
using Microsoft.AspNetCore.Http;


namespace ProAgil.WebApi.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _contexto;

        public ValuesController(DataContext contexto)
        {
            _contexto = contexto;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _contexto.Eventos.ToListAsync();
                return Ok(resultado);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var resultado = await _contexto.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(resultado);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no Banco de Dados");
            }

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
