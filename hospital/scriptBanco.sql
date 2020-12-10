CREATE DATABASE "hospital"

------------------------Sequences---------------------------------
CREATE SEQUENCE doenca_id_doenca_seq
    INCREMENT 1
    START 2
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

CREATE SEQUENCE equipamento_id_equipamento_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;
CREATE SEQUENCE paciente_id_paciente_seq
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;

----------------------------Tabelas-------------------------------

CREATE TABLE equipamento
(
    id_equipamento integer NOT NULL DEFAULT nextval('equipamento_id_equipamento_seq'::regclass),
    nome_equipamento character varying(50) NOT NULL,
    descricao_equipamento character varying(50) NOT NULL,
    quantidade integer NOT NULL, 
    CONSTRAINT equipamento_pkey PRIMARY KEY (id_equipamento)
)

CREATE TABLE doenca
(
    id_doenca integer NOT NULL DEFAULT nextval('doenca_id_doenca_seq'::regclass),
    id_equipamento integer NOT NULL,
    nome_doenca character varying(50) NOT NULL,
    descricao_doenca character varying(50) COLLATE NOT NULL,
    CONSTRAINT doenca_pkey PRIMARY KEY (id_doenca),
    CONSTRAINT doenca_fkey FOREIGN KEY (id_equipamento) REFERENCES equipamento (id_equipamento) 
)

CREATE TABLE paciente
(
    id_paciente integer NOT NULL DEFAULT nextval('paciente_id_paciente_seq'::regclass),
    id_doenca integer NOT NULL,
    nome_paciente character varying(50) NOT NULL,
    idade integer NOT NULL,
    data_internacao date NOT NULL,
    usando_equipamento boolean NOT NULL,
    CONSTRAINT pk_paciente PRIMARY KEY (id_paciente),
    CONSTRAINT paciente_fkey FOREIGN KEY (id_doenca) REFERENCES doenca (id_doenca)
)