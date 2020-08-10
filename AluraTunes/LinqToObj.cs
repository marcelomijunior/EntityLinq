using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes
{
    class LinqToObj
    {
        public static void ConsultarGeneros(List<Genero> generos)
        {
            //foreach (var genero in generos)
            //{
            //    Console.WriteLine("Id:{0}\tGenero: {1}", genero.Id, genero.Nome);
            //}

            //Console.WriteLine();

            //utilizando Linq para gerar consulta do genero pelo nome.
            var queryGeneros = from genero in generos
                               where genero.Nome.Contains("Rock")
                               select genero;

            foreach (var q in queryGeneros)
            {
                Console.WriteLine("Id:{0}\tGenero: {1}", q.Id, q.Nome);
            }
        }

        public static void ConsultarMusicas(List<Genero> generos, List<Musica> musicas)
        {
            var queryMusicas = from musica in musicas
                               join genero in generos on musica.GeneroId equals genero.Id
                               select new { musica, genero };

            foreach (var q in queryMusicas)
            {
                Console.WriteLine("Id:{0}\tMúsica:{1}\tGenero: {2}", q.musica.Id, q.musica.Nome, q.genero.Nome);
            }
        }

        public static List<Musica> CriarMusicas()
        {

            //listar músicas
            return new List<Musica>()
            {
                new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1},
                new Musica { Id=2,Nome="I Shot the Sheriff", GeneroId=2},
                new Musica {Id=3, Nome="Danúbio Azul", GeneroId=5 }
            };
        }

        public static List<Genero> CriarGeneros()
        {


            //listar os gêneros de músicas no sistema.
            return new List<Genero>() {
                new Genero {Id = 1, Nome = "Rock"},
                new Genero {Id = 2, Nome = "Reggae"},
                new Genero {Id = 3, Nome = "Rock Progressivo"},
                new Genero {Id = 4, Nome = "Jazz"},
                new Genero {Id = 5, Nome = "Punk Rock"},
                new Genero {Id = 6, Nome = "Clássica"},
            };
        }
    }

    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GeneroId { get; set; }
    }
}
