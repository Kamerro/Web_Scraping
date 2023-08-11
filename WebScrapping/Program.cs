using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScrapping;

namespace WebScraping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scrapper scraper = new Scrapper();
            string _cityshortcut = "DE";
            Console.WriteLine("All cities for the country:");
            scraper.getCountry(_cityshortcut);
            Console.ReadLine();
        }
    }
}
