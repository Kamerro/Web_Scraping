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
        public static List<Cities> cities = new List<Cities>();
        static void Main(string[] args)
        {
            Scrapper scraper = new Scrapper();
            string _cityshortcut = "DE";
            Console.WriteLine("All cities for the country:");
            cities = scraper.getCountry(_cityshortcut).ToList();
            foreach (Cities city in cities)
            {
                Console.WriteLine(city.name);
            }
            Console.ReadLine();
        }
    }
}
