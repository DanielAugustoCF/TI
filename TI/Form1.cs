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
    public partial class Form1 : Form
    {
        static IDados novo;
        static Inicializar i = new Inicializar();
        Fila[] vetProcessos = new Fila[10];
        static ListBox list1;
        Form2 f2;
        static Thread Num1 = new Thread(CarregarProcessos);
        static Thread Num2;
        static Thread Num3;
        int h = 0;

        public Form1()
        {
            InitializeComponent();
            list1 = listBox1;
            Num1.Start();
            button2.Enabled = false;
            list1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Num2 = new Thread(new ThreadStart(Executar1));
            Num3 = new Thread(new ThreadStart(Executar2));
            Num2.Start();
            Num3.Start();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            h++;
        }
        public static void CarregarProcessos()
        {
            if (File.Exists("1542228_AED_TI_SO_dados.txt"))
            {
                string linha;
                string[] info;
                StreamReader entrada = new StreamReader("1542228_AED_TI_SO_dados.txt");
                while (!entrada.EndOfStream)
                {

                    linha = entrada.ReadLine();
                    info = linha.Split(';');
                    novo = new Processos(int.Parse(info[0]), info[1], int.Parse(info[2]), int.Parse(info[3]));
                    switch (int.Parse(info[2]))
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10: i.B[int.Parse(info[2]) - 1].inserir(novo); break;
                        default:
                            Console.WriteLine("ERRO AO LER O ARQUIVO");
                            break;
                    }
                    if(int.Parse(info[2])==1)
                    {
                        Processos Pro = (Processos)(novo);
                        if (list1.InvokeRequired)
                            list1.BeginInvoke((MethodInvoker)delegate {
                                list1.Items.Add(Pro.ToString());
                            });
                        Application.DoEvents();
                    }
                }
                entrada.Close();
                for (int o = 0; o < i.B.Length; o++)
                {
                    i.A1.inserir(i.B[o]);
                }
            }
        }
        public void Executar1()
        {
            i.Executar1(label2, label4, label5, list1);
        }
        public void Executar2()
        {
            i.Executar2(label2, label4, label5, list1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //
            if(Num2.IsAlive)
                Num2.Suspend();
            if (Num3.IsAlive)
                Num3.Suspend();
            i.Salvar(label7);
            if (Num2.IsAlive)
                Num2.Resume();
            if (Num3.IsAlive)
                Num3.Resume();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            f2 = new Form2(i.B);
            f2.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (Num2 != null)
                Num2.Abort();

            if (Num3 != null)
                Num3.Abort();

            Num1.Abort();
            Thread.Sleep(250);
            Environment.Exit(1);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (f2 != null)
            {
                for (int l = 0; l < i.B.Length; l++)
                {
                    i.B[l] = new Fila();
                }

                foreach (Elemento x in f2.b1)
                {
                    Processos p = (Processos)x.d;
                    int aux = p.PID;
                    if (aux != p.PID)
                    {
                        switch (p.Prioridade)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10: i.B[p.Prioridade - 1].inserir(novo); break;
                            default:
                                Console.WriteLine("ERRO AO LER O ARQUIVO");
                                break;
                        }
                        if (p.Prioridade == 1)
                        {
                            Processos Pro = (Processos)(novo);
                            if (list1.InvokeRequired)
                                list1.BeginInvoke((MethodInvoker)delegate {
                                    list1.Items.Add(Pro.ToString());
                                });
                            Application.DoEvents();
                        }
                        aux = p.PID;
                    }
                }
                for (int o = 0; o < i.B.Length; o++)
                {
                    f2.B2.inserir(i.B[o]);
                }
                i.A1 = f2.B2;
            }
            Thread.Sleep(1000);
        }
    }
}
