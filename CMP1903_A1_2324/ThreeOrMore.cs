using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class ThreeOrMore
    {
        // starts an instance of the Three Or More game
        internal void RunGame(Statistics stats, string playerType)
        {
            Console.WriteLine("Three Or More game instantiated");
            
            // variables to score player totals and turn scores
            var points1 = 0;
            var points2 = 0;
            
            // loop until one player has 20 points
            while (points1 < 20 && points2 < 20)
            {
                // get player1 enter to roll dice
                Console.WriteLine("Player1 press enter to roll dice");
                Console.ReadLine();
                
                // roll dice method for player1
                points1 = RollDice(points1, "player1", playerType, ("0", "0"));
                
                Console.WriteLine();
                
                // player 2 turn
                if (playerType == "computer")
                {
                    // tell user computer is rolling dice
                    Console.WriteLine("Player2 (Computer) is rolling dice");
                }
                else
                {
                    // get player2 enter to roll dice
                    Console.WriteLine("Player2 press enter to roll dice");
                    Console.ReadLine();
                }
                    
                // roll dice method for player2
                points2 = RollDice(points2, "player2", playerType, ("0", "0"));
                
                Console.WriteLine();
            }
            
            // compare player totals and write winner
            if (points1 >= 20)
            {
                Console.WriteLine("Player1 wins with " + points1 + " points!");
                
                // increment number of Three Or More games won by player1 in statistics
                stats.ThreeOrMoreStatPlayer1Wins();
            }
            else
            {
                Console.WriteLine("Player2 wins with " + points2 + " points!");
                
                if (playerType == "computer")
                {
                    // increment number of Three Or More games won by computer in statistics
                    stats.ThreeOrMoreStatComputerWins();
                }
                else
                {
                    // increment number of Three Or More games won by player2 in statistics
                    stats.ThreeOrMoreStatPlayer2Wins();
                }
            }
            
        }
    
        // roll dice method, contains logic to roll 5 dice and return the total points
        private static int RollDice(int points, string player, string playerType, (string, string) twoOfAKind)
        {
            // if 2 of a kind, only roll 3 dice, else roll 5 dice
            var rolls = 5;
            if (twoOfAKind.Item1 != "0")
            {
                rolls = 3;
            }
            
            // create a list of 5 dice objects
            var dice = Enumerable.Range(0, rolls).Select(x => new Die()).ToList();
            
            // add 1-millisecond delay to ensure random seed is different
            System.Threading.Thread.Sleep(1);
            
            // create a random object
            var random = new Random();
            
            // create a string to store the dice values
            var diceValues = "";
            
            // if there are remaining dice for a rethrow, add them to the diceValues string
            if (rolls == 3)
            {
                
                diceValues = (twoOfAKind.Item1 + twoOfAKind.Item2);
            }
   
            // loop through each dice object
            foreach (var die in dice)
            {
                // roll and add the dice value to the string
                diceValues += die.Roll(random);
            }
            
            
            // counter to increment for each dice value
            var counter = 0;
            
            // check for 2,3,4 or 5 of a kind
            foreach (var value in diceValues)
            {
                counter++;
                
                // if 5 of a kind
                if (diceValues.Count(x => x == value) >= 5)
                {
                    points += 12;
                    Console.WriteLine(player + " total: " + points + ", roll scored 5 of a kind, 12 points! Roll: " + diceValues);
                    break;
                }
                
                // if 4 of a kind
                if (diceValues.Count(x => x == value) >= 4)
                {
                    points += 6;
                    Console.WriteLine(player + " total: " + points + ", roll scored 4 of a kind, 6 points! Roll: " + diceValues);
                    break;
                }
                
                // if 3 of a kind
                if (diceValues.Count(x => x == value) >= 3){
                    points += 3;
                    Console.WriteLine(player + " total: " + points + ", roll scored 3 of a kind, 3 points! Roll: " + diceValues);
                    break;
                }
                
                // if 2 of a kind
                if (diceValues.Count(x => x == value) >= 2){
                    Console.WriteLine(player + " total: " + points + ", roll scored 2 of a kind, 0 points! " + diceValues);
                    
                    var choice = "";
                    
                    if (playerType == "computer" && player == "player2")
                    {
                        // if computer, choose 1 or 2 randomly
                        Random randomChoice = new Random();
                        choice = randomChoice.Next(1, 3).ToString();
                    }
                    else
                    {
                        // ask user rethrow choice
                        Console.WriteLine("Would you like to rethrow all or just the remaining dice?"
                                          + "\n1. Rethrow all"
                                          + "\n2. Rethrow remaining");
                        
                        // get user choice on rethrow
                        while (choice != "1" && choice != "2")
                        {
                            choice = Console.ReadLine();
                        }
                    }
                    
                    // rethrow all dice
                    if (choice == "1")
                    {
                        Console.WriteLine("Rethrowing all dice for " + player);
                        points = RollDice(points, player, playerType, ("0", "0"));
                    }
                    // rethrow remaining dice
                    else
                    {
                        // get 2 of a kind dice values as a list
                        var twoOfAKindList = diceValues.Where(x => x == value).ToList();
                        
                        Console.WriteLine("Rethrowing remaining dice for " + player);
                        // recursively call RollDice method with remaining dice as a parameter
                        points = RollDice(points, player, playerType, (twoOfAKindList[0].ToString(), twoOfAKindList[1].ToString()));

                    }
                    break;
                }
                
                // if none of a kind
                if (counter == 5)
                {
                    Console.WriteLine(player + " total:" + points + ", roll scored 0 points! Roll:" + diceValues);
                }
            }
            
            return points;
        }

    }
}