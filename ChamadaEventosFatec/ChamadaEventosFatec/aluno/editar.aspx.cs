using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//MD5
using System.Security.Cryptography;
using System.Text; //UTF-8
//DB
using MySql.Data.MySqlClient;

namespace ChamadaEventosFatec.aluno
{
    public partial class editar : System.Web.UI.Page
    {
        static string sc = "Server=localhost;Database=chamada;Uid=visual_studio;Pwd=visual;";
        static MySqlConnection conn = new MySqlConnection(sc);
        static MySqlCommand cmd = new MySqlCommand();

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
                // create the MD5CryptoServiceProvider object we will use to encrypt the password
                MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

                //create an array of bytes we will use to store the encrypted password
                Byte[] hashedBytes;

                //Create a UTF8Encoding object we will use to convert our password string to a byte array
                UTF8Encoding encoder = new UTF8Encoding();

                //encrypt the password and store it in the hashedBytes byte array
                hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(inputSenhaNova1.Text));


                sql += "senha='" + encoder.GetString(hashedBytes) + "', ";
            }

            //ajuste comando
            sql = sql.Substring(0, sql.Length - 2) + " WHERE matricula='" + inputMatricula.Text + "'";


            try
            {
                conn.Open();
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Clear();

                alertSuccess.InnerText = "<strong>Parabéns! </strong> Seus dados foram alterados com sucesso!";
            }
            catch (MySqlException exe)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema com o banco de dados!<br><br>Message: "
                    + exe.Message;
            }
            catch (Exception exe)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema!<br><br>Message: "
                    + exe.Message + "<br>Erro: " + exe.ToString();
            }

            conn.Close();
        }
        protected void ExcluirAluno(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand("DELETE FROM aluno WHERE matricula = @matricula", conn);
                cmd.Parameters.AddWithValue("@matricula", inputMatricula.Text);

                cmd.ExecuteNonQuery();
                Clear();

                alertSuccess.InnerText = "<strong>Parabéns! </strong> Seus dados foram excluidos com sucesso!";
            }
            catch (MySqlException exe)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema com o banco de dados!<br><br>Message: "
                    + exe.Message;
            }
            catch (Exception exe)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema!<br><br>Message: "
                    + exe.Message + "<br>Erro: " + exe.ToString();
            }

            conn.Close();
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