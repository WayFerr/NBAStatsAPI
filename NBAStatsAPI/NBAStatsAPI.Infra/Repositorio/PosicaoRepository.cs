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
    public class PosicaoRepository : IPosicaoRepository
    {
        private readonly NBAStatsAPIContext _context;

        public PosicaoRepository(NBAStatsAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Posicao>> FindAll()
        {
            return await _context.Posicoes.ToListAsync();
        }
        public async Task<Posicao> FindById(long id)
        {
            return await _context.Posicoes.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Posicao> FindByName(string nome)
        {
            return await _context.Posicoes.Where(p => p.Nome == nome).FirstOrDefaultAsync();
        }
        public async Task<Posicao> Create(Posicao posicao)
        {
            await _context.Posicoes.AddAsync(posicao);
            await _context.SaveChangesAsync();

            return posicao;
        }
        public async Task<Posicao> Update(Posicao posicao)
        {
            var posicaoEncontrada = await _context.Posicoes.Where(p => p.Id == posicao.Id).FirstOrDefaultAsync();
            if (posicaoEncontrada == null) return null;

            posicaoEncontrada.Nome = posicao.Nome;
            posicaoEncontrada.Abreviacao = posicao.Abreviacao;

            _context.Posicoes.Update(posicaoEncontrada);
            await _context.SaveChangesAsync();

            return posicaoEncontrada;
        }
        public async Task<bool> Delete(long id)
        {
            var posicaoEncontrada = await _context.Posicoes.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (posicaoEncontrada == null) return false;

            _context.Posicoes.Remove(posicaoEncontrada);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
