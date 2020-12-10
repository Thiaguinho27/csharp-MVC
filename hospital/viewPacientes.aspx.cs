using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hospital.Model;
using hospital.Model.Entidades;
using Microsoft.Ajax.Utilities;

namespace hospital
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                grdPacientes.DataSource = Servico.BuscarPacientesDataTable();
                grdPacientes.DataBind();

                List<Doenca> doencas = new List<Doenca>();
                doencas = Servico.BuscarDoencas();

                foreach (Doenca d in doencas)
                    lstDoenca.Items.Add(d.Nome);
            }
            
        }

        protected void grdPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("detalhes"))
            {
                string id_paciente = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(id_paciente))
                {
                    Session["id"] = id_paciente;
                    Session["tipo"] = "p";
                    Response.Redirect("detalhes");
                }
            }
            
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            String nome ="";
            int idade =10;
            DateTime data = Convert.ToDateTime("10/10/2020");
            bool flag1 = false;
            bool flag2 = false;
            bool usando = cbxUsando.Checked;
            String nomeDoenca ="";

            if(!String.IsNullOrWhiteSpace(txtNome.Text))
            {
                nome = txtNome.Text;
            }
            if(!String.IsNullOrEmpty(Request.Form["idade"]))
            {
                idade = Convert.ToInt32(Request.Form["idade"]);
                flag1 = true;
            }
            if(!String.IsNullOrEmpty(Request.Form["data_internacao"]))
            {
                data = Convert.ToDateTime(Request.Form["data_internacao"]);
                flag2 = true;
            }
            if(lstDoenca.SelectedIndex != -1)
            {
                nomeDoenca = Servico.BuscarDoencas(lstDoenca.SelectedValue)[0].Nome;
            }
            if(flag1 && flag2)
            {
                grdPacientes.DataSource = Servico.BuscarPacientesDataTable(nome,idade,data,usando,nomeDoenca);
                grdPacientes.DataBind();
            }
            else
            {
                if(flag1)
                {
                    grdPacientes.DataSource = Servico.BuscarPacientesDataTable(nome, idade,usando, nomeDoenca);
                    grdPacientes.DataBind();
                }
                else if(flag2)
                {
                    grdPacientes.DataSource = Servico.BuscarPacientesDataTable(nome, data, usando, nomeDoenca);
                    grdPacientes.DataBind();
                }
                else
                {
                    grdPacientes.DataSource = Servico.BuscarPacientesDataTable(nome, usando, nomeDoenca);
                    grdPacientes.DataBind();
                }
            }

        }
    }
}