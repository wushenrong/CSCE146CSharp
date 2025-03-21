/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace SheepScheduler;

using RobotSimulator;

internal class SheepScheduler {
  private static GenericLinkedQueue<Sheep>? s_sheepToBeSorted;
  private static GenericLinkedQueue<Sheep>? s_sheepSchedule;
  private static Sheep[]? s_sheepToBeScheduled;

  public static void Main() {
    PrintGreetings();

    bool quit = false;

    while (!quit) {
      PromptForSheep();
      PrepareSchedule();
      CreateSchedule();
      PrintSchedule();

      quit = PromptForNewSchedule();
    }

    Console.WriteLine("Goodbye");
  }

  public static void PrintGreetings() {
    Console.WriteLine("Welcome to the Sheep Shearing Scheduler!");
  }

  public static void PrintSchedule() {
    s_sheepSchedule?.Print();
  }

  public static void CreateSchedule() {
    s_sheepSchedule = new();

    SheepShearer sheepShearer = new();
    int currentTime = 0;
    int currentSheep = 0;

    if (s_sheepToBeScheduled is null) {
      Console.WriteLine("Error: No sheep are scheduled to be shared");
      return;
    }

    while (true) {
      while (currentSheep < s_sheepToBeScheduled.Length
          && currentTime == s_sheepToBeScheduled[currentSheep].ArrivalTime) {
        sheepShearer.AddSheep(s_sheepToBeScheduled[currentSheep]);
        currentSheep++;
      }

      if (sheepShearer.IsDone()) {
        break;
      }

      Sheep? shearedSheep = sheepShearer.ShearSheep();

      if (shearedSheep is not null) {
        s_sheepSchedule.Enqueue(shearedSheep);
      }

      currentTime++;
    }
  }

  public static void PrepareSchedule() {
    if (s_sheepToBeSorted is null) {
      Console.WriteLine("Error: There are no sheep to be shared");
      return;
    }

    int numberOfSheep = s_sheepToBeSorted.CountQueue();
    s_sheepToBeScheduled = new Sheep[numberOfSheep];

    for (int i = 0; i < numberOfSheep; i++) {
      Sheep? sheep = s_sheepToBeSorted.Dequeue();

      if (sheep is null) {
        continue;
      }

      s_sheepToBeScheduled[i] = sheep;
    }

    QuickSortSheepByArrivalTime(0, s_sheepToBeScheduled.Length - 1);
  }

  private static void QuickSortSheepByArrivalTime(int start, int end) {
    if (start >= end) {
      return;
    }

    int pivot = Partition(start, end);
    QuickSortSheepByArrivalTime(start, pivot - 1);
    QuickSortSheepByArrivalTime(pivot + 1, end);
  }

  private static int Partition(int start, int end) {
    if (s_sheepToBeScheduled is null) {
      Console.WriteLine("Error: There are no sheep to be shared");
      return -1;
    }

    int pivot = s_sheepToBeScheduled[end].ArrivalTime;
    int i = start;

    for (int j = start; j <= end; j++) {
      if (s_sheepToBeScheduled[j].ArrivalTime < pivot) {
        (s_sheepToBeScheduled[j], s_sheepToBeScheduled[i]) = (s_sheepToBeScheduled[i], s_sheepToBeScheduled[j]);
        i++;
      }
    }

    (s_sheepToBeScheduled[end], s_sheepToBeScheduled[i]) = (s_sheepToBeScheduled[i], s_sheepToBeScheduled[end]);
    return i;
  }

  public static void PromptForSheep() {
    Console.WriteLine("Please enter the filename for the sheep file: ");
    string? filename = Console.ReadLine();
    ReadSheepFile("./" + filename);
  }

  public static bool PromptForNewSchedule() {
    while (true) {
      Console.WriteLine("\nDo you want to create a new shearing schedule? Yes or No");
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

  public static void ReadSheepFile(string filename) {
    s_sheepToBeSorted = new();

    foreach (string line in File.ReadLines(filename)) {
      string[] fields = line.Split(Sheep.DELIMITER);

      if (fields.Length != Sheep.NUMBER_OF_FIELDS) {
        continue;
      }

      string sheepName = fields[0];
      int sheepShearTime = int.Parse(fields[1]);
      int sheepArrivalTime = int.Parse(fields[2]);
      s_sheepToBeSorted.Enqueue(new(sheepName, sheepShearTime, sheepArrivalTime));
    }
  }
}
