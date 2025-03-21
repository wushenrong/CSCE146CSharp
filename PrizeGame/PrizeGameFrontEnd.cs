/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace PrizeGame;

internal class Program {
  public static readonly PrizeGameManager GameManager = new();

  private static void Main() {
    PrintGreetings();
    GetPrizeListFile();

    bool quit = false;

    while (!quit) {
      PrintChoices();

      int choice;

      while (!int.TryParse(Console.ReadLine(), out choice)) {
        Console.WriteLine("Sorry that is not a valid choice. Please try again");
      }

      switch (choice) {
        case 1:
          NewGame();
          break;

        case 2:
          quit = true;
          break;

        default:
          Console.WriteLine("Sorry that is not a valid choice.");
          break;
      }
    }

    Console.WriteLine("Goodbye!");
  }

  public static void PrintGreetings() {
    Console.WriteLine("Welcome to the showcase showdown!");
  }

  public static void PrintChoices() {
    Console.WriteLine("What would like to do:");
    Console.WriteLine("Enter 1 for a new game.");
    Console.WriteLine("Enter 2 to exit.");
  }

  public static void NewGame() {
    GameManager.NewGame();

    Console.WriteLine(
        $"Your goal for this game is to guess the total price of {PrizeGameManager.NUMBER_OF_GAME_PRIZES} prizes without going over and within {PrizeGameManager.PRICE_TOLERANCE} of its actual price.");
    Console.WriteLine("Here are your " + PrizeGameManager.NUMBER_OF_GAME_PRIZES + " prizes:");

    GameManager.PrintGamePrizes();

    Console.WriteLine(
        $"Enter your guess for the price of the {PrizeGameManager.NUMBER_OF_GAME_PRIZES} prizes:");

    double guess;

    while (!double.TryParse(Console.ReadLine(), out guess)) {
      Console.WriteLine("Sorry that is not a valid guess. Please try again");
    }

    if (GameManager.CheckPriceGuess(guess)) {
      Console.WriteLine("Congratulations, you win!!!");
    } else {
      Console.WriteLine("Sorry you lose.");
    }

    double totalPrizePrice = GameManager.GetTotalPrizePrice();
    Console.WriteLine($"The actual price of the 5 prizes is {totalPrizePrice}");
  }

  public static void GetPrizeListFile() {
    Console.WriteLine("Please enter the filename of the prize list for this game:");
    string prizeListFile = Console.ReadLine();

    GameManager.ReadPrizeList("./" + prizeListFile);
  }
}
