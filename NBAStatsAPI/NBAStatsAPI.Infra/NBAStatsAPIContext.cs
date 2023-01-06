using Microsoft.EntityFrameworkCore;
using NBAStatsAPI.Dominio.Model;

namespace NBAStatsAPI.Infra
{
    public class NBAStatsAPIContext : DbContext
    {
        public NBAStatsAPIContext(DbContextOptions<NBAStatsAPIContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}
