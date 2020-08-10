﻿using AluraTunes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes
{
    public class LinqToEntities
    {
        //criar uma consulta que deve trazer as faixas de músicas a partir de dois parâmetros. 
        //nome do artista e título do álbum.
        public static void PesquisarFaixas(AluraTunesDBEntities context, string nomeArtista, string nomeAlbum)
        {
            var query = from faixa in context.Faixas
                        where faixa.Album.Artista.Nome.Contains(nomeArtista)
                        select faixa;

            if (!String.IsNullOrEmpty(nomeAlbum))
            {
                query = query.Where(q => q.Album.Titulo.Contains(nomeAlbum));
            }

            foreach (var q in query)
            {
                Console.WriteLine("{0}\t{1}", q.Album.Titulo.PadRight(50), q.Nome);
            }
        }

        public static void PesquisarArtistas(AluraTunesDBEntities context, string nomeArtista)
        {
            //pesquisando artistas e albuns do artista com join.
            var queryPesquisa1 = from artista in context.Artistas
                                 join album in context.Albums on artista.ArtistaId equals album.ArtistaId
                                 where artista.Nome.Contains(nomeArtista)
                                 select new { NomeArtista = artista.Nome, NomeAlbum = album.Titulo};
            // ou
            //var queryPesquisa2 = context.Artistas
            //    .Where(a => a.Nome.Contains(textoPesquisa))
            //    .ToList();

            //pesquisando artistas e albuns do artista sem join.
            var queryPesquisa3 = from album in context.Albums
                                 where album.Artista.Nome.Contains(nomeArtista)
                                 select new
                                 {
                                     NomeArtista = album.Artista.Nome,
                                     NomeAlbum = album.Titulo
                                 };

            foreach (var q in queryPesquisa1)
            {
                Console.WriteLine("{0}\t{1}", q.NomeArtista, q.NomeAlbum);
            }
        }

        public static void PesquisarGeneros(AluraTunesDBEntities context)
        {
            var queryGeneros = from genero in context.Generos
                               select genero;

            foreach (var genero in queryGeneros)
            {
                Console.WriteLine("{0}\t{1}", genero.GeneroId, genero.Nome);
            }
        }

        //public static void PesquisarFaixas(AluraTunesDBEntities context)
        //{
        //    var queryFaixaDeGenero = from genero in context.Generos
        //                             join faixa in context.Faixas on genero.GeneroId equals faixa.GeneroId
        //                             select new { faixa, genero };

        //    queryFaixaDeGenero = queryFaixaDeGenero.Take(10);

        //    context.Database.Log = Console.WriteLine;

        //    foreach (var item in queryFaixaDeGenero)
        //    {
        //        Console.WriteLine("{0}\t{1}", item.faixa.Nome, item.genero.Nome);
        //    }
        //}
    }
}
