using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AS_Crowdzero
{
    public partial class Frm_Crowdzero : Form
    {
        public Frm_Crowdzero()
        {
            InitializeComponent();
        }

        private void criarUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Criar_Utilizador frm_cuapp = new Frm_Criar_Utilizador();
            this.Hide();
            frm_cuapp.Show();
        }



        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void verReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verUtilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Frm_Crowdzero_Load(object sender, EventArgs e)
        {

        }

        private void verUtilizadoresAPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Ver_Utilizadores frm_vua = new Frm_Ver_Utilizadores();
            this.Hide();
            frm_vua.Show();
        }

 
    }
}
