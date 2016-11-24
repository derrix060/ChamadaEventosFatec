﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

//DataSet
using System.Data;
//Database and Encript
using ChamadaEventosFatec.auxiliares;

namespace ChamadaEventosFatec.inscricao
{
    public partial class inscrever : System.Web.UI.Page
    {
        string sql;
        static DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["matriculaAluno"] == null)
                Response.Redirect("/aluno/login.aspx");

            if (!Page.IsPostBack)
            {
                //carrega tabelas no Dataset
                Carrega_Periodo();
                Carrega_Dia();
                Carrega_Palestra();
                Carrega_Materia();

                //load periodo
                dropPeriodo.DataSource = ds.Tables["tbPeriodo"];
                dropPeriodo.DataTextField = "cod";
                dropPeriodo.DataBind();

                //load dias
                dropDia.DataSource = ds.Tables["tbDia"];
                dropDia.DataTextField = "dia";
                dropDia.DataBind();
            }

        }

        protected void Refresh_Palestra_Materia(object sender, EventArgs e)
        {
            //filter Periodo
            string strFilterPeriodo = "periodo='" + dropPeriodo.SelectedValue + "'";

            //filter Dia
            string strFilterDia = "dia='" + dropDia.SelectedValue + "'";

            try
            {
                //Refresh Palestra
                DataTable dt = ds.Tables["tbPalestra"];
                DataRow[] dr = dt.Select(strFilterDia + " AND " + strFilterPeriodo);
                listPalestra.DataSource = dr.CopyToDataTable();
                listPalestra.DataTextField = "nome";
                listPalestra.DataValueField = "codigo";
                listPalestra.DataBind();

                //Refresh Materia
                dt = ds.Tables["tbMateria"];
                dr = dt.Select(strFilterDia + " AND " + strFilterPeriodo);
                listMateria.DataSource = dr.CopyToDataTable();
                listMateria.DataTextField = "nome";
                listMateria.DataValueField = "id";
                listMateria.DataBind();
            }
            catch
            {
                //não possui nenhum eveto para esse dia
                listPalestra.Items.Clear();
                listMateria.Items.Clear();
            }

        }
        
        private void Carrega_Periodo()
        {
            sql = "SELECT cod FROM periodo ORDER BY ord";
            BancoDados.UpdateDataSet(ds, sql, "tbPeriodo", true);
        }

        private void Carrega_Dia()
        {
            sql = "SELECT dia FROM dia ORDER BY ord";
            BancoDados.UpdateDataSet(ds, sql, "tbDia", true);
        }

        private void Carrega_Palestra()
        {
            sql = "SELECT * FROM palestra";
            BancoDados.UpdateDataSet(ds, sql, "tbPalestra", true);
        }

        private void Carrega_Materia()
        {
            sql = "SELECT * FROM materia";
            BancoDados.UpdateDataSet(ds, sql, "tbMateria", true);
        }

        protected void Inscrever(object sender, EventArgs e)
        {
            alertDanger.Visible = false;
            alertSuccess.Visible = true;

            List<string> materias = getMaterias();
            List<string> palestras = getPalestras();

            //inscrever nas palestras
            foreach (string palestra in palestras)
            {
                sql = "INSERT INTO inscricao (aluno, palestra) VALUES ('" +
                    Session["matriculaAluno"] + "','" +
                    palestra + "')";

                insertInscricaoDB(sql);
            }

            //inscrever nas materias
            foreach (string materia in materias)
            {
                sql = "INSERT INTO incricao_materia (aluno, materia) VALUES ('" +
                    Session["matriculaAluno"] + "','" +
                    materia + "')";

                insertInscricaoDB(sql);
            }

            alertSuccess.Visible = true;
        }

        private void insertInscricaoDB(string sql)
        {
            try
            {
                BancoDados.ExecuteSql(sql);
            }
            catch {}
        }
        private List<string> getMaterias()
        {
            List<string> resp = new List<string>();
            foreach (ListItem materia in listMateria.Items)
            {
                if (materia.Selected)
                    resp.Add(materia.Value);
            }

            return resp;
        }

        private List<string> getPalestras()
        {
            List<string> resp = new List<string>();

            foreach(ListItem palestra in listPalestra.Items)
            {
                if (palestra.Selected)
                    resp.Add(palestra.Value);
            }

            return resp;
        }

        protected void Voltar (object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        

    }
}