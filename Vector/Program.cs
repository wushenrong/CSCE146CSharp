/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace Vector;

internal class Program {
  public static void Main() {
    Console.WriteLine("Vector Operations Program");

    while (true) {
      Console.WriteLine("Please make a selection:");
      Console.WriteLine("Enter A to add 2 vectors");
      Console.WriteLine("Enter S to subtract 2 vectors");
      Console.WriteLine("Enter M to find the magnitude of a vector");
      Console.WriteLine("Enter Q to quit");

      string input = Console.ReadLine();

      if (input.Equals("A", StringComparison.OrdinalIgnoreCase)) {
        Console.WriteLine("Enter the size of the vector:");
        int vectorSize = GetVectorSize();

        Console.WriteLine("Enter values for the first vector:");
        double[] vector1 = CreateVector(vectorSize);
        Console.WriteLine("Enter values for the second vector:");
        double[] vector2 = CreateVector(vectorSize);

        double[] output = AddVectors(vector1, vector2);

        Console.WriteLine(VectorToString(vector1));
        Console.WriteLine("+");
        Console.WriteLine(VectorToString(vector2));
        Console.WriteLine("=");
        Console.WriteLine(VectorToString(output));
      } else if (input.Equals("S", StringComparison.OrdinalIgnoreCase)) {
        Console.WriteLine("Enter the size of the vectors:");
        int vectorSize = GetVectorSize();

        Console.WriteLine("Enter values for the first vector:");
        double[] vector1 = CreateVector(vectorSize);
        Console.WriteLine("Enter values for the second vector:");
        double[] vector2 = CreateVector(vectorSize);

        double[] output = SubtractVectors(vector1, vector2);

        Console.WriteLine(VectorToString(vector1));
        Console.WriteLine("-");
        Console.WriteLine(VectorToString(vector2));
        Console.WriteLine("=");
        Console.WriteLine(VectorToString(output));
      } else if (input.Equals("M", StringComparison.OrdinalIgnoreCase)) {
        Console.WriteLine("Enter the size of the vector:");
        int vectorSize = GetVectorSize();

        Console.WriteLine("Enter values for the vector:");
        double[] vector = CreateVector(vectorSize);

        double output = FindVectorMagnitude(vector);

        Console.WriteLine("The magnitude is: " + output);
      } else if (input.Equals("Q", StringComparison.OrdinalIgnoreCase)) {
        Console.WriteLine("Goodbye");
        break;
      } else {
        Console.WriteLine("Error: Invalid selection. Please try again");
      }

      Console.WriteLine();
    }
  }

  public static int GetVectorSize() {
    int vectorSize;

    while (!int.TryParse(Console.ReadLine(), out vectorSize) && vectorSize <= 0) {
      Console.WriteLine("Error: Invalid size. Please try again");
    }

    return vectorSize;
  }

  public static double[] CreateVector(int vectorSize) {
    double[] vector = new double[vectorSize];

    for (int i = 0; i < vector.Length; i++) {
      double value;

      while (!double.TryParse(Console.ReadLine(), out value)) {
        Console.WriteLine("Error: Invalid value. Please try again");
      }

      vector[i] = value;
    }

    return vector;
  }

  public static double[] AddVectors(double[] vector1, double[] vector2) {
    double[] output = new double[vector1.Length];

    for (int i = 0; i < output.Length; i++) {
      output[i] = vector1[i] + vector2[i];
    }

    return output;
  }

  public static double[] SubtractVectors(double[] vector1, double[] vector2) {
    double[] output = new double[vector1.Length];

    for (int i = 0; i < output.Length; i++) {
      output[i] = vector1[i] - vector2[i];
    }

    return output;
  }

  public static double FindVectorMagnitude(double[] vector) {
    double magnitude = 0.0;

    foreach (double compoent in vector) {
      magnitude += Math.Pow(compoent, 2);
    }

    return Math.Sqrt(magnitude);
  }

  public static string VectorToString(double[] vector) {
    StringBuilder output = new("<");

    for (int i = 0; i < vector.Length; i++) {
      output.Append(vector[i]);

      if (i < vector.Length - 1) {
        output.Append(", ");
      }
    }

    return output.Append('>').ToString();
  }
}
