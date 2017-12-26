using System;
using System.Collections.Generic;
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
            var addressOfCF = @"http://www.crossfitinvictus.com/wod/april-3-2017-competition/";
            
            var wc = new WebClient();
            var content = wc.DownloadString(addressOfCF);
            var paikka = content.IndexOf("A. ");
            
            var nameOfFile = "testi.txt";

            using (var sw = new StreamWriter((@"D:\Gdrive\CrossfitValmennus\Invictuksen ohjelma2017\" + nameOfFile), true, Encoding.UTF8))
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

        }
    }
