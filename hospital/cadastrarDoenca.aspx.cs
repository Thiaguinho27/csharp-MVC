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
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<Equipamento> equip = new List<Equipamento>();
        protected void Page_Load(object sender, EventArgs e)
        {
            equip = Servico.BuscarEquipamentos();
            foreach(Equipamento eq in equip)
            {
                lstEquipamento.Items.Add(eq.Nome);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Doenca d = new Doenca();

            d.Nome = txtNome.Text;
            d.Id_doenca = 0;
            d.Descricao = txtDescricao.Text;
           
            try
            {
                d.Equipamento = Servico.BuscarEquipamentos(lstEquipamento.SelectedValue.ToString())[0];
            }
            catch(Exception err)
            {
                Response.Write(err.ToString());
                return;
            }

            try
            {
                Servico.salvar(d);

                Response.Redirect("Default");
            }
            catch(Exception a)
            {
                Response.Write(a.ToString());
            }
        }
    }
}