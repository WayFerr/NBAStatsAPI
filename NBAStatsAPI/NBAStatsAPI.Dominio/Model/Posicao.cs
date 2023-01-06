using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Dominio.Model
{
    public class Posicao
    {
        public Posicao()
        {
            Jogadores = new HashSet<Jogador>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
        [Required]
        [StringLength(3)]
        public string Abreviacao { get; set; }
        public ICollection<Jogador> Jogadores { get; set; }
    }
}
