using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace TI
{
    public interface IDados
    {
        string ToString();
    }
    public class Elemento
    {
        public IDados d;
        public Elemento prox;
        public Elemento(IDados d)
        {
            this.d = d;
            this.prox = null;
        }
        public override string ToString()
        {
            return d.ToString();
        }
    }
    public class ElementoE
    {
        public Fila d;
        public ElementoE prox;
        public ElementoE(Fila d)
        {
            this.d = d;
            this.prox = null;
        }
        public override string ToString()
        {
            return d.ToString();
        }
    }
}
