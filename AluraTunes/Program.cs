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
            using (var context = new AluraTunesDBEntities())
            {
            }

            Console.WriteLine();
            Console.WriteLine("Aperte a tecla 'enter' para finalizar a execução...");
            Console.ReadKey();
        }

        private static decimal Mediana(IQueryable<NotaFiscal> notasFiscais)
        {
            var elementoCentral_1 = notasFiscais.OrderBy(nf => nf.Total).Skip(notasFiscais.Count() / 2).First();
            var elementoCentral_2 = notasFiscais.OrderBy(nf => nf.Total).Skip((notasFiscais.Count() - 1) / 2).First();

            var mediana = (elementoCentral_1.Total + elementoCentral_2.Total) / 2;

            return mediana;
        }
    }
}
