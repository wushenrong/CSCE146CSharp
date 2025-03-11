namespace RobotSimulator;

internal class RobotSimulatorFrontEnd {
  private static RobotSimulator? s_simulator;

  public static void Main() {
    PrintGreetings();

    bool quit = false;

    while (!quit) {
      CreateNewSimulation();

      if (s_simulator is null) {
        Console.WriteLine("Error creating simulation. Exiting...");
        break;
      }

      bool simulationEnded = false;

      int status = s_simulator.StartSimulation();

      switch (status) {
        case -1:
          Console.WriteLine("Error: The Board is not initialized");
          simulationEnded = true;
          break;

        case 1:
          Console.WriteLine("Error: The Robot cannot be placed down on an Obstacle");
          simulationEnded = true;
          s_simulator.PrintBoard();
          break;

        default:
          s_simulator.PrintBoard();
          break;
      }

      while (!simulationEnded) {
        status = s_simulator.RunNextCommand();

        switch (status) {
          case -1:
            Console.WriteLine("Error: Board is not initialized or no Commands received");
            simulationEnded = true;
            break;

          case 1:
            Console.WriteLine("Error: The Robot crashed into an obstacle");
            simulationEnded = true;
            break;

          case 2:
            simulationEnded = true;
            break;

          default:
            s_simulator.PrintBoard();
            break;
        }
      }

      Console.WriteLine("Simulation End");
      quit = PromptForNewSimulation();
    }

    Console.WriteLine("Goodbye!");
  }

  public static void PrintGreetings() {
    Console.WriteLine("Welcome to the Robot Simulator");
  }

  public static void CreateNewSimulation() {
    s_simulator = new RobotSimulator();

    Console.WriteLine("Enter file name for the Board:");
    string? boardFile = Console.ReadLine();

    while (boardFile is null) {
      Console.WriteLine("Error: Could not read filename. Please try again");
      boardFile = Console.ReadLine();
    }

    s_simulator.ReadBoardFile(boardFile);

    Console.WriteLine("Enter file name for the Commands:");
    string? commandsFile = Console.ReadLine();

    while (commandsFile is null) {
      Console.WriteLine("Error: Could not read filename. Please try again");
      commandsFile = Console.ReadLine();
    }

    s_simulator.ReadCommandFile(commandsFile);
  }

  public static bool PromptForNewSimulation() {
    while (true) {
      Console.WriteLine("\nDo you want run another simulation? Yes or No");
      string? input = Console.ReadLine();

      if (input is null) {
        Console.WriteLine("Error reading input. Please try again");
        continue;
      }

      if (input.Equals("Yes", StringComparison.OrdinalIgnoreCase)) {
        return false;
      }

      if (input.Equals("No", StringComparison.OrdinalIgnoreCase)) {
        return true;
      }

      Console.WriteLine("Error: Invalid input.");
    }
  }
}
