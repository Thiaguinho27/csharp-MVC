using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using hospital.Model.Entidades;
using hospital.Model.Suporte;
using Npgsql;
using NpgsqlTypes;
using System.Runtime.CompilerServices;
using System.Data;

namespace hospital.Model
{
    public class Servico
    {
        public Servico()
        {

        }

        private static Doenca objetoDoenca(ref NpgsqlDataReader dtr)
        {
            Doenca d = new Doenca();
            
            d.Id_doenca = Convert.ToInt64(dtr["id_doenca"]);

            d.Equipamento = objetoEquipamento(ref dtr);
            d.Nome = dtr["nome_doenca"].ToString();
            d.Descricao = dtr["descricao_doenca"].ToString();

            return d;
        }

        private static Equipamento objetoEquipamento(ref NpgsqlDataReader dtr)
        {
            Equipamento e = new Equipamento();
            e.Id_equipamento = Convert.ToInt64(dtr["id_equipamento"]);
            e.Nome = dtr["nome_equipamento"].ToString();
            e.Descricao = dtr["descricao_equipamento"].ToString();
            e.Quantidade = Convert.ToInt64(dtr["quantidade"]);
            return e;
        }

        private static Paciente objetoPaciente(ref NpgsqlDataReader dtr)
        {
            Paciente p = new Paciente();

            p.Id_paciente = Convert.ToInt64(dtr["id_paciente"]);
            p.Nome = (String)dtr["nome_paciente"];
            p.Idade = (int)dtr["idade"];
            p.Data_internacao = (DateTime)dtr["data_internacao"];
            p.Doenca = objetoDoenca(ref dtr);
            p.Usando_equipamento = (bool)dtr["usando_equipamento"];
            return p;
        }

        public static void salvar(Doenca d)
        {
            List<Object> param = new List<object>();
            String sql;
            try
            {
                if (d.Id_doenca == 0)
                {
                    sql = "INSERT INTO public.doenca" +
                           " (id_equipamento,nome_doenca,descricao_doenca)" +
                           " VALUES(@1,@2,@3)";

                    param.Add(d.Equipamento.Id_equipamento);
                    param.Add(d.Nome);
                    param.Add(d.Descricao);


                    ConexaoBanco.executar(sql,param);
                }
                else if (d.Id_doenca > 0)
                {
                    sql = "UPDATE public.doenca SET" +
                          " nome_doenca=@1,"+
                          " descricao_doenca=@2,"+
                          " id_equipamento=@3"+
                          " WHERE id_doenca=@4";

                    param.Add(d.Nome);
                    param.Add(d.Descricao);
                    param.Add(d.Equipamento.Id_equipamento);
                    param.Add(d.Id_doenca);

                    ConexaoBanco.executar(sql,param);
                }
            }
            catch (Exception e)
            {
                return;
            }
        }
        public static void salvar(Equipamento e)
        {
            List<Object> param = new List<Object>();
            String sql;
            try
            {
                if (e.Id_equipamento == 0)
                {
                    sql = "INSERT INTO public.equipamento" +
                           " (nome_equipamento,descricao_equipamento,quantidade)" +
                           " VALUES(@1,@2,@3)";
                    param.Add(e.Nome);
                    param.Add(e.Descricao);
                    param.Add(e.Quantidade);

                    ConexaoBanco.executar(sql,param);
                }
                else if (e.Id_equipamento > 0)
                {
                    sql = "UPDATE public.equipamento SET" +
                          " nome_equipamento= @1,"+
                          " descricao_equipamento= @2,"+
                          " quantidade=@3"+
                          " WHERE id_equipamento=@4";

                    param.Add(e.Nome);
                    param.Add(e.Descricao);
                    param.Add(e.Quantidade);
                    param.Add(e.Id_equipamento);


                    ConexaoBanco.executar(sql,param);
                }
            }
            catch(Exception er)
            {
                return;
            }
        }
        public static void salvar(Paciente p)
        {
            List<Object> param = new List<object>();

            String sql;
            try
            {
                if (p.Id_paciente == 0)
                {
                    sql = "INSERT INTO public.paciente" +
                           " (nome_paciente,id_doenca,idade,data_internacao,usando_equipamento)" +
                           " VALUES(@1,@2,@3,@4,@5)";

                    param.Add(p.Nome);
                    param.Add(p.Doenca.Id_doenca);
                    param.Add(p.Idade);
                    param.Add(p.Data_internacao);
                    param.Add(p.Usando_equipamento);

                    ConexaoBanco.executar(sql,param);
                }
                else if (p.Id_paciente > 0)
                {
                    sql = "UPDATE public.paciente SET" +
                          " nome_paciente=@1,"+
                          " id_doenca=@2,"+
                          " idade=@3,"+
                          " data_internacao=@4,"+
                          " usando_equipamento=@5" +
                          " WHERE id_paciente=@6";
                    param.Add(p.Nome);
                    param.Add(p.Doenca.Id_doenca);
                    param.Add(p.Idade);
                    param.Add(p.Data_internacao);
                    param.Add(p.Usando_equipamento);
                    param.Add(p.Id_paciente);


                    ConexaoBanco.executar(sql,param);
                }
            }
            catch(Exception e)
            {
                return;
            }
        }

        public static List<Doenca> BuscarDoencas()
        {

            String sql = "SELECT * FROM doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento";
            List<Doenca> doenca = new List<Doenca>();
            try
            {
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql);
                while (dtr.Read())
                {
                    doenca.Add(objetoDoenca(ref dtr));
                }
                dtr.Close();
                return doenca;
            }
            catch(Exception e)
            {
                return null;
            }

        }
        public static List<Doenca> BuscarDoencas(String nome)
        {
            List<Doenca> doenca = new List<Doenca>();
            List<Object> param = new List<Object>();
            String sql = "SELECT * FROM doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento WHERE nome_doenca LIKE @1";
            
            try
            {
                param.Add("%"+nome+"%");
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql,param);

                while (dtr.Read())
                {
                    doenca.Add(objetoDoenca(ref dtr));
                }
                dtr.Close();
                return doenca;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static List<Doenca> BuscarDoencas(Int64 id)
        {
            List<Doenca> doenca = new List<Doenca>();
            List<Object> param = new List<Object>();
            String sql = "SELECT * FROM doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento WHERE id_doenca = @1";
            
            try
            {
                param.Add(id);
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql,param);

                while (dtr.Read())
                {
                    doenca.Add(objetoDoenca(ref dtr));
                }
                dtr.Close();
                return doenca;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable BuscarDoencasDataTable()
        {

            try
            {
                String sql = "SELECT * FROM doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento";
                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarDoencasDataTable(string nome)
        {
            try
            {
                String sql = "SELECT * FROM doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento WHERE nome_doenca LIKE '%"+nome+"%'";
                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarDoencasDataTable(Int64 id_equip)
        {
            try
            {
                String sql = "SELECT * FROM doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento WHERE doenca.id_equipamento ="+id_equip;
                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarDoencasDataTable(String nome, Int64 id_equip)
        {
            try
            {
                String sql = "SELECT * FROM doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento WHERE doenca.id_equipamento =" + id_equip+" AND nome_doenca LIKE '%"+nome+"%'";
                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<Paciente> BuscarPacientes()
        {

            String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento";
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql);

                while (dtr.Read())
                {
                    pacientes.Add(objetoPaciente(ref dtr));
                }
                dtr.Close();
                return pacientes;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public static List<Paciente> BuscarPacientes(Int64 id)
        {
            List<Object> param = new List<Object>();
            List<Paciente> pacientes = new List<Paciente>();
            String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento WHERE id_paciente = @1";
            
            try
            {
                param.Add(id);
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql,param);

                while (dtr.Read())
                {
                    pacientes.Add(objetoPaciente(ref dtr));
                }
                dtr.Close();
                return pacientes;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable BuscarPacientesDataTable()
        {

            try
            {
                String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento";

                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch(Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarPacientesDataTable(String nome, int idade, DateTime data, bool usando, String nomeDoenca)
        {

            try
            {
                String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento "+
                    "WHERE nome_paciente LIKE '%"+nome+"%' AND idade = "+idade+" AND data_internacao = '"+data+"' AND usando_equipamento = "+usando+" AND nome_doenca LIKE '%"+nomeDoenca+"%'";

                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarPacientesDataTable(String nome, DateTime data, bool usando, String nomeDoenca)
        {

            try
            {
                String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento " +
                    "WHERE nome_paciente LIKE '%" + nome + "%' AND data_internacao = '" + data + "' AND usando_equipamento = " + usando + " AND nome_doenca LIKE '%" + nomeDoenca + "%'";

                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarPacientesDataTable(String nome, bool usando, String nomeDoenca)
        {

            try
            {
                String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento " +
                    "WHERE nome_paciente LIKE '%" + nome + "%' AND usando_equipamento = " + usando + " AND nome_doenca LIKE '%" + nomeDoenca + "%'";

                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarPacientesDataTable(String nome, int idade, bool usando, String nomeDoenca)
        {

            try
            {
                String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento " +
                    "WHERE nome_paciente LIKE '%" + nome + "%' AND idade = " + idade + " AND usando_equipamento = " + usando + " AND nome_doenca LIKE '%" + nomeDoenca + "%'";

                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static List<Paciente> BuscarPacientes(String nome)
        {
            List<Paciente> pacientes = new List<Paciente>();
            List<Object> param = new List<Object>();
            String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento WHERE nome_paciente LIKE @1";
            
            try
            {
                param.Add("%"+nome+"%");
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql,param);

                while (dtr.Read())
                {
                    pacientes.Add(objetoPaciente(ref dtr));
                }
                dtr.Close();
                return pacientes;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static List<Paciente> BuscarPacientes(DateTime data_intern)
        {
            List<Paciente> pacientes = new List<Paciente>();
            List<Object> param = new List<Object>();
            String sql = "SELECT * FROM paciente INNER JOIN doenca ON paciente.id_doenca = doenca.id_doenca INNER JOIN equipamento ON doenca.id_equipamento = equipamento.id_equipamento WHERE data_internacao= @1";
            
            try
            {
                param.Add(data_intern);
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql,param);

                while (dtr.Read())
                {
                    pacientes.Add(objetoPaciente(ref dtr));
                }
                dtr.Close();
                return pacientes;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static List<Equipamento> BuscarEquipamentos()
        {

            String sql = "SELECT * FROM equipamento";
            List<Equipamento> equipamentos = new List<Equipamento>();
            
            try
            {
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql);

                while (dtr.Read())
                {
                    equipamentos.Add(objetoEquipamento(ref dtr));
                }
                dtr.Close();
                return equipamentos;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public static Equipamento BuscarEquipamentos(Int64 id_equipamento)
        {
            Equipamento equipamento = new Equipamento();
            List<Object> param = new List<Object>();
            String sql = "SELECT * FROM equipamento WHERE id_equipamento = @1";
            
            try
            {
                param.Add(id_equipamento);
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql,param);
                dtr.Read();

                equipamento = objetoEquipamento(ref dtr);

                dtr.Close();
                return equipamento;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Equipamento> BuscarEquipamentos(String nome)
        {

            String sql = "SELECT * FROM equipamento WHERE nome_equipamento LIKE @1";
            List<Equipamento> equipamentos = new List<Equipamento>();
            List<Object> param = new List<object>();

            param.Add("%"+nome+"%");

            try
            {
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql,param);

                while (dtr.Read())
                {
                    equipamentos.Add(objetoEquipamento(ref dtr));
                }
                dtr.Close();
                return equipamentos;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        /*public static Equipamento BuscarEquipamento(String nome)
        {

            String sql = "SELECT * FROM equipamento WHERE nome_equipamento='"+nome+"'";
            Equipamento equipamento = new Equipamento();

            try
            {
                NpgsqlDataReader dtr = ConexaoBanco.selecionar(sql);


                equipamento = objetoEquipamento(ref dtr);
                
                dtr.Close();
                return equipamento;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
                return null;
            }
        }
        */

        public static DataTable BuscarEquipamentosDataTable()
        {

            try
            {
                String sql = "SELECT * FROM equipamento";
                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarEquipamentosDataTable(String nome )
        {

            try
            {
                String sql = "SELECT * FROM equipamento WHERE nome_equipamento LIKE '%"+nome+"%'";
                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static DataTable BuscarEquipamentosDataTable(int quantMin, int quantMax)
        {

            try
            {
                String sql = "SELECT * FROM equipamento WHERE quantidade BETWEEN "+quantMin+" AND "+quantMax;
                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public static DataTable BuscarEquipamentosDataTable(String nome, int quantMin, int quantMax)
        {

            try
            {
                String sql = "SELECT * FROM equipamento WHERE quantidade BETWEEN '" + quantMin + "' AND '" + quantMax+"' AND nome_equipamento LIKE '%"+nome+"%'";
                return ConexaoBanco.selecionarDataTable(sql);
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public static void Excluir(Equipamento eq)
        {
            List<Object> param = new List<Object>();
            try
            {
                param.Add(eq.Id_equipamento);
                string sql = "DELETE FROM equipamento WHERE id_equipamento = @1";
                ConexaoBanco.executar(sql,param);
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public static void Excluir(Doenca d)
        {
            List<Object> param = new List<Object>();
            try
            {
                param.Add(d.Id_doenca);
                string sql = "DELETE FROM doenca WHERE id_doenca = @1";
                ConexaoBanco.executar(sql,param);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public static void Excluir(Paciente p)
        {
            List<Object> param = new List<Object>();
            try
            {
                param.Add(p.Id_paciente);
                string sql = "DELETE FROM paciente WHERE id_paciente = @1";
                ConexaoBanco.executar(sql,param);
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

    }
}
