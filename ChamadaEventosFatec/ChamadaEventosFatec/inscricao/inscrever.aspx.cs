using System;
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
                Carrega_Aluno();

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

        private void Carrega_Aluno()
        {
            sql = "SELECT * FROM aluno";
            BancoDados.UpdateDataSet(ds, sql, "tbAluno", true);
        }

        protected void Inscrever(object sender, EventArgs e)
        {
            alertDanger.Visible = false;
            alertSuccess.Visible = true;

            List<string> materias = getMateriasValues();
            List<string> palestras = getPalestrasValues();

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

            //enviar email
            criarEmail();

            alertSuccess.Visible = true;
        }

        private void criarEmail()
        {
            //email To
            List<string> email = new List<string>();
            email.Add(ds.Tables["tbAluno"].Rows[0]["email"].ToString());

            //assunto
            string assunto = "Parabens! Inscricao realizada com sucesso!";

            //corpo
            string corpo = "Sua inscrição foi realizada com sucesso para as seguintes palestras: ";
            corpo += "<br><br>";

            //palestras e materias
            List<string> materias = getMateriasText();
            List<string> palestras = getPalestrasText();

            //alimentar palestras
            foreach (string palestra in palestras)
            {
                corpo += palestra + ", ";
            }
            corpo.Remove(corpo.Length -2);

            //alimentar materias
            corpo += "<br><br>E para as seguintes materias: <br><br>";
            foreach (string materia in materias)
            {
                corpo += materia + ", ";
            }
            corpo.Remove(corpo.Length - 2);


            string resp = Email.EnviarEmail(email, corpo, assunto);

        }

        private void insertInscricaoDB(string sql)
        {
            try
            {
                BancoDados.ExecuteSql(sql);
            }
            catch {}
        }

        private List<string> getMateriasText()
        {
            List<string> resp = new List<string>();
            foreach (ListItem materia in listMateria.Items)
            {
                if (materia.Selected)
                    resp.Add(materia.Text);
            }

            return resp;
        }
        private List<string> getPalestrasText()
        {
            List<string> resp = new List<string>();
            foreach (ListItem palestra in listPalestra.Items)
            {
                if (palestra.Selected)
                    resp.Add(palestra.Text);
            }

            return resp;
        }

        private List<string> getMateriasValues()
        {
            List<string> resp = new List<string>();
            foreach (ListItem materia in listMateria.Items)
            {
                if (materia.Selected)
                    resp.Add(materia.Value);
            }

            return resp;
        }

        private List<string> getPalestrasValues()
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