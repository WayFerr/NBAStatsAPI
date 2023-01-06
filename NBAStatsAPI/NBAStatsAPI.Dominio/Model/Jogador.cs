using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Dominio.Model
{
    public class Jogador
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal PPG { get; set; }
        [Required]
        public long PontosTotais { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal APG { get; set; }
        [Required]
        public long AssistenciasTotais { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal RPG { get; set; }
        [Required]
        public long RebotesTotais { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal BPG { get; set; }
        [Required]
        public long BlocksTotais { get; set; }
        [Required]
        [Column(TypeName = "decimal(3,1)")]
        public decimal SPG { get; set; }
        [Required]
        public long StealsTotais { get; set; }
        [ForeignKey("PosicaoId")]
        public long PosicaoId { get; set; }
        [ForeignKey("TimeId")]
        public long TimeId { get; set; }
        public Posicao Posicao { get; set; }
        public Time Time { get; set; }
    }
}
