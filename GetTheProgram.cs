using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

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
            var actualMonthNro = 4;
            string value = null;
            string[] kk = {"april", "may", "june", "july", "august", "september", "november", "october", "december"};
            try
            {
                foreach (string item in kk)
                {
                    for (int i = 0; i < System.DateTime.DaysInMonth(2017, actualMonthNro); i++)
                    {
                        addressOfCF = String.Format(@"http://www.crossfitinvictus.com/wod/{0}-{1}-2017-competition/",
                            kk[kknumber], pvm);
                        
                        var wc = new HtmlWeb();
                        var doc = wc.Load(addressOfCF);
                
                        if (doc != null)
                        {
                            var node = doc.DocumentNode.SelectSingleNode("//div[@class='entry-content']");
                            if (node != null)
                            {
                                value = node.InnerText.Trim();
                            }
                        }
                
                        var nameOfFile = String.Format("Invictus{0}{1}.txt",kk[kknumber],pvm);

                        using (var sw = new StreamWriter((@"D:\Gdrive\CrossfitValmennus\Invictuksen ohjelma2017\" + nameOfFile),
                            true, Encoding.UTF8))
                        {
                            
                        }
                        
                        
                        
                    }



                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
 
}
