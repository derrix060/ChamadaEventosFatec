﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//DataSet
using System.Data;
//Database
using MySql.Data.MySqlClient;

namespace ChamadaEventosFatec.auxiliares
{
    public class BancoDados
    {
        private static string           sc      =   "Server=tcp:serverchamadaeventosfatec.database.windows.net,1433;Initial Catalog=chamada;Persist Security Info=False;User ID=mario@serverchamadaeventosfatec;Password=m@rIo564231897;"; //old -> "Server=localhost;Database=chamada;uid=visual_studio;pwd=visual;";
        private static MySqlConnection  conn    =   new MySqlConnection(sc);
        private static MySqlCommand     cmd     =   new MySqlCommand();

        public static void ExecuteSql (string sql)
        {
            cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException exe)
            {
                conn.Close();
                throw new Exception("MySqlException: " + exe.Message);
            }
            catch (Exception exe)
            {
                conn.Close();
                throw new Exception(exe.Message);
            }
        }

        public static DataTable GetFromDB (string sql)
        {
            DataSet ds = new DataSet();
            UpdateDataSet(ds, sql, "tbl", true);
            return ds.Tables["tbl"];
        }

        public static void UpdateDataSet (DataSet ds, string sql, string tbName, bool removeOld)
        {
            cmd = new MySqlCommand(sql, conn);

            try
            {
                if (removeOld)
                    ds.Tables[tbName].Clear();
            }
            catch { }

            try
            {
                cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter conversor = new MySqlDataAdapter();
                conversor.SelectCommand = cmd;
                conversor.Fill(ds, tbName);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

    }
}