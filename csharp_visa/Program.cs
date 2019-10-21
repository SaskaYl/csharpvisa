using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace csharp_visa
{
    class Program
    {
            static string nimi;
        static List<Kysymys> täysilista;
        static List<Kysymys> sekolista;
        static int score;
        static void Main(string[] args)
        {
            
            KysyNimi();
            Filut luku = new Filut();
            List<string> kys;
            List<string> vast;
            
            luku.Luerivit(out kys, out vast);
            täysilista=LuoKysymysLista(kys, vast);
            sekolista=ArvoKysymykset(täysilista);
            KysyKäyttäjältä(sekolista);
            PrinttaaPisteet();

            
            
        }

        private static void PrinttaaPisteet()
        {
            Console.WriteLine();

            if (score < 3)
            {
                Console.WriteLine($"{nimi}, sait {score}/{sekolista.Count} pistettä!Aika heikko suoritus");
            }
            else if( score>=3&&score<7)
            {
                Console.WriteLine($"{nimi}, sait {score}/{sekolista.Count} pistettä!Ihan ok!");
            }
            else
            {
                Console.WriteLine($"Onneksi olkoon { nimi}, sait { score}/{ sekolista.Count} pistettä!");
            }
                
        }

        private static void KysyKäyttäjältä(List<Kysymys> kyssät)
        {
            bool jatka = true;
            while(jatka)
            {
                Console.WriteLine("Aloitetaan testi. ");
                Console.WriteLine("Vastaa painamalla K/E + enter.");
                Thread.Sleep(3000);
                Console.Clear();

                for (int i = 0; i < kyssät.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine(kyssät[i].Kys);
                    var vastaus = Console.ReadLine().ToUpper();
                        if (kyssät[i].Vast.Equals("K")&& vastaus.Equals("YES")|| kyssät[i].Vast.Equals("K") && vastaus.Equals("Y") )
                        {
                            vastaus = kyssät[i].Vast;
                            Console.WriteLine("Hyvä, oikein meni!");
                            Thread.Sleep(800);
                            Console.Clear();

                            score++;
                        }
                    else if (kyssät[i].Vast.Equals("E") && vastaus.Equals("NO") || kyssät[i].Vast.Equals("E") && vastaus.Equals("N"))
                    {
                        vastaus = kyssät[i].Vast;
                        Console.WriteLine("Hyvä, oikein meni!");
                        Thread.Sleep(800);
                        Console.Clear();

                        score++;
                    }

                    else if (vastaus.Equals(kyssät[i].Vast))
                    {
                        Console.WriteLine("Hyvä, oikein meni!");
                         Thread.Sleep(800);
                        Console.Clear();
                        
                        score++;
                    }
                    else 
                    {
                        Console.WriteLine("Vastasit väärin :(");
                        Thread.Sleep(800);
                        Console.Clear();



                    }
                    
                }
                Console.WriteLine("Paina enter lopettaaksesi pelin.");
                 if (Console.ReadKey().Key!= ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    jatka = true;
                }
                else
                {
                    jatka = false;
                }
                
            }
            
        }

        private static List<Kysymys> ArvoKysymykset(List<Kysymys> lista)
        {
            var sekolista = new List<Kysymys>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                
            int x = rnd.Next(lista.Count);
                if (!sekolista.Contains(lista[x]))
                {
                sekolista.Add(lista[x]);

                }
                else
                {
                    i--;
                }

            }
            return sekolista;
        }

        private static List<Kysymys> LuoKysymysLista(List<string> kys,
        List<string> vas)
        {
            var Kysymyslista = new List<Kysymys>();
            for (int i = 0; i < vas.Count; i++)
            {
                Kysymyslista.Add(new Kysymys(kys[i], vas[i]));
            }
            return Kysymyslista;
        }

        public static void KysyNimi()
        {
            Console.WriteLine("Kirjoita nimesi");
            nimi = Console.ReadLine();
            Console.WriteLine($"Hei, {nimi}!");
            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}
