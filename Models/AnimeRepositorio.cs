using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class AnimeRepositorio : IRepositorio<Animes>
    {
        private List<Animes> listaAnime = new List<Animes>();
        public void Atualiza(int id, Animes objeto)
        {
            listaAnime[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaAnime[id].Excluira();
        }

        public void Insere(Animes objeto)
        {
            listaAnime.Add(objeto);
        }

        public List<Animes> Lista()
        {
            return listaAnime;
        }

        public int ProximoId()
        {
            return listaAnime.Count;
        }

        public Animes RetornaPorId(int id)
        {
            return listaAnime[id];
        }
    }
}