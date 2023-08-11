using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapping
{
    internal class Scrapper
    {
        private string URL
            = "https://unece.org/trade/cefact/unlocode-code-list-country-and-territory";
        public List<Cities> cities = new List<Cities>();
        /// <summary>
        /// country shortcut for Poland = PL. Germany = DE etc
        /// </summary>
        /// <param name="county_shortcut"></param>
        public void getCountry(string country_shortcut = "PL")
        {
            var web = new HtmlWeb();
            var document = web.Load(URL);
            var tableRows = document.QuerySelectorAll("table tr").Skip(1);
            HtmlNode node = tableRows.First(x=>x.QuerySelectorAll("td")[0].InnerHtml == country_shortcut);
            var td = node.QuerySelectorAll("td");
            var href = td[1].QuerySelector("a").Attributes["href"];
            var code = td[1].InnerText;
            var name = td[0].InnerHtml;

            var inner_web = new HtmlWeb();
            var inner_document = inner_web.Load(href.Value);
            var inner_table= inner_document.QuerySelectorAll("table").Skip(2);
            var inner_tab_rows = inner_table.QuerySelectorAll("tr");
            foreach(var obj in inner_tab_rows)
            {
                var city_rows = obj.QuerySelectorAll("td");
                Cities city = new Cities();
                city.name = city_rows[3].InnerText.DeleteHardSpace();
                cities.Add(city);
            }

            foreach(Cities city in cities)
            {
                Console.WriteLine(city.name);
            }

        }
    }

    public static class StringExtensions
    {
        public static string DeleteHardSpace(this string a)
        {
            return a.Replace("&nbsp", "");
        }
    }
}
