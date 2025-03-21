/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace Labs;

public class WordHelper {
  public static string[] SortByVowels(string[] words) {
    string[] sortedWords = new string[words.Length];
    Array.Copy(words, sortedWords, words.Length);

    bool hasSwapped;

    do {
      hasSwapped = false;

      for (int i = 0; i < sortedWords.Length - 1; i++) {
        if (CountVowels(sortedWords[i]) > CountVowels(sortedWords[i + 1])) {
          (sortedWords[i + 1], sortedWords[i]) = (sortedWords[i], sortedWords[i + 1]);
          hasSwapped = true;
        }
      }
    }
    while (hasSwapped);

    return sortedWords;
  }

  public static string[] SortByConsonants(string[] words) {
    string[] sortedWords = new string[words.Length];
    Array.Copy(words, sortedWords, words.Length);

    bool hasSwapped;

    do {
      hasSwapped = false;

      for (int i = 0; i < sortedWords.Length - 1; i++) {
        if (CountConsonants(sortedWords[i]) > CountConsonants(sortedWords[i + 1])) {
          (sortedWords[i + 1], sortedWords[i]) = (sortedWords[i], sortedWords[i + 1]);
          hasSwapped = true;
        }
      }
    }
    while (hasSwapped);

    return sortedWords;
  }

  public static string[] SortByLength(string[] words) {
    string[] sortedWords = new string[words.Length];
    Array.Copy(words, sortedWords, words.Length);

    bool hasSwapped;

    do {
      hasSwapped = false;
      for (int i = 0; i < sortedWords.Length - 1; i++) {
        if (sortedWords[i].Length > sortedWords[i + 1].Length) {
          (sortedWords[i + 1], sortedWords[i]) = (sortedWords[i], sortedWords[i + 1]);
          hasSwapped = true;
        }
      }
    }
    while (hasSwapped);

    return sortedWords;
  }

  private static int CountVowels(string word) {
    int count = 0;

    foreach (char character in word) {
      if (IsCharVowel(character)) {
        count++;
      }
    }

    return count;
  }

  private static int CountConsonants(string word) {
    int count = 0;

    foreach (char character in word) {
      if (!IsCharVowel(character)) {
        count++;
      }
    }

    return count;
  }

  private static bool IsCharVowel(char character) {
    return character == 'a'
        || character == 'e'
        || character == 'i'
        || character == 'o'
        || character == 'u'
        || character == 'y';
  }
}
