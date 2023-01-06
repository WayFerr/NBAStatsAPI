using Microsoft.EntityFrameworkCore;
using NBAStatsAPI.Dominio.Interface;
using NBAStatsAPI.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Infra.Repositorio
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly NBAStatsAPIContext _context;

        public JogadorRepository(NBAStatsAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Jogador>> FindAll()
        {
            return await _context.Jogadores.ToListAsync();
        }

        public async Task<Jogador> FindById(long id)
        {
            return await _context.Jogadores.Where(j => j.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Jogador> FindByName(string nome)
        {
            return await _context.Jogadores.Where(j => j.Nome == nome).FirstOrDefaultAsync();
        }
        public async Task<Jogador> Create(Jogador jogador)
        {
            await _context.AddAsync(jogador);
            await _context.SaveChangesAsync();
            
            return jogador;
        }
        public async Task<Jogador> Update(Jogador jogador)
        {
            var jogadorEncontrado = await _context.Jogadores.Where(j => j.Id == jogador.Id).FirstOrDefaultAsync();
            if (jogadorEncontrado == null) return null;

            jogadorEncontrado.Nome = jogador.Nome;
            jogadorEncontrado.PPG = jogador.PPG;
            jogadorEncontrado.PontosTotais = jogador.PontosTotais;
            jogadorEncontrado.APG = jogador.APG;
            jogadorEncontrado.AssistenciasTotais = jogador.AssistenciasTotais;
            jogadorEncontrado.RPG = jogador.RPG;
            jogadorEncontrado.RebotesTotais = jogador.RebotesTotais;
            jogadorEncontrado.BPG = jogador.BPG;
            jogadorEncontrado.BlocksTotais = jogador.BlocksTotais;
            jogadorEncontrado.SPG = jogador.SPG;
            jogadorEncontrado.StealsTotais = jogador.StealsTotais;
            jogadorEncontrado.PosicaoId = jogador.PosicaoId;
            jogadorEncontrado.TimeId = jogador.TimeId;

            _context.Jogadores.Update(jogadorEncontrado);
            await _context.SaveChangesAsync();

            return jogadorEncontrado;
        }
        public async Task<bool> Delete(long id)
        {
            var jogadorEncontrado = await _context.Jogadores.Where(j => j.Id == id).FirstOrDefaultAsync();
            if (jogadorEncontrado == null) return false;

            _context.Jogadores.Remove(jogadorEncontrado);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
