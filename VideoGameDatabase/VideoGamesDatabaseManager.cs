namespace VideoGameDatabase;

internal class VideoGamesDatabaseManager {
  public static readonly VideoGamesDatabase Database = new();

  public static void Main() {
    PrintGreetings();

    bool quit = false;

    while (!quit) {
      PrintChoices();

      string? choice = Console.ReadLine();

      if (choice is null) {
        Console.WriteLine("Error: Unable to read input");
        Console.WriteLine("Please try again");
        continue;
      }

      switch (choice) {
        case "quit":
          quit = true;
          break;

        case "load":
          ReadVideoGamesCollectionFile();
          break;

        case "search":
          SearchVideoGamesDatabase();
          break;

        case "print":
          PrintVideoGamesResult();
          break;

        default:
          Console.WriteLine("Sorry that is not a valid option, please try again:");
          break;
      }
    }

    Console.WriteLine("Goodbye!");
  }

  public static void PrintGreetings() {
    Console.WriteLine("Welcome to the Video Games Database Manager!");
  }

  public static void PrintChoices() {
    Console.WriteLine();
    Console.WriteLine("Enter 'load' to load a video games database.");
    Console.WriteLine("Enter 'search' to search the database.");
    Console.WriteLine("Enter 'print' to print current results.");
    Console.WriteLine("Enter 'quit' to quit the database.");
  }

  public static void SearchVideoGamesDatabase() {
    Console.WriteLine();
    Console.WriteLine("Enter the name of the game or '*' for all games:");
    string? gameQuery = Console.ReadLine();

    Console.WriteLine("Enter the name of the console or '*' for all consoles:");
    string? consoleQuery = Console.ReadLine();

    if (!Database.SearchVideoGames(gameQuery, consoleQuery)) {
      Console.WriteLine("Error: Something has gone wrong with the search function.");
      Console.WriteLine("Have you load a video game database yet?");
      return;
    }

    PrintVideoGamesResult();
  }

  public static void PrintVideoGamesResult() {
    Console.WriteLine();

    if (!Database.PrintVideoGamesSearchResults()) {
      Console.WriteLine("Error: No search result, please search for a game.");
      return;
    }

    Console.WriteLine();

    Console.WriteLine("Do you want to save the results to a file? Yes or No?");
    string? option = Console.ReadLine();

    while (true) {
      if (option is null) {
        Console.WriteLine("Error: Unable to read input");
        Console.WriteLine("Please try again");
        continue;
      }

      if (option.Equals("no", StringComparison.OrdinalIgnoreCase)) {
        return;
      }

      if (option.Equals("yes", StringComparison.OrdinalIgnoreCase)) {
        WriteVideoGamesSearchResults();
        return;
      }

      Console.WriteLine("Error: Invalid option, please type 'Yes' or 'No'.");
      option = Console.ReadLine();
    }
  }

  public static void ReadVideoGamesCollectionFile() {
    Console.WriteLine("Enter the file name of the video games database:");
    string? filename = Console.ReadLine();
    Database.ReadVideoGameCollectionFile("./" + filename);
  }

  public static void WriteVideoGamesSearchResults() {
    Console.WriteLine("Enter the name of the file to write results to:");
    string? filename = Console.ReadLine();

    bool append = PromptToAppendFile();

    if (!Database.WriteVideoGamesSearchResults("./" + filename, append)) {
      Console.WriteLine("Error: Failed to write search results to file.");
      Console.WriteLine("Have you search for a game yet?");
      return;
    }

    Console.WriteLine("Results written to " + filename);
  }

  private static bool PromptToAppendFile() {
    Console.WriteLine("Would you like to append to the file? Yes or No");
    string? option = Console.ReadLine();

    while (true) {
      if (option is null) {
        Console.WriteLine("Error: Unable to read input");
        Console.WriteLine("Please try again");
        continue;
      }

      if (option.Equals("no", StringComparison.OrdinalIgnoreCase)) {
        return false;
      }

      if (option.Equals("yes", StringComparison.OrdinalIgnoreCase)) {
        return true;
      }

      Console.WriteLine("Error: Invalid option, please type 'Yes' or 'No'.");
      option = Console.ReadLine();
    }
  }

}
