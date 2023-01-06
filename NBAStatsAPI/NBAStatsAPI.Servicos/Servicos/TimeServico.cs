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
    public class TimeServico : ITimeServico
    {
        private readonly ITimeRepository _time;

        public TimeServico(ITimeRepository time)
        {
            _time = time;
        }


        public async Task<List<Time>> FindAll()
        {
            return await _time.FindAll();
        }
        public async Task<Time> FindById(long id)
        {
            return await _time.FindById(id);
        }
        public async Task<Time> FindByName(string nome)
        {
            return await _time.FindByName(nome);
        }
        public async Task<Time> Create(Time time)
        {
            var timeEncontrado = await _time.FindByName(time.Nome);
            if (timeEncontrado != null) return null;

            return await _time.Create(time);
        }
        public async Task<Time> Update(Time time)
        {
            var timeEncontrado = await _time.FindById(time.Id);
            if (timeEncontrado == null) return null;

            return await _time.Update(time);
        }
        public async Task<bool> Delete(long id)
        {
            var timeEncontrado = await _time.FindById(id);
            if (timeEncontrado == null) return false;

            return await _time.Delete(id);
        }
    }
}
