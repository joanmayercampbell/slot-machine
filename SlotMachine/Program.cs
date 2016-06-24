using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Program
    {
        /*
         * Welcome message
         * Directions
         * Choose a machine
         * Place a bet
         * Pull lever
         * Randomly rolls around and gives you 
         * Machine tells you if you won or not
         */
        static void Main(string[] args)
        {
            SlotMachine myMachine = new SlotMachine(); // 3 slots, 5 icons per slot

            Console.WriteLine("Welcome to slots!");

            Console.WriteLine("Directions");

            while (true)
            {
                // place a bet
                Console.WriteLine("Type in how many pennies to bet or enter 0 to exit: ");

                // You could get this using:
                // int userBet = Convert.ToInt32(Console.ReadLine());
                // myMachine.CurrentBet = userBet;
                myMachine.CurrentBet = Convert.ToInt32(Console.ReadLine());

                // if zero pennies then leave the program
                if (myMachine.CurrentBet == 0)
                {
                    break;
                }

                // pull the lever
                Console.WriteLine("Press enter to pull the lever");
                Console.ReadKey(); // TODO Later: make this actually look for ENTER
                myMachine.PullLever();

                // display the results
                int[] tempResults = myMachine.GetResults();
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < tempResults.Length; i++)
                {

                    Console.Write(tempResults[i] + " ");
                }
                Console.ForegroundColor = ConsoleColor.White;

                // payout
                Console.WriteLine();
                if (myMachine.GetPayout() == 0)
                {
                    Console.WriteLine("Sorry you did not win, try again!", myMachine.GetPayout());
                }
                else
                {
                    decimal penniesInDollars = myMachine.GetPayout() / 100;
                    Console.WriteLine("You won $ {0} ",penniesInDollars);
                }
                
            }

        }
    }
}
