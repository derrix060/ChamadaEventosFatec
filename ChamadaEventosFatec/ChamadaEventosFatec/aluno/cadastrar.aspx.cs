using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//MD5
using ChamadaEventosFatec.auxiliares;
//Database and Encript
namespace ChamadaEventosFatec.aluno
{
    public partial class cadastrar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CadastrarAluno(object sender, EventArgs e)
        {
           Byte[] hashedBytes = Encrypt.Criptografar(inputSenha.Text);


            string sql = "INSERT INTO aluno VALUES ('"
                + inputMatricula.Text + "','"
                + inputNome.Text + "','"
                + Encrypt.CriptToString(hashedBytes) + "','"
                + inputEmail.Text + "')";

            try
            {
                BancoDados.ExecuteSql(sql);
                Clear();
                alertSuccess.Visible = true;
            }
            catch (Exception exception)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml += "<strong>Ops! </strong> Houve algum problema!<br><br>Message: "
                    + exception.Message + "<br>Erro: " + exception.ToString();
            }
        }

        private void Clear()
        {
            alertDanger.Visible = false;
            alertSuccess.Visible = false;
            inputEmail.Text = "";
            inputMatricula.Text = "";
            inputNome.Text = "";
            inputSenha.Text = "";
        }
    }
}