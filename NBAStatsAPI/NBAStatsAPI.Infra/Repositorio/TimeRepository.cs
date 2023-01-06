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
    public class TimeRepository : ITimeRepository
    {
        private readonly NBAStatsAPIContext _context;

        public TimeRepository(NBAStatsAPIContext context)
        {
            _context = context;
        }


        public async Task<List<Time>> FindAll()
        {
            return await _context.Times.ToListAsync();
        }
        public async Task<Time> FindById(long id)
        {
            return await _context.Times.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Time> FindByName(string nome)
        {
            return await _context.Times.Where(t => t.Nome == nome).FirstOrDefaultAsync();
        }
        public async Task<Time> Create(Time time)
        {
            await _context.Times.AddAsync(time);
            await _context.SaveChangesAsync();

            return time;
        }
        public async Task<Time> Update(Time time)
        {
            var timeEncontrado = await _context.Times.Where(t => t.Id == time.Id).FirstOrDefaultAsync();
            if (timeEncontrado == null) return null;

            timeEncontrado.Nome = time.Nome;

            _context.Times.Update(timeEncontrado);
            await _context.SaveChangesAsync();

            return timeEncontrado;
        }
        public async Task<bool> Delete(long id)
        {
            var timeEncontrado = await _context.Times.Where(t => t.Id == id).FirstOrDefaultAsync();
            if (timeEncontrado == null) return false;

            _context.Times.Remove(timeEncontrado);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
