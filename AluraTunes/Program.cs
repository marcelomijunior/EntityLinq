using AluraTunes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraTunes
{
    class Program
    {
        static void Main(string[] args)
        {
            //criar uma consulta que deve trazer as faixas de músicas a partir de dois parâmetros. 
            //nome do artista e título do álbum.
            LinqToEntities.PesquisarFaixas(new AluraTunesDBEntities(), "Iron Maiden", "");

            Console.WriteLine();
            Console.WriteLine("Aperte a tecla 'enter' para finalizar a execução...");
            Console.ReadKey();
        }
    }
}
