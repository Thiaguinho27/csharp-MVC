using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using hospital.Model;
using hospital.Model.Entidades;
using hospital.Model.Suporte;


namespace hospital
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Equipamento novo = new Equipamento();

            if (!String.IsNullOrWhiteSpace(Request.Form["quanti"]) && !String.IsNullOrWhiteSpace(txtNomeEquip.Text) && !String.IsNullOrWhiteSpace(txtDescricaoEquip.Text))
            {
                novo.Nome = txtNomeEquip.Text;
                novo.Id_equipamento = 0;
                novo.Descricao = txtDescricaoEquip.Text;
                try
                {
                    novo.Quantidade = Convert.ToInt64(Request.Form["quanti"]);
                }
                catch(Exception a)
                {

                }
                try
                {
                    Servico.salvar(novo);
                    Response.Redirect("Default.aspx");
                }
                catch(Exception s)
                {

                }
            }
            else
            {

            }
        }
    }
}