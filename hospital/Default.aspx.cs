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
    public partial class _Default : System.Web.UI.Page
    {
        protected List<Paciente> pacientes;
        protected List<Equipamento> equipamentos;
        protected List<Doenca> doencas;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            int aux = 0;
            String[] nomeE = { };
            int[] valorE = { };
            equipamentos = Servico.BuscarEquipamentos();
            foreach (Equipamento eq in equipamentos)
            {
                nomeE[aux] = eq.Nome;
                valorE[aux] = Convert.ToInt32(eq.Quantidade);
                aux++;
            }
                
            */
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}