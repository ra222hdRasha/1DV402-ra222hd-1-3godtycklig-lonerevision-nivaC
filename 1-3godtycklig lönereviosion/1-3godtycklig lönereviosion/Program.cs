using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3godtycklig_lönereviosion
{
    class Program
    {
        static void Main(string[] args)
        {
            int antalLön;
            int[] salaries;
            //bool valid = true;
            do{
                do{
                    Console.Title ="GodTycklig lönerevision -nivå C";
                    //ReadInt() anropas för att ta reda på antalet löner som nvändaren vill mata in. 
                    antalLön = ReadInt("Ange antal löner att mata in:");
                    Console.WriteLine();

                         if(antalLön < 2){
                             ViewMessage("Du måste mata in minst två löner för att kunna göra en beräkning!",backgroundColor:ConsoleColor.Red);
                             
                         }else{
                             
                             break;
                         }
                }while (true);
                 //ReadSalaries anropas antalet löner att läsa in skickas med som argument och en array med lönerna returneras.
                //Presentas the resultat efter beräkningar
                salaries = ReadSalaries(antalLön);
                ViewResult(salaries);
            }while(IsContinuing());
            
        }
        //********************************************************************************************************************************
        //Metoden presenterar ett meddelande som upppmanar använadaren att trycka på en tangent för att fortsätta eller Escape-avslutar. *
        //********************************************************************************************************************************

        private static bool IsContinuing()
        {
        
                ViewMessage("Tryck på en tangent för ny beräkning -Esc avslutar");

                return Console.ReadKey(true).Key != ConsoleKey.Escape;
            
        }

        //*************************************************************************
        //Metoden ska användas för att läsa in så väl antalet löner som en lön.   *
        //*************************************************************************
        private static int ReadInt(string prompt)
        {
            int integer;
            string mess;
          
          //  bool valid = true;
            do
            {
                Console.Write(prompt);
                mess = Console.ReadLine();
                try
                {
                    integer = Int32.Parse(mess);
                    break;

                }
                catch (FormatException) {
                    ViewMessage(String.Format("FEL! '{0}' kan inte to tolkas som ett heltal!", mess), backgroundColor: ConsoleColor.Red);

                }
              

            } while (true);
            return integer;
        }
        //***************************************************************************************************************
        //Metoden läser in lönerna, genom anrop av metoden ReadInt(), coh lagra dessa i en lokal array av typen int []. *
        //***************************************************************************************************************
        private static int[] ReadSalaries(int count){
            string mes = null;
             //List-objekt som kan innehålla referenser till int-objekt T i List<T> ersätts med typ som List-objekt ska innehålla
            List<int> salaries = new List<int>();
            for (int i = 1; i <= count; i++)
            {
                //För att lägga till objekt till List-objekt måste du använda metoden Add .
               salaries.Add(ReadInt(String.Format("Ange lön nummer {0}: ", i)));
            }
            Console.WriteLine();
            ViewMessage(String.Format("Antal löner som användaren angett :-", mes), backgroundColor: ConsoleColor.DarkGreen);
            Console.WriteLine();
           foreach (int mySalaries in salaries)
            {
                
                Console.WriteLine(mySalaries);
            }
            return salaries.ToArray();

        }
        //*************************************************************************************************
        //
        private static void ViewMessage(string message,
            ConsoleColor backgroundColor = ConsoleColor.Blue
            ,ConsoleColor foregroundColor = ConsoleColor.White)
       {
         Console.WriteLine();
         Console.BackgroundColor = backgroundColor;
         Console.ForegroundColor = foregroundColor;
         Console.WriteLine(message);
         Console.ResetColor();
         Console.WriteLine();

    }
        //****************************************************************************************************************************************
        //ViewResult refererar till en array med inmatade löner. I samband med att median lön medellön och lönespridning presenteras på lämpligt *
        //****************************************************************************************************************************************
        //Medianlönen ======== utökningmetoden Median()
        //Medellönen ========= utökningmetoden Average()
        //Lönespridning ======== utökning metoden Dispersion()
        private static void ViewResult(int[] salaries)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Medianlön:            {0:c0}", salaries.Median());
            Console.WriteLine("Medellön:             {0:c0}", salaries.Average());
            Console.WriteLine("Lönespridning:        {0:c0}", salaries.Dispersion());
            Console.WriteLine("------------------------------------");
            for (int index = 0; index < salaries.Length; index += 3)
            {
                for (int j = 0; index+ j < salaries.Length && j < 3; j++)
                {
                    Console.Write("{0,10}", salaries[index + j]);
                }
                Console.WriteLine();
            }

        }
    }
}
