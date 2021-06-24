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
        private int Episodios { get; set; }
        private string Emissora { get; set; }
        private bool Completo { get; set; }
        private bool Indisponivel { get; set; }

        // MÉTODOS
        public Dorama (int id, Genero genero, string titulo, string sinopse, int ano, int episodios, string emissora, bool completo) {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Sinopse = sinopse;
            this.Ano = ano;
            this.Episodios = episodios;
            this.Emissora = emissora;
            this.Completo = completo;
            this.Indisponivel = false;
        }

        public override string ToString() {
            string retorno = "";
            retorno += "TÍTULO: "+this.Titulo+Environment.NewLine;
            retorno += "GÊNERO: "+this.Genero+Environment.NewLine;
            retorno += "SINOPSE: "+this.Sinopse+Environment.NewLine;
            retorno += "LANÇAMENTO: "+this.Ano+"        EPISÓDIOS: "+this.Episodios+"        EMISSORA: "+this.Emissora+Environment.NewLine;
            retorno += "COMPLETO: "+(this.Completo ? "SIM" : "NÃO")+Environment.NewLine;
            retorno += "DISPONÍVEL: "+(this.Indisponivel ? "NÃO" : "SIM");
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