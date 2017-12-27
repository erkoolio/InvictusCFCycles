using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using System.Xml;

namespace InvictusCFCycles
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            //April 3 - august 8
            //
            var addressOfCF = String.Empty;
            
            var pvm = 1;
            var kknumber = 0;
            var weeknumber = 1;
            var actualMonthNro = 4;
            string value = null;
            int i = 1;
            string[] kk = {"april", "may", "june", "july", "august", "september", "november", "october", "december"};
            try
            {
                foreach (string item in kk)
                {
                    for (i = 1; i <= System.DateTime.DaysInMonth(2017, actualMonthNro); i++)
                    {
                        addressOfCF = String.Format(@"http://www.crossfitinvictus.com/wod/{0}-{1}-2017-competition/",
                            kk[kknumber], pvm);

                        var wc = new HtmlWeb();
                        var doc = wc.Load(addressOfCF);
                        //var doc = GetCleanHtml(addressOfCF);
                        if (doc != null)
                        {
                            var node = doc.DocumentNode.SelectSingleNode("//div[@class='entry-content']");
                            
                            if (node != null)
                            {
                                var noodde = node.InnerHtml;
                                value = value + "\n" + noodde.InnerText.Trim() + "=============================";
                            }
                        }

                        if (i % 7 == 0)
                        {
                            var nameOfFile =
                                "InvictusWeek" + weeknumber; //String.Format("Invictus{0}{1}.txt",kk[kknumber],pvm);

                            using (var sw = new StreamWriter(
                                (@"D:\Gdrive\CrossfitValmennus\Invictuksen ohjelma2017\" + nameOfFile),
                                true, Encoding.UTF8))
                            {
                                sw.Write(value);
                            }
                            value = String.Empty;

                        }
                        actualMonthNro++;
                        
                    }




                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        
        public static string GetCleanHtml(string html)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return HtmlAgilityPack.HtmlEntity.DeEntitize(doc.DocumentNode.InnerText);
        }
    }
 
}
