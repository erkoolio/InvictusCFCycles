using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace InvictusCFCycles
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            //April 3 - august 8
            //
            var addressOfCF = String.Empty;
            ;
            var pvm = 1;
            var kknumber = 0;
            var actualMonthNro = 4;
            string[] kk = {"april", "may", "june", "july", "august", "september", "november", "october", "december"};
            try
            {
                foreach (string item in kk)
                {
                    for (int i = 0; i < System.DateTime.DaysInMonth(2017, actualMonthNro); i++)
                    {
                        addressOfCF = String.Format(@"http://www.crossfitinvictus.com/wod/{0}-{1}-2017-competition/",
                            kk[kknumber], pvm);
                    }



                }

                //var addressOfCF = String.Format(@"http://www.crossfitinvictus.com/wod/{0}-{1}-2017-competition/",kk[kknumber], pvm );

                var wc = new WebClient();
                var content = wc.DownloadString(addressOfCF);
                var paikka = content.IndexOf("A. ");

                var nameOfFile = "testi.txt";

                using (var sw = new StreamWriter((@"D:\Gdrive\CrossfitValmennus\Invictuksen ohjelma2017\" + nameOfFile),
                    true, Encoding.UTF8))
                {
                    var alku = content.IndexOf("<p>A.<");

                    var temp = content.Substring(alku);
                    var loppu = temp.IndexOf("</div>");

                    var mites = temp.Substring(0, loppu).Replace("<br />", @"\n;").Split(';');
                    foreach (var item in mites)
                    {
                        sw.Write(item);
                    }
                    sw.Write("==========================================");
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
