using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TI
{
    public partial class Form2 : Form
    {
        ListBox list1 = new ListBox();
        public List<Elemento> b1;
        public Lista_Circular B2 = new Lista_Circular();
        public Fila[] K = new Fila[10];
        public int i = 0;
        public List<Elemento> B1
        {
            get { return b1; }
            set { b1 = value; }
        }
        public Form2(Fila[] B)
        {
            InitializeComponent();
            b1 = new List<Elemento>();
            list1 = listBox1;
            for (int i = 0; i < K.Length; i++)
                K[i] = new Fila();
            exibir(B);
        }
        public void exibir(Fila[] B)
        {
            for (int i = 0; i < B.Length; i++)
            {
                for (Elemento j = B[i].ConsultaTopo(); j != null; j = j.prox)
                {                    
                    b1.Add(j);
                    list1.Items.Add(j);
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Elemento n = (Elemento)list1.Items[list1.SelectedIndex];
            Processos p = (Processos)n.d;
            p.Prioridade = comboBox1.SelectedIndex+1;
            MessageBox.Show(p.ToString());
            list1.Items.Clear();
            foreach(Elemento x in b1)
            {
                list1.Items.Add(x);
            }
            Application.DoEvents();
            i++;
        }

        public void Button2_Click(object sender, EventArgs e)
        { 
            this.Hide();
        }
    }
}
