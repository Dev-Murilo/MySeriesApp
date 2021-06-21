using MySeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySeries
{
    class Serie : Identificador
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int AnoLanc { get; set; }
        public bool Assistido { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string nome, string descricao, int AnoLanc)
        {
            this.Id = id;
            this.Titulo = nome;
            this.Descricao = descricao;
            this.AnoLanc = AnoLanc;
            this.Assistido = false;
            this.Excluido = false;


        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.AnoLanc + Environment.NewLine;

            return retorno;
        }



        public int RetornaId()
        {
            return this.Id;
        }
        public string RetornaTitulo()
        {
            return this.Titulo;
        }
        public bool FoiExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}
