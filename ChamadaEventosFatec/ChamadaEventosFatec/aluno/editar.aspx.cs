using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//DB and Cript
using ChamadaEventosFatec.auxiliares;

namespace ChamadaEventosFatec.aluno
{
    public partial class editar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EditarAluno(object sender, EventArgs e)
        {
            string sql = "UPDATE aluno SET ";

            //email
            if (inputEmail.Text != "")
            {
                sql += "email='" + inputEmail.Text + "', ";
            }

            //nome
            if (inputNome.Text != "")
            {
                sql += "nome='" + inputNome.Text + "', ";
            }

            //senha
            if (inputSenhaNova1.Text != "")
            {
               
                Byte[] novaSenha = Encrypt.Criptografar(inputSenhaNova1.Text);
                
                sql += "senha='" + Encrypt.CriptToString(novaSenha) + "', ";
            }

            //ajuste comando
            sql = sql.Substring(0, sql.Length - 2) + " WHERE matricula='" + inputMatricula.Text + "'";
            
            try
            {
                BancoDados.ExecuteSql(sql);
                Clear();

                alertSuccess.InnerText = "<strong>Parabéns! </strong> Seus dados foram alterados com sucesso!";
            }
            catch (Exception exe)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema!<br><br>Message: " + exe.Message;
            }
        }
        protected void ExcluirAluno(object sender, EventArgs e)
        {
            try
            {
                string sql = "DELETE FROM aluno WHERE matricula = '" + inputMatricula.Text + "'";
                BancoDados.ExecuteSql(sql);
                Clear();

                alertSuccess.InnerText = "<strong>Parabéns! </strong> Seus dados foram excluidos com sucesso!";
            }
            catch (Exception exe)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema!<br><br>Message: " + exe.Message;
            }
        }

        private void Clear()
        {
            alertDanger.Visible = false;
            alertSuccess.Visible = false;
            inputEmail.Text = "";
            inputMatricula.Text = "";
            inputNome.Text = "";
            inputSenhaAntiga.Text = "";
            inputSenhaNova1.Text = "";
            inputSenhaNova2.Text = "";
        }
    }
}