/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace StringSorter;

internal class Program {
  public const string SORT_STRING = "sort";

  private static readonly StringLinkedQueue StringsQueue = new();

  public static void Main() {
    Console.WriteLine("Welcome to the Sort Sorter!");

    bool quit = false;
    while (!quit) {
      Console.WriteLine("Enter any number of strings and I will sort by 'sort'");
      Console.WriteLine("Just hit enter when you are done entering strings\n");

      while (true) {
        string input = Console.ReadLine();

        if (input.Equals("", StringComparison.Ordinal)) {
          break;
        }

        StringsQueue.Enqueue(input);
      }

      int numberOfStrings = StringsQueue.CountStrings();
      string[] sortedSortStrings = new string[numberOfStrings];

      for (int i = 0; i < numberOfStrings; i++) {
        sortedSortStrings[i] = StringsQueue.Dequeue();
      }

      SortSortStrings(sortedSortStrings);

      foreach (string sortedString in sortedSortStrings) {
        Console.WriteLine(sortedString);
      }

      quit = PromptToSortNewStrings();
    }
  }

  public static void SortSortStrings(string[] array) {
    QuickSortStrings(array, 0, array.Length - 1);
  }

  public static void QuickSortStrings(string[] array, int start, int end) {
    if (start >= end) {
      return;
    }

    int pivot = Partition(array, start, end);
    QuickSortStrings(array, start, pivot - 1);
    QuickSortStrings(array, pivot + 1, end);
  }

  public static int Partition(string[] array, int start, int end) {
    int pivot = CountSorts(array[end].ToLower());
    int i = start;

    for (int j = start; j <= end; j++) {
      if (CountSorts(array[j].ToLower()) < pivot) {
        (array[j], array[i]) = (array[i], array[j]);
        i++;
      }
    }

    (array[end], array[i]) = (array[i], array[end]);
    return i;
  }

  public static int CountSorts(string input) {
    int indexOfSort = input.IndexOf(SORT_STRING);

    return indexOfSort == -1 ? 0 : CountSorts(input[(indexOfSort + SORT_STRING.Length)..]) + 1;
  }

  public static bool PromptToSortNewStrings() {
    while (true) {
      Console.WriteLine("\nDo you want run sort more strings? Yes or No");
      string input = Console.ReadLine();

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
