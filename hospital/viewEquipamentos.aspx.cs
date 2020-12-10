using hospital.Model;
using hospital.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hospital
{
    public partial class viewEquipamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                grdEquipamentos.DataSource = Servico.BuscarEquipamentosDataTable();
                grdEquipamentos.DataBind();
            }
        }

        protected void grdEquipamentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("detalhes"))
            {
                string id_equipamento = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(id_equipamento))
                {
                    Session["id"] = id_equipamento;
                    Session["tipo"] = "e";
                    Response.Redirect("detalhes");
                }
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            String nome = "";
            int min = 1;
            int max = 2147483647;

            if(!String.IsNullOrWhiteSpace(txtNome.Text))
            {
                nome = txtNome.Text;
            }
            if(!String.IsNullOrEmpty(Request.Form["min"]))
            {
                min = Convert.ToInt32(Request.Form["min"]);
            }

            if (!String.IsNullOrEmpty(Request.Form["max"]))
            {
                max = Convert.ToInt32(Request.Form["max"]);
            }

            if (!String.IsNullOrWhiteSpace(txtNome.Text) || !String.IsNullOrWhiteSpace(Request.Form["min"]) || !String.IsNullOrWhiteSpace(Request.Form["max"]))
            {
               
                grdEquipamentos.DataSource = Servico.BuscarEquipamentosDataTable(nome,min,max);
                grdEquipamentos.DataBind();
               
            }
            else
            {
                Response.Write("<script>alert('Entre com o dado que deseja selecionar')</script>");
                return;
            }
        }
    }
}