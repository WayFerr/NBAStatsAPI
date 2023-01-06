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
    public class JogadorServico : IJogadorServico
    {
        private readonly IJogadorRepository _jogador;

        public JogadorServico(IJogadorRepository jogador)
        {
            _jogador = jogador;
        }


        public async Task<List<Jogador>> FindAll()
        {
            return await _jogador.FindAll();
        }
        public async Task<Jogador> FindById(long id)
        {
            return await _jogador.FindById(id);
        }
        public async Task<Jogador> FindByName(string nome)
        {
            return await _jogador.FindByName(nome);
        }
        public async Task<Jogador> Create(Jogador jogador)
        {
            var jogadorEncontrado = await _jogador.FindByName(jogador.Nome);
            if (jogadorEncontrado != null) return null;

            return await _jogador.Create(jogador);
        }
        public async Task<Jogador> Update(Jogador jogador)
        {
            var jogadorEncontrado = await _jogador.FindById(jogador.Id);
            if (jogadorEncontrado == null) return null;

            return await _jogador.Update(jogador);
        }
        public async Task<bool> Delete(long id)
        {
            var jogadorEncontrado = await _jogador.FindById(id);
            if (jogadorEncontrado == null) return false;

            return await _jogador.Delete(id);
        }
    }
}
