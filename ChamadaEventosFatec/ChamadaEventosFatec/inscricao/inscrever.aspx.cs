using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//DataSet
using System.Data;
//Database and Encript
using ChamadaEventosFatec.auxiliares;

namespace ChamadaEventosFatec.inscricao
{
    public partial class inscrever : System.Web.UI.Page
    {
        string sql;
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

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
            string strFilterPeriodo = "";
            string strFilterDia = "";


            //filter Periodo
            strFilterPeriodo = "periodo='" + dropPeriodo.SelectedValue + "'";

            //filter Dia
            strFilterDia = "dia='" + dropDia.SelectedValue + "'";

            try
            {
                //Refresh Palestra
                DataTable dt = ds.Tables["tbPalestra"];
                DataRow[] dr = dt.Select(strFilterDia + " AND " + strFilterPeriodo);
                dropPalestra.DataSource = dr.CopyToDataTable();
                dropPalestra.DataTextField = "nome";
                dropPalestra.DataBind();

                //Refresh Materia
                dt = ds.Tables["tbMateria"];
                dr = dt.Select(strFilterDia + " AND " + strFilterPeriodo);
                dropMateria.DataSource = dr.CopyToDataTable();
                dropMateria.DataTextField = "nome";
                dropMateria.DataBind();
            }
            catch
            {
                //não possui nenhum eveto para esse dia
                dropPalestra.Items.Clear();
                dropMateria.Items.Clear();
            }

            //Response.Write("<script lang=javasript>$('.selectpicker').selectpicker();</script>");
        }



        private void Carrega_Periodo()
        {
            sql = "SELECT cod FROM periodo ORDER BY ord DESC";
            BancoDados.UpdateDataSet(ds, sql, "tbPeriodo", true);
        }

        private void Carrega_Dia()
        {
            sql = "SELECT dia FROM dia ORDER BY ord DESC";
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
    }
}