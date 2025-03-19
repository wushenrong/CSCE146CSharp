﻿
namespace PrizeGame;
public class Prize {
  public const string DEFAULT_NAME = "none";
  public const string DELIMITER = "\t";
  public const int NUMBER_OF_FIELDS = 2;

  public string Name { get; set => field = value ?? DEFAULT_NAME; }
  public double Price { get; set => field = value >= 0.0 ? value : 0.0; }

  public Prize() : this(DEFAULT_NAME, 0.0) { }

  public Prize(string name, double price) {
    Name = name;
    Price = price;
  }

  public override string ToString() => $"Prize: {Name} Price: {Price}";

  public override bool Equals(object obj) {
    return obj is Prize prize &&
           Name == prize.Name &&
           Price == prize.Price;
  }

  public override int GetHashCode() => HashCode.Combine(Name, Price);
}
