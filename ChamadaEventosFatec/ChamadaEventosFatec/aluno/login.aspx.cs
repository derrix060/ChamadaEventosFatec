using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//DataSet
using System.Data;

//Database
using MySql.Data.MySqlClient;

//MD5
using System.Security.Cryptography;
using System.Text; //UTF-8

namespace ChamadaEventosFatec.aluno
{
    public partial class login : System.Web.UI.Page
    {
        static string sc = "Server=localhost;Database=chamada;uid=visual_studio;pwd=visual;";
        static MySqlConnection conn = new MySqlConnection(sc);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logar(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT matricula, senha FROM aluno WHERE email = '" + inputEmail.Text + "'", conn);

                //executar
                MySqlDataAdapter conversor = new MySqlDataAdapter(cmd);
                MySqlDataReader reader = cmd.ExecuteReader();
                 

                if (reader.Read())
                {
                    // create the MD5CryptoServiceProvider object we will use to encrypt the password
                    MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

                    //create an array of bytes we will use to store the encrypted password
                    Byte[] hashedBytes;

                    //Create a UTF8Encoding object we will use to convert our password string to a byte array
                    UTF8Encoding encoder = new UTF8Encoding();

                   

                    //encrypt the password and store it in the hashedBytes byte array
                    hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(inputSenha.Text));

                    Byte[] senha = (Byte[]) reader["senha"];

                    if (EqualsPassword(hashedBytes, senha))
                    {
                        //ok -> Goto inicial
                        alertSenha.Text = "Tudo certo!";
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
            conn.Close();
        }

        private Boolean EqualsPassword (Byte[] pri, Byte[] sec)
        {
            for (int i=0; i<pri.Length; i++)
            {
                if (pri[i] != sec[i]) return false;
            }
            return true;
        }
    }


}