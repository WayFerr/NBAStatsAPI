using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAStatsAPI.Dominio.ViewModel
{
    public class JogadorViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal PPG { get; set; }
        public long PontosTotais { get; set; }
        public decimal APG { get; set; }
        public long AssistenciasTotais { get; set; }
        public decimal RPG { get; set; }
        public long RebotesTotais { get; set; }
        public decimal BPG { get; set; }
        public long BlocksTotais { get; set; }
        public decimal SPG { get; set; }
        public long StealsTotais { get; set; }
        public long PosicaoId { get; set; }
        public long TimeId { get; set; }
    }
}
