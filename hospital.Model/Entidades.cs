using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace hospital.Model.Entidades
{
    public class Doenca
    {
        //================================Atributos====================================
        private String nome;
        private Int64 id_doenca;
        private String descricao;
        private Equipamento equipamento;

        // ===============================Propriedades====================================

        public String Nome
        {
            get
            {
                return this.nome;
            }

            set
            {
                this.nome = value;
            }
        }

        public Int64 Id_doenca
        {
            get
            {
                return this.id_doenca;
            }

            set
            {
                this.id_doenca = value;
            }
        }

        public String Descricao
        {
            get
            {
                return this.descricao;
            }

            set
            {
                this.descricao = value;
            }
        }

        public Equipamento Equipamento
        {
            get
            {
                return this.equipamento;
            }

            set
            {
                this.equipamento = value;
            }
        }
    }
    public class Equipamento 
    {
        //================================Atributos====================================
        private Int64 id_equipamento;
        private String nome;
        private String descricao;
        private Int64 quantidade;
        // ===============================Propriedades====================================

        public Int64 Id_equipamento 
        {

            get => this.id_equipamento;

            set
            {
                this.id_equipamento = value;
            }
        }
        public String Nome
        {

            get => this.nome;

            set
            {
                this.nome = value;
            }
        }
        public String Descricao
        {

            get => this.descricao;

            set
            {
                this.descricao = value;
            }
        }
        public Int64 Quantidade
        {
            get
            {
                return this.quantidade;
            }
            set
            {
                this.quantidade = value;
            }
        }

    }
    public class Paciente
    {
        //================================Atributos====================================
        private String nome;
        private int idade;
        private Int64 id_paciente;
        private Doenca doenca;
        private DateTime data_internacao;
        private bool usando_equipamento;
        // ===============================Propriedades====================================
        public String Nome
        {
            get
            {
                return this.nome;
            }
            set
            {
                this.nome = value;
            }
        }

        public int Idade
        {
            get
            {
                return this.idade;
            }
            set
            {
                this.idade = value;
            }
        }
        public Int64 Id_paciente
        {
            get
            {
                return this.id_paciente;
            }
            set
            {
                this.id_paciente = value;
            }
        }
        public Doenca Doenca
        {
            get
            {
                return this.doenca;
            }
            set
            {
                this.doenca = value;
            }
        }
        public DateTime Data_internacao
        {
            get
            {
                return this.data_internacao;
            }
            set
            {
                this.data_internacao = value;
            }
        }

        public bool Usando_equipamento
        {
            get
            {
                return this.usando_equipamento;
            }
            set
            {
                this.usando_equipamento = value;
            }
        }

    }


}
