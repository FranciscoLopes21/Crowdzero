using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace AS_Crowdzero
{
    public partial class Frm_Ver_Utilizadores : Form
    {
        BaseDados bd = new BaseDados();
        public Frm_Ver_Utilizadores()
        {
            InitializeComponent();
        }

        private void Frm_Ver_Utilizadores_Load(object sender, EventArgs e)
        {
            label4.Visible = true;
            txt_N_Avatar.Visible = true;
            string sql = "SELECT * FROM UTILIZADORES AS u INNER JOIN APP AS a ON u.N_UTILIZADOR=a.N_UTILIZADOR Order by u.N_UTILIZADOR ASC;";
            dgv_Listar.DataSource = bd.devolveconsulta(sql);
            dgv_Listar.Refresh();
            btn_editar.Visible = false;
        }

        public void pesquisar()
        {
            string sql = "SELECT * FROM UTILIZADORES AS u INNER JOIN APP AS a ON u.N_UTILIZADOR=a.N_UTILIZADOR";
            string sql1 = "Select *  FROM APP WHERE N_APP>0";
            string sql2 = "SELECT ESTADO FROM UTILIZADORES AS u INNER JOIN APP AS a ON u.N_UTILIZADOR=a.N_UTILIZADOR";

            if (txt_Nome.Text != "")
            {
                sql += " and NOME like '%" + txt_Nome.Text + "%'";
            }

            if (txt_Idade.Text != "")
            {
                sql += " and IDADE like '%" + txt_Idade.Text + "%'";
            }

            if (cmb_Genero.Text != "")
            {
                sql += " and GENERO like '%" + cmb_Genero.Text + "%'";
            }

            if (txt_Telefone.Text != "")
            {
                sql += " and TELEFONE like '%" + txt_Telefone.Text + "%'";
            }

            if (txt_BI.Text != "")
            {
                sql += " and BI like '%" + txt_BI.Text + "%'";
            }

            if (txt_Email.Text != "")
            {
                sql += " and EMAIL like '%" + txt_Email.Text + "%'";
            }

            if (txt_Telefone.Text != "")
            {
                sql += " and PASSWORD like '%" + txt_Telefone.Text + "%'";
            }

            if (cmb_Estado.Text != "")
            {
                sql2 += " and ESTADO like '%" + cmb_Estado.Text + "%'";
            }

            if (txt_pontos.Text != "")
            {
                sql1 += " and RANKING like '%" + txt_pontos.Text + "%'";
            }

            if (txt_N_Avatar.Text!="")
            {
                sql += " and N_AVATAR like '%" + txt_N_Avatar.Text + "%'";
            } 

            dgv_Listar.DataSource = bd.devolveconsulta(sql);
            dgv_Listar.Refresh();
            btn_editar.Visible = false;
        }

        private void txt_Nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_editar_Click(object sender, EventArgs e)
        {

            string Nome = txt_Nome.Text;
            int Idade = Convert.ToInt32(txt_Idade.Text);
            string Genero = cmb_Genero.Text;
            int Telefone = Convert.ToInt32(txt_Telefone.Text);
            int BI = Convert.ToInt32(txt_BI.Text);
            string Email = txt_Email.Text;
            string Pass = txt_Password.Text;
            string Estado = cmb_Estado.Text;
            int Ranking = Convert.ToInt32(txt_pontos.Text);

            string up = "UPDATE UTILIZADORES SET NOME=@NOME, IDADE=@IDADE, GENERO=@GENERO, TELEFONE=@TELEFONE, BI=@BI, EMAIL=@EMAIL, PASSWORD=@PASSWORD, ESTADO=@ESTADO where N_UTILIZADOR= " + dgv_Listar.SelectedRows[0].Cells[0].Value;

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nome", Nome));
            parametros.Add(new SqlParameter("@IDADE", (int)Idade));
            parametros.Add(new SqlParameter("@GENERO", Genero));
            parametros.Add(new SqlParameter("@TELEFONE", (int)Telefone));
            parametros.Add(new SqlParameter("@BI", (int)BI));
            parametros.Add(new SqlParameter("@EMAIL", Email));
            parametros.Add(new SqlParameter("@PASSWORD", Pass));
            parametros.Add(new SqlParameter("@ESTADO", Estado));
            bd.executa_SQL(up, parametros);

            //APP
            string up_APP = "UPDATE APP SET RANKING=@RANKING, ESTADO=@ESTADO where N_UTILIZADOR =" + dgv_Listar.SelectedRows[0].Cells[0].Value;

            List<SqlParameter> parametros1 = new List<SqlParameter>();
            parametros1.Add(new SqlParameter("@RANKING", (int)Ranking));
            parametros1.Add(new SqlParameter("@ESTADO", Estado));
            bd.executa_SQL(up_APP, parametros1);
            dgv_Listar.Visible = true;
            string sql = "SELECT * FROM UTILIZADORES AS u INNER JOIN APP AS a ON u.N_UTILIZADOR=a.N_UTILIZADOR Order by u.N_UTILIZADOR ASC;";
            dgv_Listar.DataSource = bd.devolveconsulta(sql);
            dgv_Listar.Refresh();
            btn_editar.Visible = false;
            txt_Nome.Text = "";
            txt_Idade.Text = "";
            cmb_Genero.SelectedIndex = -1;
            txt_Telefone.Text = "";
            txt_BI.Text = "";
            txt_Email.Text = "";
            txt_Password.Text = "";
            txt_N_Avatar.Text = "";
            cmb_Estado.SelectedIndex = -1;
            txt_pontos.Text = "";
        }

        private void dgv_Listar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //label4.Visible = false;
            txt_N_Avatar.ReadOnly = true;

            string nome = dgv_Listar.SelectedRows[0].Cells[1].Value.ToString();
            int Idade = int.Parse(dgv_Listar.SelectedRows[0].Cells[3].Value.ToString());
            string genero = dgv_Listar.SelectedRows[0].Cells[4].Value.ToString();
            int telefone = int.Parse(dgv_Listar.SelectedRows[0].Cells[5].Value.ToString());
            int BI = int.Parse(dgv_Listar.SelectedRows[0].Cells[6].Value.ToString());
            string email = dgv_Listar.SelectedRows[0].Cells[7].Value.ToString();
            string pass = dgv_Listar.SelectedRows[0].Cells[8].Value.ToString();
            string estado = dgv_Listar.SelectedRows[0].Cells[9].Value.ToString();
            int n_avatar = int.Parse(dgv_Listar.SelectedRows[0].Cells[12].Value.ToString());
            int ranking = int.Parse(dgv_Listar.SelectedRows[0].Cells[14].Value.ToString());

            txt_Nome.Text = nome;
            txt_Idade.Text = Convert.ToString(Idade);
            cmb_Genero.Text = genero;
            txt_Telefone.Text = Convert.ToString(telefone);
            txt_BI.Text = Convert.ToString(BI);
            txt_Email.Text = email;
            txt_Password.Text = pass;
            cmb_Estado.Text = estado;
            txt_pontos.Text = Convert.ToString(ranking);
            txt_N_Avatar.Text = Convert.ToString(n_avatar);
            btn_editar.Visible = true;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bd.executa_SQL("Delete From APP WHERE N_UTILIZADOR=" + dgv_Listar.SelectedRows[0].Cells[0].Value);
            bd.executa_SQL("Delete From UTILIZADORES WHERE N_UTILIZADOR=" + dgv_Listar.SelectedRows[0].Cells[0].Value);


            string sql = "SELECT * FROM UTILIZADORES AS u INNER JOIN APP AS a ON u.N_UTILIZADOR=a.N_UTILIZADOR Order by u.N_UTILIZADOR ASC;";
            dgv_Listar.DataSource = bd.devolveconsulta(sql);
            dgv_Listar.Refresh();
            btn_editar.Visible = false;
            txt_Nome.Text = "";
            txt_Idade.Text = "";
            cmb_Genero.SelectedIndex = -1;
            txt_Telefone.Text = "";
            txt_BI.Text = "";
            txt_Email.Text = "";
            txt_Password.Text = "";
            cmb_Estado.SelectedIndex = -1;
            txt_pontos.Text = "";
            txt_N_Avatar.Text = "";
            btn_editar.Visible = true;
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            pesquisar();
            //label4.Visible = false;
            //txt_N_Avatar.Visible = false;
            txt_N_Avatar.ReadOnly = false;
            cmb_Estado.Visible = true;
            btn_editar.Visible = false;
            txt_Nome.Text = "";
            txt_Idade.Text = "";
            cmb_Genero.SelectedIndex = -1;
            txt_Telefone.Text = "";
            txt_BI.Text = "";
            txt_Email.Text = "";
            txt_Password.Text = "";
            cmb_Estado.SelectedIndex = -1;
            txt_pontos.Text = "";
            txt_N_Avatar.Text = "";
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Frm_Crowdzero frm_c = new Frm_Crowdzero();
            frm_c.Show();
            this.Close();
        }
    }
}
