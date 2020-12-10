using hospital.Model.Entidades;
using hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace hospital
{
    public partial class cadastrarPaciente : System.Web.UI.Page
    {
        List<Doenca> doenc = new List<Doenca>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                doenc = Servico.BuscarDoencas();
                foreach (Doenca d in doenc)
                {
                    lstDoenca.Items.Add(d.Nome);
                }
            }
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Paciente p = new Paciente();

            p.Nome = txtNome.Text;
            p.Id_paciente = 0;
            p.Data_internacao = calInternacao.SelectedDate;
            p.Usando_equipamento = cbxUsando.Checked;

            try
            {
                p.Doenca = Servico.BuscarDoencas(lstDoenca.SelectedValue.ToString())[0];
                    
            }
            catch (Exception err)
            {
                Response.Write(err.ToString());
            }

            try
            {
                if(String.IsNullOrEmpty(Request.Form["idade"]))
                {
                    Response.Write("<script>alert('Entre com uma idade')</script>");
                    return;
                }
                p.Idade = Convert.ToInt16(Request.Form["idade"]);
            }
            catch (Exception erro)
            {
                Response.Write(erro.ToString());
            }

                
            if(p.Usando_equipamento && p.Doenca.Equipamento.Quantidade == 0)
            {
                Response.Write("Infelizmente não há mais equipamentos disponíveis para esse tratamento");
                return;
            }
            
            try
            {
                p.Doenca.Equipamento.Quantidade--;

                Servico.salvar(p);
                Servico.salvar(p.Doenca.Equipamento);

                //Response.Write(p.Doenca.Equipamento.Quantidade+"     toma = "+p.Doenca.Nome);
                Response.Redirect("Default");
            }
            catch (Exception er)
            {
                Response.Write(er.ToString());
            }
            
            
        }
    }
}