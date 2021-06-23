using System;
using System.Collections.Generic;
using DIO.Cadastro.Interfaces;

namespace DIO.Cadastro
{
    public class DoramaRepositorio : IRepositorio<Dorama>
    {
        private List<Dorama> listaDorama = new List<Dorama>();
        public void Atualiza(int id, Dorama objeto)
        {
            listaDorama[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaDorama[id].exclui();
        }

        public void Insere(Dorama objeto)
        {
            listaDorama.Add(objeto);
        }

        public List<Dorama> Lista()
        {
            return listaDorama;
        }

        public int ProximoId()
        {
            return listaDorama.Count;
        }

        public Dorama RetornaPorId(int id)
        {
            return listaDorama[id];
        }
    }
}