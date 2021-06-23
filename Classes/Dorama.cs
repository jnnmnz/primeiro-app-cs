using System;

namespace DIO.Cadastro
{
    public class Dorama : EntidadeBase
    {
        // ATRIBUTOS
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Sinopse { get; set; }
        private int Ano { get; set; }
        private bool Indisponivel { get; set; }

        // MÉTODOS
        public Dorama (int id, Genero genero, string titulo, string sinopse, int ano) {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Sinopse = sinopse;
            this.Ano = ano;
            this.Indisponivel = false;
        }

        public override string ToString() {
            string retorno = "";
            retorno += "Gênero: "+this.Genero+Environment.NewLine;
            retorno += "Título: "+this.Titulo+Environment.NewLine;
            retorno += "Sinopse: "+this.Sinopse+Environment.NewLine;
            retorno += "Lançamento: "+this.Ano+Environment.NewLine;
            retorno += "Disponível: "+this.Indisponivel;
            //return base.ToString();
            return retorno;
        }

        // ECAPSULAMENTO

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