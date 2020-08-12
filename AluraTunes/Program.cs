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
                context.Database.Log = Console.WriteLine;
            }

            Console.WriteLine();
            Console.WriteLine("Aperte a tecla 'enter' para finalizar a execução...");
            Console.ReadKey();
        }

        
    }
}
