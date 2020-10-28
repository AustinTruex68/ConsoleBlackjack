using System;
using System.Linq;
using Blackjack.Models;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
           bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Welcome to Blackjack! $10 min/max\r");
            Console.WriteLine("------------------------\n");
            var userMoney = 20;

            while (!endApp)
            {
                // Declare variables and set to empty.
                var userHand = Game.GetUserHand();
                bool userTurn = true;
                int userSum = userHand.Sum(r => r.Number);
                bool userBust = false;
                bool? userWin = null;
                
                var dealerHand = Game.GetDealerHand();
                bool dealerTurn = true;
                int dealerSum = dealerHand.Sum(r => r.Number);
                bool dealerBust = false;
                
                Console.WriteLine($"Dealer showing {dealerHand.First().Value} of {dealerHand.First().Suite}");
                while (userTurn)
                {
                    userSum = userHand.Sum(r => r.Number);

                    Console.WriteLine($"Your hand is: {userSum}");

                    if (userSum > 21)
                    {
                        Console.WriteLine("Busted!");
                        userTurn = false;
                        userBust = true;
                        break;
                    }
                    
                    Console.Write("Hit? (y/n)\n");
                    
                    var hit = Console.ReadLine()?.ToLower() == "y";

                    if (hit)
                        userHand = Game.Hit(userHand);
                    else
                        userTurn = false;
                }
                
                while (dealerTurn)
                {
                    dealerSum = dealerHand.Sum(r => r.Number);
                    if (dealerSum > 21)
                    {
                        Console.WriteLine("Dealer Busted!");
                        dealerTurn = false;
                        dealerBust = true;
                    }

                    Console.WriteLine($"Dealer hand is {dealerSum}");

                    if (dealerSum < 17)
                        dealerHand = Game.Hit(dealerHand);
                    else
                        dealerTurn = false;
                }

                if (userBust)
                {
                    Console.WriteLine("You busted, you lost.");
                    userWin = false;
                }
                else if (!userBust && dealerBust)
                {
                    Console.WriteLine("Dealer busted, you win.");
                    userWin = true;
                }
                else if (dealerSum > userSum)
                {
                    Console.WriteLine("You lose.");
                    userWin = false;
                }
                else if (userSum > dealerSum)
                {
                    Console.WriteLine("You win.");
                    userWin = true;
                }
                else if (userSum == dealerSum)
                {
                    Console.WriteLine("Push");
                    userWin = null;
                }

                if (userWin == true)
                    userMoney += 10;
                else if (userWin == false)
                    userMoney -= 10;
                
                Console.WriteLine($"---- Your Money: ${userMoney}\n");

                if (userMoney == 0)
                    Console.WriteLine("Outta money... No worries.. I got you on credit.");

                // Wait for the user to respond before closing.
                Console.Write("Another hand? (y/n)\n");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}