using NBAStatsAPI.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Dominio.Interface
{
    public interface IPosicaoRepository
    {
        Task<List<Posicao>> FindAll();
        Task<Posicao> FindById(long id);
        Task<Posicao> FindByName(string nome);
        Task<Posicao> Create(Posicao posicao);
        Task<Posicao> Update(Posicao posicao);
        Task<bool> Delete(long id);
    }
}
