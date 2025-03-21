/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

const int array_size = 10;

int[] numbers = new int[array_size];

Console.WriteLine($"Enter {array_size} numbers and I will sort them:");

for (int i = 0; i < numbers.Length; i++) {
  Console.WriteLine($"Enter value {i + 1}:");

  while (!int.TryParse(Console.ReadLine(), out numbers[i])) {
    Console.WriteLine("Error: Invalid input.");
    Console.WriteLine($"Enter value {i + 1}:");
  }

  Console.WriteLine();
}

bool hasSwapped;

do {
  hasSwapped = false;

  for (int i = 0; i < numbers.Length - 1; i++) {
    if (numbers[i] > numbers[i + 1]) {
      (numbers[i + 1], numbers[i]) = (numbers[i], numbers[i + 1]);
      hasSwapped = true;
    }
  }
} while (hasSwapped);

foreach (int number in numbers) {
  Console.WriteLine(number);
}
