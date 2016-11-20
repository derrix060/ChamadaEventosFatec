using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//MD5
using System.Security.Cryptography;
using System.Text; //UTF-8

namespace ChamadaEventosFatec.auxiliares
{
    public class Encrypt
    {
        static UTF8Encoding encoder = new UTF8Encoding();

        public static Byte[] Criptografar(string campo)
        {
            // create the MD5CryptoServiceProvider object we will use to encrypt the password
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            //create an array of bytes we will use to store the encrypted password
            Byte[] resp;
            
            //encrypt the password and store it in the hashedBytes byte array
            resp = md5Hasher.ComputeHash(encoder.GetBytes(campo));
            
            return resp;
        }

        public static Boolean Equals(Byte[] pri, Byte[] sec)
        {
            for (int i = 0; i < pri.Length; i++)
            {
                if (pri[i] != sec[i]) return false;
            }
            return true;
        }

        public static string CriptToString(Byte[] cript)
        {
            return encoder.GetString(cript);
        }

    }

    
}