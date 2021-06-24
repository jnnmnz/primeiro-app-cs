using System;

namespace DIO.Cadastro
{
    public class Filme : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Sinopse { get; set; }
        private int Ano { get; set; }
        private int Duracao { get; set; }
        private bool Indisponivel { get; set; }

        public Filme (int id, Genero genero, string titulo, string sinopse, int ano, int duracao) {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Sinopse = sinopse;
            this.Ano = ano;
            this.Duracao = duracao;
            this.Indisponivel = false;
        }

        public override string ToString() {
            string retorno = "";
            retorno += "TÍTULO: "+this.Titulo+Environment.NewLine;
            retorno += "GÊNERO: "+this.Genero+Environment.NewLine;
            retorno += "SINOPSE: "+this.Sinopse+Environment.NewLine;
            retorno += "LANÇAMENTO: "+this.Ano+"        DURAÇÃO: "+this.Duracao+" minutos"+Environment.NewLine;
            retorno += "DISPONÍVEL: "+(this.Indisponivel ? "NÃO" : "SIM");
            //return base.ToString();
            return retorno;
        }

        public string retornaTitulo() {
            return this.Titulo;
        }
        public int retornaId() {
            return this.Id;
        }
        public bool retornaExluido(){
            return this.Indisponivel;
        }
        public void exclui(){
            this.Indisponivel = true;
        }
    }
}