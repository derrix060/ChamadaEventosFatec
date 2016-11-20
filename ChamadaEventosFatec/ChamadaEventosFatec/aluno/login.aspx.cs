using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//DataSet
using System.Data;
//cript and DB
using ChamadaEventosFatec.auxiliares;
//DataSet
using System.Data;

namespace ChamadaEventosFatec.aluno
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logar(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT matricula, senha FROM aluno WHERE email = '" + inputEmail.Text + "'";

                //executar
                DataTable dt = BancoDados.GetFromDB(sql);
                
                if (dt.Rows.Count == 1)
                {

                    Byte[] senhaTela = Encrypt.Criptografar(inputSenha.Text);

                    Byte[] senhaBanco = (Byte[]) dt.Rows[0].ItemArray[1];

                    if (Encrypt.Equals(senhaTela, senhaBanco))
                    {
                        Session["matriculaAluno"] = dt.Rows[0].ItemArray[0].ToString();

                        Response.Redirect("/aluno/inicio.aspx");
                    }
                    else
                    {
                        alertSenha.Text = "Senha incorreta!";
                    }

                }
                else
                {
                    alertSenha.Text = "Email não encontrado!";
                }
            }
            catch (Exception exe)
            {
                alertSenha.Text = "Ocorreu o seguinte erro: " + exe.Message;
            }

            alertSenha.Visible = true;
        }
    }


}