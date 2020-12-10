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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected Paciente p = new Paciente();
        protected Equipamento eq = new Equipamento();
        protected Doenca d = new Doenca();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["id"] != null)
                {

                    //======================Pacientes
                    if (Session["tipo"].Equals("p"))
                    {
                        
                        p = Servico.BuscarPacientes(Convert.ToInt64(Session["id"]))[0];
                        List<Doenca> doe = new List<Doenca>();
                        doe = Servico.BuscarDoencas();
                        foreach(Doenca aux in doe)
                        {
                            lstDoenca.Items.Add(aux.Nome);
                        }
                        lstDoenca.SelectedValue = p.Doenca.Nome;
                        TxtNomePaciente.Text = p.Nome;
                        
                        cbxUsando.Checked = p.Usando_equipamento;
                        calInternacao.SelectedDate = p.Data_internacao;
                        
                    }

                    //======================Equipamentos
                    if (Session["tipo"].Equals("e"))
                    {
                        
                        eq = Servico.BuscarEquipamentos(Convert.ToInt64(Session["id"]));
                        
                        txtNomeEquip.Text = eq.Nome;
                        txtDescricaoEquip.Text = eq.Descricao;

                    }

                    //======================Doencas
                    if (Session["tipo"].Equals("d"))
                    {
                        
                        d = Servico.BuscarDoencas(Convert.ToInt64(Session["id"]))[0];
                        List<Equipamento> eqAux = new List<Equipamento>();
                        eqAux = Servico.BuscarEquipamentos();
                        foreach(Equipamento eqr in eqAux)
                        {
                            lstEquipamento.Items.Add(eqr.Nome);
                        }
                        lstEquipamento.SelectedValue = d.Equipamento.Nome;
                        txtNomeDoenca.Text = d.Nome;
                        txtDescricaoDoenca.Text = d.Descricao;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Nao foi selecionado nenhum objeto')</script>");
                    Response.Redirect("Default");
                }
            }
            
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Session["tipo"].Equals("p"))
            {
                if(!String.IsNullOrEmpty(TxtNomePaciente.Text) && !String.IsNullOrEmpty(Request.Form["idade"]) && (lstDoenca.SelectedIndex != -1))
                {
                    try
                    {
                        p = Servico.BuscarPacientes(Convert.ToInt64(Session["id"]))[0];
                        
                        if (p.Usando_equipamento == !cbxUsando.Checked)
                        {
                            eq = Servico.BuscarEquipamentos(p.Doenca.Equipamento.Nome)[0];
                            if (cbxUsando.Checked)
                                eq.Quantidade--;
                            else
                                eq.Quantidade++;
                            Servico.salvar(eq);
                        }
                        p.Nome = TxtNomePaciente.Text;
                        p.Usando_equipamento = cbxUsando.Checked;
                        p.Data_internacao = calInternacao.SelectedDate;
                        p.Doenca = Servico.BuscarDoencas(lstDoenca.SelectedValue)[0];
                        p.Idade = Convert.ToInt32(Request.Form["idade"]);

                        
                        Servico.salvar(p);
                        Response.Redirect("Default");
                    }
                    catch(Exception err)
                    {
                        Response.Write("<script>alert('Erro: "+err.ToString()+". Tente novamente')</script>");
                        Response.Redirect("Default");
                    }
                    
                }
            }

            //======================Equipamentos
            if (Session["tipo"].Equals("e"))
            {
                if(!String.IsNullOrEmpty(Request.Form["quantidade"]) && !String.IsNullOrEmpty(txtDescricaoEquip.Text) && !String.IsNullOrEmpty(txtNomeEquip.Text))
                {
                    try
                    {
                        eq = Servico.BuscarEquipamentos(Convert.ToInt64(Session["id"]));

                        eq.Nome = txtNomeEquip.Text;
                        eq.Quantidade = Convert.ToInt64(Request.Form["quantidade"]);
                        eq.Descricao = txtDescricaoEquip.Text;
                        
                        Servico.salvar(eq);
                        Response.Redirect("Default");
                    }
                    catch (Exception err)
                    {
                        Response.Write("<script>alert('Erro: " + err.ToString() + ". Tente novamente')</script>");
                        Response.Redirect("Default");
                    }
                }
            }

            //======================Doencas
            if (Session["tipo"].Equals("d"))
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtNomeDoenca.Text) && !String.IsNullOrEmpty(txtDescricaoDoenca.Text))
                    {
                        d = Servico.BuscarDoencas(Convert.ToInt64(Session["id"]))[0];

                        d.Nome = txtNomeDoenca.Text;
                        d.Descricao = txtDescricaoDoenca.Text;
                        d.Equipamento = Servico.BuscarEquipamentos(lstEquipamento.SelectedValue)[0];

                        //Response.Write(d.Equipamento.Id_equipamento);
                        Servico.salvar(d);
                        Response.Redirect("Default");
                    }
                }
                catch(Exception err)
                {
                    Response.Write("<script>alert('Erro: " + err.ToString() + ". Tente novamente')</script>");
                    Response.Redirect("Default");
                }
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Session["tipo"].Equals("p"))
            {
                try
                {
                    p = Servico.BuscarPacientes(Convert.ToInt64(Session["id"]))[0];
                    Servico.Excluir(p);
                    Response.Redirect("Default");
                }
                catch(Exception err)
                {
                    Response.Write("<script>alert('Erro: " + err.ToString() + ". Tente novamente')</script>");
                }
            }

            //======================Equipamentos
            if (Session["tipo"].Equals("e"))
            {
                try
                {
                    eq = Servico.BuscarEquipamentos(Convert.ToInt64(Session["id"]));
                    Servico.Excluir(eq);
                    Response.Redirect("Default");
                }
                catch (Exception err)
                {
                    Response.Write("<script>alert('Erro: " + err.ToString() + ". Tente novamente')</script>");
                }
            }

            //======================Doencas
            if (Session["tipo"].Equals("d"))
            {
                try
                {
                    d = Servico.BuscarDoencas(Convert.ToInt64(Session["id"]))[0];
                    Servico.Excluir(d);
                    Response.Redirect("Default");
                }
                catch (Exception err)
                {
                    Response.Write("<script>alert('Erro: " + err.ToString() + ". Tente novamente')</script>");
                }
            }
        }
    }
}