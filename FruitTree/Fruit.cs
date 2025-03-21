/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace FruitTree;

public class Fruit : IComparable<Fruit> {
  public const int NUMBER_OF_FIELDS = 2;
  public const string DELIMITER = "\t";

  public const string TYPE_APPLE = "Apple";
  public const string TYPE_ORANGE = "Orange";
  public const string TYPE_BANANA = "Banana";
  public const string TYPE_KIWI = "Kiwi";
  public const string TYPE_TOMATO = "Tomato";

  public const double DEFAULT_VALUE = 1.0;

  public string Type { get; set => field = IsTypeValid(value) ? value : TYPE_APPLE; }
  public double Weight { get; set => field = value > 0.0 ? value : DEFAULT_VALUE; }

  public Fruit() : this(TYPE_APPLE, DEFAULT_VALUE) { }

  public Fruit(string type, double weight) {
    Type = type;
    Weight = weight;
  }

  private static bool IsTypeValid(string fruitType) {
    return fruitType == TYPE_APPLE
        || fruitType == TYPE_ORANGE
        || fruitType == TYPE_BANANA
        || fruitType == TYPE_KIWI
        || fruitType == TYPE_TOMATO;
  }

  public override string? ToString() {
    return $"Type: {Type}{DELIMITER}Weight: {Weight}";
  }

  public int CompareTo(Fruit? other) {
    return other is null || Weight < other.Weight
      ? -1
      : Weight > other.Weight ? 1 : Type.CompareTo(other.Type);
  }

  public override bool Equals(object? obj) {
    return obj is Fruit fruit &&
           Type == fruit.Type &&
           Weight == fruit.Weight;
  }

  public override int GetHashCode() => HashCode.Combine(Type, Weight);
}
