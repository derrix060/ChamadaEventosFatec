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
//reader
using MySql.Data.MySqlClient;

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
                MySqlDataReader reader = BancoDados.GetFromDB(sql);
                 

                if (reader.Read())
                {

                    Byte[] senhaTela = Encrypt.Criptografar(inputSenha.Text);

                    Byte[] senhaBanco = (Byte[]) reader["senha"];

                    if (Encrypt.Equals(senhaTela, senhaBanco))
                    {
                        //ok -> Goto inicial
                        alertSenha.Text = "Tudo certo!";

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