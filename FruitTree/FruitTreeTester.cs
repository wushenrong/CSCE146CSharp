/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace FruitTree;

internal class FruitTreeTester {
  public const string FRUIT_TYPE_TO_DELETE = Fruit.TYPE_APPLE;
  public const double FRUIT_WEIGHT_TO_DELETE = 0.485_985_341_217_072_8;

  public static readonly LinkedBinarySearchTree<Fruit> FruitTree = new();

  public static void Main() {
    Console.WriteLine("Welcome to the fruit tree!");

    ReadFruitFile();
    PrintInOrder();
    PrintPreOrder();
    PrintPostOrder();
    DeleteFruit();
  }

  public static void ReadFruitFile() {
    Console.WriteLine("Please enter the filename for a Fruit File");
    string? filename = Console.ReadLine();

    while (filename is null) {
      Console.WriteLine("Error getting filename. Please try again");
      filename = Console.ReadLine();
    }

    foreach (string line in File.ReadLines(filename)) {
      string[] fields = line.Split(Fruit.DELIMITER);

      if (fields.Length != Fruit.NUMBER_OF_FIELDS) {
        continue;
      }

      string fruitType = fields[0];
      double fruitWeight = double.Parse(fields[1]);

      FruitTree.Add(new Fruit(fruitType, fruitWeight));
    }
  }

  public static void PrintInOrder() {
    Console.WriteLine("Printing the in-order traversal");
    FruitTree.PrintInOrder();
    Console.WriteLine();
  }

  public static void PrintPreOrder() {
    Console.WriteLine("Printing the pre-order traversal");
    FruitTree.PrintPreOrder();
    Console.WriteLine();
  }

  public static void PrintPostOrder() {
    Console.WriteLine("Printing the post-order traversal");
    FruitTree.PrintPostOrder();
    Console.WriteLine();
  }

  public static void DeleteFruit() {
    Console.WriteLine($"Deleting: {FRUIT_TYPE_TO_DELETE}{Fruit.DELIMITER}{FRUIT_WEIGHT_TO_DELETE}");
    FruitTree.Remove(new Fruit(FRUIT_TYPE_TO_DELETE, FRUIT_WEIGHT_TO_DELETE));
    PrintInOrder();
  }
}
