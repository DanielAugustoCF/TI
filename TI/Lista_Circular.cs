using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace TI
{
    public class Lista_Circular
    {
        ElementoE anterior, atual;
        public Lista_Circular()
        {
            this.atual = new ElementoE(null);
            this.anterior = this.atual;
            this.atual.prox = this.atual;
        }
        public bool vazia()
        {
            return (this.atual == this.anterior);
        }
        public void inserir(Fila d)
        {
            ElementoE novo = new ElementoE(d);
            this.anterior.prox = novo;
            novo.prox = this.atual;
            if (this.vazia())
                this.atual = novo;
            else
                this.anterior = novo;
        }
        public Fila retirar()
        {
            if (this.vazia()) return null;

            ElementoE aux = this.atual;
            if (aux.d == null)
            {
                aux = aux.prox;
            }
            this.anterior.prox = aux.prox;
            this.atual = aux.prox;
            aux.prox = null;
            if (this.vazia()) this.atual.prox = this.atual;
            return aux.d;
        }
        public Fila localizar(int posBusca)
        {
            int posAux = 0;
            ElementoE aux = this.atual;

            while ((aux != null) && (posAux < posBusca))
            {
                aux = aux.prox;
                posAux++;
            }

            if (aux == null) { return null; }
            else { return aux.d; }
        }

        public void concatenar(Lista_Circular outra)
        {
            if (outra.vazia()) return;

            this.anterior.prox = outra.atual.prox;
            this.anterior = outra.anterior;
            outra = new Lista_Circular();
        }

        public override string ToString()
        {
            if (this.vazia())
                return null;
            StringBuilder auxString = new StringBuilder();
            ElementoE aux = this.atual;
            do
            {
                if (aux.d != null)
                {
                    aux.ToString();
                    auxString.AppendLine(aux.ToString());
                }
                aux = aux.prox;
            } while (aux != this.atual);
            return auxString.ToString();
        }
        public ElementoE ConsultaTopo()
        {
            return atual;
        }
        public ElementoE ConsultaFundo()
        {
            return anterior;
        }
    }
}
