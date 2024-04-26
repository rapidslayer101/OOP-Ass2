using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class SevensOut
    {
        // starts an instance of the sevens out game
        protected internal void RunGame(Statistics stats, string playerType)
        {
            Console.WriteLine("\nSevens Out game instantiated");

            // variables to score player totals and turn scores
            var total1 = 0;
            var score1 = 0;
            var total2 = 0;
            var score2 = 0;
            var die1Value = 0;
            var die2Value = 0;

            // loop until both players have a score of 7
            while (true)
            {
                // if player1 has not scored 7, roll dice
                if (score1 != 7)
                {
                    // get player1 enter to roll dice
                    Console.WriteLine("Player 1 press enter to roll dice");
                    Console.ReadLine();
                    
                    // roll dice method
                    (total1, score1) = RollDice(total1, "player1");

                    if (score1 == 7)
                    {
                        Console.WriteLine("Player 1 has scored 7 and ended their turns");
                    }

                    Console.WriteLine();
                }

                // if player2 has not scored 7, roll dice
                if (score2 != 7)
                {
                    if (playerType == "computer")
                    {
                        // get computer to roll dice
                        Console.WriteLine("Player 2 (Computer) is rolling dice");
                    }
                    else
                    {
                        // get player2 enter to roll dice
                        Console.WriteLine("Player 2 press enter to roll dice");
                        Console.ReadLine();
                    }

                    // roll dice method
                    (total2, score2) = RollDice(total2, "player2");

                    if (score2 == 7)
                    {
                        Console.WriteLine("Player 2 has scored 7 and ended their turns");
                    }

                    Console.WriteLine();
                }

                // if both players have a score of 7, end the game
                if (score1 == 7 & score2 == 7)
                {
                    Console.WriteLine("Sevens Out game finished\n");
                    break;
                }
            }

            // write player totals
            Console.WriteLine("Player 1 total: " + total1);
            Console.WriteLine("Player 2 total: " + total2);

            // compare player totals and write winner
            if (total1 > total2)
            {
                Console.WriteLine("Player 1 wins with score " + total1);
                
                // increment number of sevens out games won by player1 in statistics
                stats.SevensOutStatPlayer1Wins();
                
                // check if high score has been beaten and update if necessary in statistics
                stats.SevensOutStatHighScore(total1);
            }
            else if (total2 > total1)
            {
                Console.WriteLine("Player 2 wins with score " + total2);
                
                if (playerType == "computer")
                {
                    // increment number of sevens out games won by computer in statistics
                    stats.SevensOutStatComputerWins();
                }
                else
                {
                    // increment number of sevens out games won by player2 in statistics
                    stats.SevensOutStatPlayer2Wins();
                }
                
                // check if high score has been beaten and update if necessary in statistics
                stats.SevensOutStatHighScore(total2);
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        // roll dice method, contains logic for rolling dice and calculating scores
        private static (int, int) RollDice(int total, string player)
        {
            // create a new dice object
            var die1 = new Die();
            var die2 = new Die();

            // add 1-millisecond delay to ensure random seed is different
            System.Threading.Thread.Sleep(1);
            
            // create random object
            var random = new Random();
            
            // roll 2 dice by calling the RollDice method
            var die1Value = die1.Roll(random);
            var die2Value = die2.Roll(random);

            // sum the two dice rolls
            var score = die1Value + die2Value;

            // if both dice are the same, double the score
            if (die1Value == die2Value)
            {
                score *= 2;
            }

            // add the score to total
            total += score;
            
            // write the player's total and the score for the current roll 
            Console.WriteLine(player + " total: " + total + ", roll score: " + score +
                              " (" + die1Value + " + " + die2Value + ")");

            // return data to calling method to write to 
            return (total, score);
        }
        
        // todo test version of RollDice method
        public void RunTest()
        {
            //
        }
    }
}