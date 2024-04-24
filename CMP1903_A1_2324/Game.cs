﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        // main method to run the program
        static void Main(string[] args)
        {
            var userInput = 0;
            // loop until user enters a valid input of one of the below menu options
            while (true)
            {
                try
                {
                    // show user options menu
                    Console.WriteLine("----------------------------------\n" +
                                      "1. Instantiate Sevens Out game\n" +
                                      "2. Instantiate Three Or More game\n" +
                                      "3. View Statistics data\n" +
                                      "4. Perform Tests");
                    // get user input
                    userInput = Convert.ToInt32(Console.ReadLine());
                    // check valid user input
                    if (userInput < 1 || userInput > 4)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4");
                    }
                    else
                    {
                        break;
                    }
                }
                // show error message if user input is not a number
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            }

            // check user input and perform the corresponding action
            switch (userInput)
            {
                case 1:
                    // get choice for play against player or computer
                    var choice1 = PlayerChoice(); 
                    
                    // instantiate the Sevens Out game
                    SevensOut sevensOut = new SevensOut();
                    sevensOut.RunGame(choice1);
                    break;
                
                case 2:
                    // get choice for play against player or computer
                    var choice2 = PlayerChoice();
                    
                    // instantiate the Three Or More game
                    ThreeOrMore threeOrMore = new ThreeOrMore();
                    threeOrMore.RunGame(choice2);
                    break;
                
                case 3:
                    // view stats data  //todo 
                    Console.WriteLine("Viewing statistics data");
                    break;
                case 4:
                    // perform tests in testing class  //todo
                    Console.WriteLine("Performing tests");
                    break;
            }
            
            // call main recursively to allow user to perform another action from the menu (program loop)
            Console.WriteLine("");
            Main(args);
        }

        private static string PlayerChoice()
        {
            // ask user if they want to play against computer or actual player
            Console.WriteLine("Do you want to play against the computer or an actual player?\n" +
                              "1. Computer\n" +
                              "2. Player");
            
            // get user input for player choice
            var playerType = Console.ReadLine();
            switch (playerType)
            {
                case "1":
                    playerType = "computer";
                    break;
                case "2":
                    playerType = "player";
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter 1 or 2");
                    // recursively call the method to get a valid input
                    PlayerChoice();
                    break;
            }
            
            return playerType;
        }
    }
}
