using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBAStatsAPI.Dominio.Model;
using NBAStatsAPI.Dominio.ViewModel;
using NBAStatsAPI.Servicos.Interface;

namespace NBAStatsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly ITimeServico _time;
        private readonly IMapper _mapper;

        public TimeController(ITimeServico time, IMapper mapper)
        {
            _time = time;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var timesEncontrados = await _time.FindAll();
            if (timesEncontrados == null) return NotFound("Times não encontrados");

            return Ok(timesEncontrados);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var timeEncontrado = await _time.FindById(id);
            if (timeEncontrado == null) return NotFound("Time não encontrado");

            return Ok(timeEncontrado);
        }
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> FindByName(string nome)
        {
            var timeEncontrado = await _time.FindByName(nome);
            if (timeEncontrado == null) return NotFound("Time não encontrado");

            return Ok(timeEncontrado);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TimeViewModel time)
        {
            if (time == null) return BadRequest();

            var entidade = _mapper.Map<Time>(time);
            await _time.Create(entidade);

            return Ok(time);
        }
        [HttpPut]
        public async Task<IActionResult> Update(TimeViewModel time)
        {
            if (time == null) return BadRequest();

            var entidade = _mapper.Map<Time>(time);
            await _time.Update(entidade);

            return Ok(time);
        }
        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var timeEncontrado = await _time.FindById(id);
            if (timeEncontrado == null) return NotFound("Time não encontrado");

            await _time.Delete(timeEncontrado.Id);

            return Ok(timeEncontrado);
        }
    }
}
