/*
  First Name : Oumar
  Last Name  : Barry
  Prof Name  : Hao Tang
  Session    : Fall 2021
  Class      : CSC 350H
  Date       : 09/30/2021
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    public class Program
    {
        static void Main(String[] args)
        {
            // creating variables and initialization
            int card1, card2, king, queen, jack, ten, input, gameWon;
            bool pairExists, isForfeit, isGameReset, hasWon;
            hasWon = isGameReset = isForfeit = false;
            gameWon = card1 = card2 = king = queen = jack = ten = 0;
            
            do
            {
                // print menu
                PrintMenu();
                input = Convert.ToInt32(Console.ReadLine());

                // Game 1
                if (input == 1)
                {
                    TensBoard tensGame = new TensBoard(); // create an object
                    tensGame.Play(input); // Select game to play
                    
                    // Print Title
                    Console.WriteLine("\n-----------------------------");
                    Console.WriteLine("WELCOME TO THE TENSBOARD GAME");
                    Console.WriteLine("-----------------------------");
                    tensGame.Rules();
                    do
                    {
                        // In case user decides the reset the game
                        if (isGameReset == true)
                            tensGame.resetGame();

                        // Set both reset and forfeit flags to false
                        isGameReset = false;
                        isForfeit = false;
                        
                        // print the list of card
                        tensGame.PrintList();

                        // Checks if Jack, Queen, King and Ten exists in the list
                        if (tensGame.ValidateJQKT())
                        {
                            
                            Console.WriteLine("Selects the following cards : King, Queen, Jack and Ten");

                            // Select King and Input validation
                            Console.Write("\nSelect King # : ");
                            king = Convert.ToInt32(Console.ReadLine());
                            while (!tensGame.validateCard(king, "King"))
                            {
                                Console.WriteLine("\nThe card you selected is not a King. Try again !");
                                Console.Write("Select King # : ");
                                king = Convert.ToInt32(Console.ReadLine());
                            }

                            // Select Queen and Input validation
                            Console.Write("\nSelect Queen # : ");
                            queen = Convert.ToInt32(Console.ReadLine());
                            while (!tensGame.validateCard(queen, "Queen"))
                            {
                                Console.WriteLine("\nThe card you selected is not a Queen. Try again !");
                                Console.Write("Select Queen # : ");
                                queen = Convert.ToInt32(Console.ReadLine());
                            }

                            // Select Jack and Input validation
                            Console.Write("\nSelect Jack # : ");
                            jack = Convert.ToInt32(Console.ReadLine());
                            while (!tensGame.validateCard(jack, "Jack"))
                            {
                                Console.WriteLine("The card you selected is not a Jack. Try again !");
                                Console.Write("Select Jack # : ");
                                jack = Convert.ToInt32(Console.ReadLine());
                            }

                            // Select Ten and Input validation
                            Console.Write("\nSelect Ten # : ");
                            ten = Convert.ToInt32(Console.ReadLine());
                            while (!tensGame.validateCard(ten, "Ten"))
                            {
                                Console.WriteLine("The card you selected is not a Ten. Try again !");
                                Console.Write("Select Ten# : ");
                                ten = Convert.ToInt32(Console.ReadLine());
                            }

                            // Remove the cards
                            tensGame.removeUndesiredCards(king, queen, jack, ten);
                            Console.WriteLine("\nYour King, Queen, Jack and Ten cards have been removed.\n");
                            tensGame.PrintList();

                        }

                        // If combination does not exists in the list
                        if (!tensGame.PairExists())
                            pairExists = false; // set flag to false

                        else
                        {
                            // If combination exists in the list
                            Console.Write("\nThere's a pair of 10 in your list. Pick two cards.");
                            
                            // Select two cards
                            tensGame.SelectTwoCards(ref card1, ref card2);

                            // Check if selection is valid and remove the cards
                            if (tensGame.isValidSelection(card1, card2))
                                tensGame.replaceCards(card1, card2);

                            // Recheck if combination exists in the list
                            pairExists = tensGame.PairExists();

                            // Prompt the user for reset option
                            if (resetGame())
                                isGameReset = true; // set flag to true

                            // Prompt the user for forfeit option
                            if (isGameReset != true && forfeitGame())
                                isForfeit = true; // set flag to true

                            // check is user has won the game 
                            if (tensGame.hasWon())
                                hasWon = true; // set flag to true
                        }


                    } while (pairExists == true && isForfeit == false && hasWon == false); // Loop condition

                    // Output if there's no more combination in the list
                    if (pairExists == false)
                    {
                        tensGame.PrintList();
                        Console.WriteLine("\nAs you can see, there's no possible combination. You have lost the game!\nYour score is "
                                      + tensGame.Score + " Please select the game you would like to play next" +
                                      " or enter option 4 to exit\n");
                    }

                    // Output if user decides to forfeit the game
                    if (isForfeit == true)
                    { 
                        Console.WriteLine("\nYou have forfeited on this game. Your score is " + tensGame.Score + 
                                          "\nPlease select the game you would like to play next" +
                                          " or enter option 4 to exit\n");
                    }

                    if (hasWon == true)
                    {
                        Console.WriteLine("\nCONGRATULATION, you just won this game." +
                                          "\nPlease select the game you would like to play next" +
                                          " or enter option 4 to exit\n");
                        gameWon++;
                    }                        
                }

                // Game 2
                if (input == 2)
                {
                    ElevensBoard elevensBoard = new ElevensBoard(); // create an object
                    elevensBoard.Play(input); // Select game to play

                    // Prints the game title
                    Console.WriteLine("\n-------------------------------");
                    Console.WriteLine("WELCOME TO THE ELEVENBOARD GAME");
                    Console.WriteLine("-------------------------------");
                    elevensBoard.Rules(); // Prints the rule

                    do
                    {
                        // If user resets the game
                        if (isGameReset == true)
                            elevensBoard.resetGame();

                        // Set both reset and forfeit flags to false
                        isGameReset = false;
                        isForfeit = false;

                        // Prints the list of card
                        elevensBoard.PrintList();

                        // Checks if Jack, Queen and King exists in the list
                        if (elevensBoard.ValidateJQK())
                        {
                            Console.WriteLine("Selects the following cards : King, Queen and Jack :");
                            Console.Write("\nSelect King # : ");

                            king = Convert.ToInt32(Console.ReadLine());
                            while (!elevensBoard.validateCard(king, "King"))
                            {
                                Console.WriteLine("\nThe card you selected is not a King. Try again !");
                                Console.Write("Select King # : ");
                                king = Convert.ToInt32(Console.ReadLine());
                            }

                            Console.Write("\nSelect Queen # : ");
                            queen = Convert.ToInt32(Console.ReadLine());
                            while (!elevensBoard.validateCard(queen, "Queen"))
                            {
                                Console.WriteLine("\nThe card you selected is not a Queen. Try again !");
                                Console.Write("Select Queen # : ");
                                queen = Convert.ToInt32(Console.ReadLine());
                            }

                            Console.Write("\nSelect Jack # : ");
                            jack = Convert.ToInt32(Console.ReadLine());
                            while (!elevensBoard.validateCard(jack, "Jack"))
                            {
                                Console.WriteLine("The card you selected is not a Jack. Try again !");
                                Console.Write("Select Jack # : ");
                                jack = Convert.ToInt32(Console.ReadLine());
                            }

                            elevensBoard.removeUndesiredCards(king, queen, jack);
                            Console.WriteLine("\nYour King, Queen and Jack cards have been removed.\n");
                            elevensBoard.PrintList();
                        }

                        // Checks if a combination does not exist in the list
                        if (!elevensBoard.PairExists())
                            pairExists = false;

                        else
                        {
                            // In case there is a combination
                            Console.Write("\nThere's a pair of 11 in your list. Pick two cards.");

                            // Select two cards, valid them and replace if valid
                            elevensBoard.SelectTwoCards(ref card1, ref card2);

                            if (elevensBoard.isValidSelection(card1, card2))
                                elevensBoard.replaceCards(card1, card2);

                            // Recheck if pair exists in the list
                            pairExists = elevensBoard.PairExists();

                            // Prompt the user for reset option
                            if (resetGame())
                                isGameReset = true; // set flag to true

                            // Prompt the user for reset option
                            if (isGameReset != true && forfeitGame())
                                isForfeit = true; // set flag to true

                            // Check if user has won the game
                            if (elevensBoard.hasWon())
                                hasWon = true; // set flag to true
                        } 


                    } while (pairExists == true && isForfeit == false && hasWon == false); // Loop condition

                    // Output if there's no more combination in the list
                    if (pairExists == false)
                    {
                        Console.WriteLine("\nThere's no possible combination. You have lost the game!\nYour score is "
                                      + elevensBoard.Score + " Please select the game you would like to play next" +
                                      " or enter option 4 to exit\n");
                    }

                    // Output if user forfeits the game
                    if (isForfeit == true)
                    {
                        Console.WriteLine("\nYou have forfeited on this game. Your score is " + elevensBoard.Score +
                                          "\nPlease select the game you would like to play next" +
                                          " or enter option 4 to exit\n");
                    }

                    // Output if user has won the game
                    if (hasWon == true)
                    {
                        Console.WriteLine("\nCONGRATULATION, you just won this game." +
                                          "\nPlease select the game you would like to play next" +
                                          " or enter option 4 to exit\n");

                        gameWon++; // increment gameWon
                    }
                }

                // Game 3
                if (input == 3)
                {
                    ThirteensBoard thirteenGame = new ThirteensBoard();
                    thirteenGame.Play(input);

                    Console.WriteLine("\n----------------------------------");
                    Console.WriteLine("WELCOME TO THE THIRTEENSBOARD GAME");
                    Console.WriteLine("----------------------------------");
                    thirteenGame.Rules();
                    do
                    {
                        if (isGameReset == true)
                            thirteenGame.resetGame();

                        isGameReset = false;
                        isForfeit = false;

                        thirteenGame.PrintList();
                        if (thirteenGame.ValidateK())
                        {
                            Console.WriteLine("Selects the following cards : King, Queen and Jack :");
                            Console.Write("\nSelect King # : ");
                            king = Convert.ToInt32(Console.ReadLine());
                            while (!thirteenGame.validateCard(king, "King"))
                            {
                                Console.WriteLine("\nThe card you selected is not a King. Try again !");
                                Console.Write("Select King # : ");
                                king = Convert.ToInt32(Console.ReadLine());
                            }

                            thirteenGame.removeUndesiredCards(king);
                            Console.WriteLine("\nYour King card has been removed.\n");
                            thirteenGame.PrintList();
                        }

                        if (!thirteenGame.PairExists())
                            pairExists = false;

                        else
                        {
                            Console.Write("\nThere's a pair of 13 in your list. Pick two cards.");
                            thirteenGame.SelectTwoCards(ref card1, ref card2);
                            if (thirteenGame.isValidSelection(card1, card2))
                                thirteenGame.replaceCards(card1, card2);

                            pairExists = thirteenGame.PairExists();

                            if (resetGame())
                                isGameReset = true;

                            if (isGameReset != true && forfeitGame())
                                isForfeit = true;

                            if (thirteenGame.hasWon())
                                hasWon = true;
                        }


                    } while (pairExists == true && isForfeit == false && hasWon == false);

                    if (pairExists == false)
                    {
                        Console.WriteLine("\nThere's no possible combination. You have lost the game!\nYour score is "
                                      + thirteenGame.Score + " Please select the game you would like to play next" +
                                      " or enter option 4 to exit\n");
                    }

                    if (isForfeit == true)
                    {
                        Console.WriteLine("\nYou have forfeited on this game. Your score is " + thirteenGame.Score +
                                          "\nPlease select the game you would like to play next" +
                                          " or enter option 4 to exit\n");
                    }

                    if (hasWon == true)
                    {
                        Console.WriteLine("\nCONGRATULATION, you just won this game." +
                                          "\nPlease select the game you would like to play next" +
                                          " or enter option 4 to exit\n");
                        gameWon++;
                    }
                }

            } while (input != 4);

            // final output
            Console.WriteLine("Thank you so much for playing. " +
                              "\nYou have won " + gameWon + " games.");    
        }

        // This function prints a menu
        static public void PrintMenu()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("WELCOME TO THE BOARD GAME");
            Console.WriteLine("-------------------------\n");
            Console.WriteLine("Select the game you would like to play\n");

            Console.Write("1. Play the TensBoard Game \n" +
                          "2. Play the ElevensBoard Game\n" +
                          "3. Play the ThirteensBoard Game\n" +
                          "4. Quit \n\n" +
                          "Enter your option : ");
        }

        // This function asks the user 
        static public bool resetGame()
        {
            string userChoice;

            Console.Write("Would you like to reset the game ? 'Y' = Yes / 'N' = No : ");
            userChoice = Console.ReadLine();

            while (!(userChoice == "Y" || userChoice == "y" || userChoice == "n" || userChoice == "N"))
            {
                Console.WriteLine("You have entered the wrong input !");
                Console.WriteLine("Would you like to reset the game ?");
                Console.Write("Please enter 'Y' for Yes or 'N' for No : ");

                userChoice = Console.ReadLine();
            }

            if (userChoice == "Y" || userChoice == "y")
                return true;

            return false;
        }

        static public bool forfeitGame()
        {
            string userChoice;

            Console.Write("Would you like to forfeit the game ? 'Y' = Yes / 'N' = No : ");
            userChoice = Console.ReadLine();

            while (!(userChoice == "Y" || userChoice == "y" || userChoice == "n" || userChoice == "N"))
            {
                Console.WriteLine("You have entered the wrong input !");
                Console.WriteLine("Would you like to forfeit the game ?");
                Console.Write("Please enter 'Y' for Yes or 'N' for No : ");

                userChoice = Console.ReadLine();
            }

            if (userChoice == "Y" || userChoice == "y")
                return true;

            return false;
        }    
    }
}

