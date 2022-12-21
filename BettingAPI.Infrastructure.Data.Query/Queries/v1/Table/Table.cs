using Newtonsoft.Json;
using System.Collections.Generic;

namespace BettingAPI.Infrastructure.Data.Query.Queries.v1.Table
{
    public class TableRequest
    {
        public int Posicao { get; set; }
        public int Pontos { get; set; }
        public Time Time { get; set; }
        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int Gols_pro { get; set; }
        public int Gols_contra { get; set; }
        public int Saldo_gols { get; set; }
        public int Aproveitamento { get; set; }
        public int Variacao_posicao { get; set; }
        public List<string> Ultimos_jogos { get; set; }
    }

    public class Time
    {
        public int Time_id { get; set; }
        public string Nome_popular { get; set; }
        public string Sigla { get; set; }
        public string Escudo { get; set; }
    }
}

