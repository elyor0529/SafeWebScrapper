using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SafeWebScrapper.Example
{
    internal static class Program
    {

        private static void Main(string[] args)
        {
            var url = "https://jobboerse.arbeitsagentur.de";
            var scrapper = new JobBoerseScraper(url);

            scrapper.Start();

            Console.ReadLine();

            scrapper.Stop();
        }
    }
}
