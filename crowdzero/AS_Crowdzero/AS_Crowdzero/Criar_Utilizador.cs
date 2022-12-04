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
    public partial class Frm_Criar_Utilizador : Form
    {
        BaseDados bd = new BaseDados();
        public Frm_Criar_Utilizador()
        {
            InitializeComponent();
        }

        private void Frm_Criar_Utilizador_Load(object sender, EventArgs e)
        {
      
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            bool erro = false;
            errorProvider1.Clear();

            if (txt_Nome.Text == "")
            {
                errorProvider1.SetError(txt_Nome, "Campo de preenchimento obrigatorio");
                erro = true;
            }

            if (txt_Idade.Text == "")
            {
                errorProvider1.SetError(txt_Idade, "Campo de preenchimento obrigatorio");
                erro = true;
            }

            if (cmb_Genero.Text == "")
            {
                errorProvider1.SetError(cmb_Genero, "Campo de preenchimento obrigatorio");
                erro = true;
            }

            if (txt_Telefone.Text == "")
            {
                errorProvider1.SetError(txt_Telefone, "Campo de preenchimento obrigatorio");
                erro = true;
            }

            if (txt_BI.Text == "")
            {
                errorProvider1.SetError(txt_BI, "Campo de preenchimento obrigatorio");
                erro = true;
            }

            if (txt_Email.Text == "")
            {
                errorProvider1.SetError(txt_Email, "Campo de preenchimento obrigatorio");
                erro = true;
            }

            if (txt_Password.Text == "")
            {
                errorProvider1.SetError(txt_Password, "Campo de preenchimento obrigatorio");
                erro = true;
            }

            if (txt_pontos.Text == "")
            {
                errorProvider1.SetError(txt_pontos, "Campo de preenchimento obrigatorio");
                erro = true;
            }

            if (erro)
            {
                DialogResult = DialogResult.None;
            }

            if (!erro)
            {
                string Nome = txt_Nome.Text;
                int Idade = Convert.ToInt32(txt_Idade.Text);
                string Tipo_Func = "Utilizador APP";
                string Genero = cmb_Genero.Text;
                int Telefone = Convert.ToInt32(txt_Telefone.Text);
                int BI = Convert.ToInt32(txt_BI.Text);              
                string Email = txt_Email.Text;
                string Pass = txt_Password.Text;
                string Estado = "Ativo";

                string sql = "INSERT INTO UTILIZADORES ( NOME, TIPO_UTILIZADOR, IDADE, GENERO, TELEFONE, BI, EMAIL, PASSWORD, ESTADO) "
                    + "VALUES ( @NOME, @TIPO_UTILIZADOR, @IDADE, @GENERO, @TELEFONE, @BI, @EMAIL, @PASSWORD, @ESTADO)";

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@Nome", Nome));
                parametros.Add(new SqlParameter("@TIPO_UTILIZADOR", Tipo_Func));
                parametros.Add(new SqlParameter("@IDADE", (int)Idade));
                parametros.Add(new SqlParameter("@GENERO", Genero));
                parametros.Add(new SqlParameter("@TELEFONE", (int)Telefone));
                parametros.Add(new SqlParameter("@BI", (int)BI));
                parametros.Add(new SqlParameter("@EMAIL", Email));
                parametros.Add(new SqlParameter("@PASSWORD", Pass));
                parametros.Add(new SqlParameter("@ESTADO", Estado));
                bd.executa_SQL(sql, parametros);

                //APP

                string n_ut = "Select TOP 1 CONVERT(INT, N_UTILIZADOR) FROM UTILIZADORES ORDER by N_UTILIZADOR DESC";
                DataTable id = bd.devolveconsulta(n_ut);

                int id_ut = int.Parse(id.Rows[0][0].ToString());
                int N_Avatar = 1;
                int Pontos = Convert.ToInt32(txt_pontos.Text);
                string data = DateTime.Now.ToShortDateString();

                string sql1 = "INSERT INTO APP (N_UTILIZADOR, N_AVATAR, DATA_ADMISSAO, RANKING, ESTADO) "
                    + "VALUES ( @N_UTILIZADOR, @N_AVATAR, @DATA_ADMISSAO, @RANKING, @ESTADO)";

                List<SqlParameter> parametros1 = new List<SqlParameter>();
                parametros1.Add(new SqlParameter("@N_UTILIZADOR", id_ut));
                parametros1.Add(new SqlParameter("@N_AVATAR", N_Avatar));
                parametros1.Add(new SqlParameter("@DATA_ADMISSAO", data));
                parametros1.Add(new SqlParameter("@RANKING", Pontos));
                parametros1.Add(new SqlParameter("@ESTADO", Estado));
                bd.executa_SQL(sql1, parametros1);

                MessageBox.Show("Registo introduzido com sucesso", "Registo Formulario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frm_Crowdzero frm_c = new Frm_Crowdzero();
                frm_c.Show();
                this.Close();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Frm_Crowdzero frm_c = new Frm_Crowdzero();
            frm_c.Show();
            this.Close();
        }
    }
}
