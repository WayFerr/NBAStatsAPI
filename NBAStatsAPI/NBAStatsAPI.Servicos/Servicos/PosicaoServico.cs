using NBAStatsAPI.Dominio.Interface;
using NBAStatsAPI.Dominio.Model;
using NBAStatsAPI.Servicos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Servicos.Servicos
{
    public class PosicaoServico : IPosicaoServico
    {
        private readonly IPosicaoRepository _posicao;

        public PosicaoServico(IPosicaoRepository posicao)
        {
            _posicao = posicao;
        }


        public async Task<List<Posicao>> FindAll()
        {
            return await _posicao.FindAll();
        }
        public async Task<Posicao> FindById(long id)
        {
            return await _posicao.FindById(id);
        }
        public async Task<Posicao> FindByName(string nome)
        {
            return await _posicao.FindByName(nome);
        }
        public async Task<Posicao> Create(Posicao posicao)
        {
            var posicaoEncontrada = await _posicao.FindByName(posicao.Nome);
            if (posicaoEncontrada != null) return null;

            return await _posicao.Create(posicao);
        }
        public async Task<Posicao> Update(Posicao posicao)
        {
            var posicaoEncontrada = await _posicao.FindById(posicao.Id);
            if (posicaoEncontrada == null) return null;

            return await _posicao.Update(posicao);
        }
        public async Task<bool> Delete(long id)
        {
            var posicaoEncontrada = await _posicao.FindById(id);
            if (posicaoEncontrada == null) return false;

            return await _posicao.Delete(id);
        }
    }
}
