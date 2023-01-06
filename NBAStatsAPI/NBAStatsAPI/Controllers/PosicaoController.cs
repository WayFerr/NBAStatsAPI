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
    public class PosicaoController : ControllerBase
    {
        private readonly IPosicaoServico _posicao;
        private readonly IMapper _mapper;

        public PosicaoController(IPosicaoServico posicao, IMapper mapper)
        {
            _posicao = posicao;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var posicoesEncontradas = await _posicao.FindAll();
            if (posicoesEncontradas == null) return NotFound("Posições não encontradas");

            return Ok(posicoesEncontradas);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var posicaoEncontrada = await _posicao.FindById(id);
            if (posicaoEncontrada == null) return NotFound("Posição não encontrada");

            return Ok(posicaoEncontrada);
        }
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> FindByName(string nome)
        {
            var posicaoEncontrada = await _posicao.FindByName(nome);
            if (posicaoEncontrada == null) return NotFound("Posição não encontrada");

            return Ok(posicaoEncontrada);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PosicaoViewModel posicao)
        {
            if (posicao == null) return BadRequest();

            var entidade = _mapper.Map<Posicao>(posicao);
            await _posicao.Create(entidade);

            return Ok(posicao);
        }
        [HttpPut]
        public async Task<IActionResult> Update(PosicaoViewModel posicao)
        {
            if (posicao.Id == null) return BadRequest();

            var entidade = _mapper.Map<Posicao>(posicao);
            await _posicao.Update(entidade);

            return Ok(posicao);
        }
        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var posicaoEncontrada = await _posicao.FindById(id);
            if (posicaoEncontrada == null) return NotFound("Posição não encontrada");

            await _posicao.Delete(posicaoEncontrada.Id);

            return Ok(posicaoEncontrada);
        }
    }
}
