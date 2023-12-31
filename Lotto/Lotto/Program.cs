﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Lotto
{
    class Pula
    {
        public int[] wybrane = new int[6];
        public int[] zbior = new int[6];
        public HashSet<int> unique_zbior = new HashSet<int>();

        public void wybor()
        {
            bool warunek = true;
            Console.WriteLine("Wprowadź wybrane 6 różnych cyfr w zakresie 1-49: ");
            while (warunek)
            {
                for (int i = 0; i < wybrane.Length; i++)
                {
                    Console.WriteLine("{0}. cyfra: ", i + 1);
                    int x = Convert.ToInt32(Console.ReadLine());
                    if(x >= 1 && x <= 49)
                    {
                        if (wybrane.Contains(x))
                        {
                            Console.WriteLine("Wybrałeś już tą liczbę. Wybierz inną");
                            x = 0;
                            i--;
                        }
                        else
                        {
                            wybrane[i] = x;
                        }    
                    }
                    else if (x < 1 || x > 49)
                    {
                        Console.WriteLine("Error. Musisz podać cyfrę w zakresie 1-49. Spróbuj ponownie.");
                        x = 0;
                        i--;
                    }
                    
                }
                warunek = false;
            }
            Array.Sort(wybrane);
            Console.WriteLine("Wybrane: " + string.Join(", ", wybrane));
        }
        public void losowanie()
        {
            for (int i = 0; i < 6; i++)
            {
                Random rnd = new Random();
                int v = rnd.Next(1, 49);

                unique_zbior.Add(v);
                //sprawdzenie ile cyfr udało się nam odgadnąć
            }
            Array.Sort(zbior);
            Console.WriteLine("Wylosowane: " + string.Join(", ", unique_zbior));

            int[] trafione = new int[6];
            int licznik = 0;
            for (int i = 0; i < 6; i++)
            {
                if (unique_zbior.Contains(wybrane[i]))
                {
                    trafione[i] = wybrane[i];
                }
                if (trafione[i] > 0)
                {
                    licznik++;
                }
            }
            Console.WriteLine("Trafione: " + string.Join(", ", trafione));
            Console.WriteLine("Liczba trafionych: " + string.Join(", ", licznik));
            if (licznik == 1)
            {
                Console.WriteLine("Uff, chociaż 1 trafienie. Nagroda: satysfakcja");
            }
            else if (licznik == 2)
            {
                Console.WriteLine("Całkiem nieźle, 2 trafienia. Nagroda: Uśmiech na resztę dnia :)");
            }
            else if (licznik == 3)
            {
                Console.WriteLine("Jacie 3 trafienia. Nagroda: PATRZ!! CZY TO JESIOTR??");
            }
            else if (licznik == 4)
            {
                Console.WriteLine("Winszuje, 4 trafienia to nie lada wynik. Nagroda: Przkręcony Pentium 3 + zapas niebieskich trytytek");
            }
            else if (licznik == 5)
            {
                Console.WriteLine("W czepku urodzony. 5 trafień to niezwykłe szczęście. Nagroda: Nowiutki Maybach S-Clasa, ale kluczyki gdzieś posiałem");
            }
            else if (licznik == 6)
            {
                Console.WriteLine("WOOOW!!! Jak to możliwe? 6 TRAFIEŃ! Moje gratulacje. Nagroda: Fiat Multipla TDI 3.0 w gazie");
            }
            else
            {
                Console.WriteLine("Ahh no niestety, nie udało się. Może następnym razem");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("********#Loteria lotto#*********");
                Pula obj = new Pula();
                obj.wybor();
                obj.losowanie();
            }
        }
    }
}
