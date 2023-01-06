using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Dominio.Model
{
    public class Time
    {
        public Time()
        {
            Jogadores = new HashSet<Jogador>();
        }
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        public ICollection<Jogador> Jogadores { get; set; }
    }
}
