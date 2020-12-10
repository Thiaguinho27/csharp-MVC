using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hospital.Model.Entidades;
using hospital.Model;

namespace hospital
{
    public partial class viewDoencas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack && String.IsNullOrEmpty(txtNomeDoenc.Text))
            {
                grdDoencas.DataSource = Servico.BuscarDoencasDataTable();
                grdDoencas.DataBind();

                List<Equipamento> eq = new List<Equipamento>();
                eq = Servico.BuscarEquipamentos();
                foreach (Equipamento eqa in eq)
                    lstEquipamento.Items.Add(eqa.Nome);
            }
        }

        protected void grdDoencas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("detalhes"))
            {
                string id_doenca = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(id_doenca))
                {
                    Session["id"] = id_doenca;
                    Session["tipo"] = "d";
                    Response.Redirect("detalhes");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           if(!String.IsNullOrWhiteSpace(txtNomeDoenc.Text) || (lstEquipamento.SelectedIndex!= -1))
           {
               if(lstEquipamento.SelectedIndex == -1)
               {
                    grdDoencas.DataSource = Servico.BuscarDoencasDataTable(txtNomeDoenc.Text);
                    grdDoencas.DataBind();
               }
               else if(String.IsNullOrWhiteSpace(txtNomeDoenc.Text))
               {
                    Equipamento eq = new Equipamento();
                    eq = Servico.BuscarEquipamentos(lstEquipamento.SelectedValue)[0];
                    //Response.Write(eq.Id_equipamento);
                    grdDoencas.DataSource = Servico.BuscarDoencasDataTable(eq.Id_equipamento);
                    grdDoencas.DataBind();
               }
               else
               {
                    Equipamento eq = new Equipamento();
                    eq = Servico.BuscarEquipamentos(lstEquipamento.SelectedValue)[0];

                    grdDoencas.DataSource = Servico.BuscarDoencasDataTable(txtNomeDoenc.Text,eq.Id_equipamento);
                    grdDoencas.DataBind();
               }
               
           }
           else
           {
                Response.Write("<script>alert('Entre com o dado para procurar')</script>");
                return;
           }
        }

    }
}