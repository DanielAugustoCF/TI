using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace TI
{
    public class Processos : IDados
    {
        public int PID { get; set; }
        public string Nome { get; set; }
        public int Prioridade { get; set; }
        public int Ciclos { get; set; }

        public Processos(int PID, string Nome, int Prioridade, int Ciclos)
        {
            this.PID = PID;
            this.Nome = Nome;
            this.Prioridade = Prioridade;
            this.Ciclos = Ciclos;
        }
        public int Processar()
        {
            Ciclos -= 5;
            if (Ciclos < 0)
                Ciclos = 0;
            return Ciclos;
        }
        public void dimPrioridade()
        {
            Prioridade++;
        }
        public override string ToString()
        {
            return ":" + this.PID.ToString() + " - " + this.Nome.ToString() + " - " + this.Prioridade.ToString() + " - " + this.Ciclos.ToString();
        }
    }
}
