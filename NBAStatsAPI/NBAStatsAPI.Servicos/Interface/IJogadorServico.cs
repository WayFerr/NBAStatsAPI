using NBAStatsAPI.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Servicos.Interface
{
    public interface IJogadorServico
    {
        Task<List<Jogador>> FindAll();
        Task<Jogador> FindById(long id);
        Task<Jogador> FindByName(string nome);
        Task<Jogador> Create(Jogador jogador);
        Task<Jogador> Update(Jogador jogador);
        Task<bool> Delete(long id);
    }
}
