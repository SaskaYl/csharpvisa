
using System;
using System.Collections.Generic;
using System.IO;
namespace csharp_visa

{
    public class Filut
    {
        
        static string rivi;

        StreamReader r = new StreamReader(@"C:\Users\saska\OneDrive\Tiedostot\csharp_visa\csharpvisa.txt");

        public Filut()
        {
        }
        public void Luerivit(out List<string> kys, out List<string> vasta)
        {
            List<string> kyssät = new List<string>();
            List<string> vastaukset = new List<string>();
            while ((rivi = r.ReadLine())!=null)
            {
                string[] palaset = rivi.Split(';');
                kyssät.Add(palaset[0]);
                vastaukset.Add(palaset[1]);
            }
             kys = kyssät;
             vasta = vastaukset;
            
    r.Dispose();
        }

        }
    }
