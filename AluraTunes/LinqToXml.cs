using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AluraTunes
{
    class LinqToXml
    {
        private static void ListarMusicas(XElement element)
        {
            var query = from genero in element.Elements("Generos").Elements("Genero")
                        join musica in element.Elements("Musicas").Elements("Musica")
                        on genero.Element("GeneroId").Value equals musica.Element("GeneroId").Value
                        select new
                        {
                            Id = musica.Element("MusicaId").Value,
                            Musica = musica.Element("Nome").Value,
                            Genero = genero.Element("Nome").Value
                        };

            foreach (var q in query)
            {
                Console.WriteLine("{0}\t{1}", q.Musica, q.Genero);
            }
        }

        private static void ListarGeneros(XElement element)
        {
            var queryXML = from generos in element.Element("Generos").Elements("Genero")
                           select generos;

            foreach (var genero in queryXML)
            {
                Console.WriteLine("Id:{0}\tGenero:{1}", genero.Element("GeneroId").Value, genero.Element("Nome").Value);
            }
        }

        private static XElement CarregarXML()
        {
            return XElement.Load(@"XML\AluraTunes.xml");
        }
    }
}
