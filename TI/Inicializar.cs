using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace TI
{
    public class Inicializar
    {
        static object locker = new object();
        public Lista_Circular A1;
        Fila Extra = new Fila(), F;
        public Fila[] B;
        public string nomeArquivo = "1542228_AED_TI_SO_dados.txt";
        Label l3, l4;

        public Inicializar()
        {
            B = new Fila[10];
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = new Fila();
            }
            A1 = new Lista_Circular();
            Extra = new Fila();
        }

        public void Salvar(Label l)
        {
            Processos p = (Processos)F.retirar();
            if(p!=null)
                l.Text = p.ToString();
        }

        public void Executar1(Label l1, Label l2, Label l5,ListBox l)
        {
            Monitor.Enter(locker);
            l3 = l1;
            l4 = l2;
            int k = 0;
            for (int i = 0; i < this.B.Length/2; i++)
            {
                if (l5.InvokeRequired)
                    l5.BeginInvoke((MethodInvoker)delegate { l5.Text = "Lista " + (i+1); });
                if (A1.ConsultaTopo()!=null)
                    F = (Fila)(A1.retirar());
                else
                {
                    F = (Fila)(A1.retirar());
                    A1.inserir(F);
                    F = (Fila)(A1.retirar());
                }
                Processos P;
                while (!F.vazia())
                {
                    P = (Processos)(F.retirar());
                    if (P.Processar() > 0)
                    {
                        if (i != B.Length/2 - 1)
                            P.dimPrioridade();
                        if (i == 0)
                            A1.ConsultaTopo().prox.d.inserir(P);
                        else if (i < B.Length/2 - 1)
                            A1.ConsultaTopo().d.inserir(P);
                        else
                            F.inserir(P);
                        if (l3.InvokeRequired)
                            l3.BeginInvoke((MethodInvoker)delegate { l3.Text = "Processo: " + P.Nome + " - PRIORIDADE DIMINUÍDA."; });
                    }
                    else
                    {
                        if (l4.InvokeRequired)
                            l4.BeginInvoke((MethodInvoker)delegate { l4.Text = " Processo: " + P.Nome + " - TERMINADO."; });
                    }
                    if (F!= null)
                    {
                        Elemento x = F.ConsultaTopo();
                        if (l.InvokeRequired)
                            l.BeginInvoke((MethodInvoker)delegate { l.Items.Clear(); });
                        
                        while(x!=null)
                        {
                            Processos pro = (Processos)x.d;
                            if (l.InvokeRequired)
                                l.BeginInvoke((MethodInvoker)delegate { l.Items.Add(pro.ToString()); });
                            x = x.prox;
                        }
                    }
                    Application.DoEvents();
                    Thread.Sleep(200);
                }
                k++;
                if (F.vazia())
                {
                    if (l4.InvokeRequired)
                        l4.BeginInvoke((MethodInvoker)delegate { l4.Text = "FIM - " + k + " filas de processos concluídas."; });
                }
                Thread.Sleep(2000);
            }
            Monitor.Exit(locker);
        }
        public void Executar2(Label l1, Label l2, Label l5, ListBox l)
        {
            Monitor.Enter(locker);
            l3 = l1;
            l4 = l2;
            int k = 5;
            for (int i = B.Length/2; i < this.B.Length; i++)
            {
                if (l5.InvokeRequired)
                    l5.BeginInvoke((MethodInvoker)delegate { l5.Text = "Lista "+(i+1); });
                if (i < B.Length - 1)
                    F = (Fila)(A1.retirar());
                else
                {
                    F = (Fila)(A1.retirar());
                    A1.inserir(F);
                    F = (Fila)(A1.retirar());
                }
                Processos P;
                while (!F.vazia())
                {
                    P = (Processos)(F.retirar());
                    if (P.Processar() > 0)
                    {
                        if (i != B.Length - 1)
                            P.dimPrioridade();
                        if (i == 0)
                            A1.ConsultaTopo().prox.d.inserir(P);
                        if (i < B.Length - 1)
                            A1.ConsultaTopo().d.inserir(P);
                        else
                            F.inserir(P);
                        if (l3.InvokeRequired)
                            l3.BeginInvoke((MethodInvoker)delegate { l3.Text = "Processo: " + P.Nome + " - PRIORIDADE DIMINUÍDA."; });
                    }
                    else
                    {
                        if (l4.InvokeRequired)
                            l4.BeginInvoke((MethodInvoker)delegate { l4.Text = " Processo: " + P.Nome + " - TERMINADO."; });
                    }
                    if (F != null)
                    {
                        Elemento x = F.ConsultaTopo();
                        if (l.InvokeRequired)
                            l.BeginInvoke((MethodInvoker)delegate { l.Items.Clear(); });

                        while (x != null)
                        {
                            Processos pro = (Processos)x.d;
                            if (l.InvokeRequired)
                                l.BeginInvoke((MethodInvoker)delegate { l.Items.Add(pro.ToString()); });
                            x = x.prox;
                        }
                    }
                    Application.DoEvents();
                    Thread.Sleep(200);
                }
                k++;
                if (F.vazia())
                {
                    if (l4.InvokeRequired)
                        l4.BeginInvoke((MethodInvoker)delegate { l4.Text = "FIM - " + k + " filas de processos concluídas."; });
                }
                Thread.Sleep(2000);
            }
            Monitor.Exit(locker);
        }
    }
}
