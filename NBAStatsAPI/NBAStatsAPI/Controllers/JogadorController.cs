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
    public class JogadorController : ControllerBase
    {
        private readonly IJogadorServico _jogador;
        private readonly IMapper _mapper;

        public JogadorController(IJogadorServico jogador, IMapper mapper)
        {
            _jogador = jogador;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var jogadoresEncontrados = await _jogador.FindAll();
            if (jogadoresEncontrados == null) return NotFound("Jogadores não encontrados");
            
            return Ok(jogadoresEncontrados);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var jogadorEncontrado = await _jogador.FindById(id);
            if (jogadorEncontrado == null) return NotFound("Jogador não encontrado");

            return Ok(jogadorEncontrado);
        }
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> FindByName(string nome)
        {
            var jogadorEncontrado = await _jogador.FindByName(nome);
            if (jogadorEncontrado == null) return NotFound("Jogador não encontrado");

            return Ok(jogadorEncontrado);
        }
        [HttpPost]
        public async Task<IActionResult> Create(JogadorViewModel jogador)
        {
            if (jogador == null) return BadRequest();

            var entidade = _mapper.Map<Jogador>(jogador);
            await _jogador.Create(entidade);

            return Ok(jogador);
        }
        [HttpPut]
        public async Task<IActionResult> Update(JogadorViewModel jogador)
        {
            if (jogador.Id == null) return BadRequest();

            var entidade = _mapper.Map<Jogador>(jogador);
            await _jogador.Update(entidade);

            return Ok(jogador);
        }
        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var jogadorEncontrado = await _jogador.FindById(id);
            if (jogadorEncontrado == null) return NotFound("Jogador não encontrado");

            await _jogador.Delete(jogadorEncontrado.Id);

            return Ok(jogadorEncontrado);
        }
    }
}
