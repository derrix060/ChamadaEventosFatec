using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//MD5
using System.Security.Cryptography;
using System.Text; //UTF-8
//CommandType
using System.Data;
//DB
using MySql.Data.MySqlClient;

namespace ChamadaEventosFatec.aluno
{
    public partial class cadastrar : System.Web.UI.Page
    {
        static string sc = "Server=localhost;Database=chamada;Uid=visual_studio;Pwd=visual;";
        static MySqlConnection conn = new MySqlConnection(sc);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CadastrarAluno(object sender, EventArgs e)
        {
            // create the MD5CryptoServiceProvider object we will use to encrypt the password
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            //create an array of bytes we will use to store the encrypted password
            Byte[] hashedBytes;

            //Create a UTF8Encoding object we will use to convert our password string to a byte array
            UTF8Encoding encoder = new UTF8Encoding();

            //encrypt the password and store it in the hashedBytes byte array
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(inputSenha.Text));

            //matr nome senha email
            MySqlCommand cmd = new MySqlCommand("INSERT INTO aluno VALUES (@matricula, @nome, @passwd, @email)", conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@matricula", inputMatricula.Text);
            cmd.Parameters.AddWithValue("@nome", inputNome.Text);
            cmd.Parameters.AddWithValue("@passwd", hashedBytes);
            cmd.Parameters.AddWithValue("@email", inputEmail.Text);
            /*
            sql = "INSERT INTO aluno VALUES ('"
                + inputMatricula.Text + "','"
                + inputNome.Text + "','"
                + hashedBytes + "','"
                + inputEmail.Text + "'";
            */

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Clear();
                alertSuccess.Visible = true;
            }
            catch (MySqlException mysqlException)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema para salvar no banco de dados!<br><br>Message: "
                    + mysqlException.Message;
            }
            catch (Exception exception)
            {
                alertDanger.Visible = true;
                alertDanger.InnerHtml = "<strong>Ops! </strong> Houve algum problema para salvar no banco de dados!<br><br>Message: "
                    + exception.Message + "<br>Erro: " + exception.ToString();
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
            inputSenha.Text = "";
        }
    }
}