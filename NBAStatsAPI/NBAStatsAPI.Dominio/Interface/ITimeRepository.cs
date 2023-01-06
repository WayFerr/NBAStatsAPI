using NBAStatsAPI.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Dominio.Interface
{
    public interface ITimeRepository
    {
        Task<List<Time>> FindAll();
        Task<Time> FindById(long id);
        Task<Time> FindByName(string nome);
        Task<Time> Create(Time time);
        Task<Time> Update(Time time);
        Task<bool> Delete(long id);
    }
}
