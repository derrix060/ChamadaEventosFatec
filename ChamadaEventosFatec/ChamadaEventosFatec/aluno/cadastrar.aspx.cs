using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//MD5
using ChamadaEventosFatec.auxiliares;
//Database, Encript and Email
using ChamadaEventosFatec.auxiliares;


namespace ChamadaEventosFatec.aluno
{
    public partial class cadastrar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CadastrarAluno(object sender, EventArgs e)
        {
           //Byte[] hashedBytes = Encrypt.Criptografar(inputSenha.Text);


            string sql = "INSERT INTO aluno VALUES ('"
                + inputMatricula.Text + "','"
                + inputNome.Text + "',"
                + "UNHEX(MD5('" + inputSenha.Text + "')),'"
                + inputEmail.Text + "')";

            try
            {
                BancoDados.ExecuteSql(sql);
                Clear();
                alertSuccess.Visible = true;

                //envia email

            }
            catch (Exception exception)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema!<br><br>Message: "
                    + exception.Message + "<br>Erro: " + exception.ToString();
            }
        }

        private void criarEmail()
        {
            //email To
            List<string> email = new List<string>();
            email.Add(inputEmail.Text);

            //assunto
            string assunto = "Cadastro realizado com sucesso!";

            //corpo
            string corpo = "Parabéns " + inputNome.Text + "! Seu cadastro no sistema foi realizado com sucesso!";

            //enviar
             alertDanger.Visible = true;
            alertDanger.InnerHtml = "<strong>Ops!</strong > Houve algum problema!<br><br>"
                + Email.EnviarEmail(email, corpo, assunto);



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


        protected void Voltar(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }


}