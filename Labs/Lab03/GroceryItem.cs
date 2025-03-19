namespace Labs.Lab03;

public class GroceryItem {
  public const string DEFAULT_NAME = "none";
  public const double DEFAULT_VALUE = 0.0;

  public string Name { get; set => field = value ?? DEFAULT_NAME; }

  public double Value {
    get;
    set => field = value >= DEFAULT_VALUE ? value : DEFAULT_VALUE;
  }

  public GroceryItem() : this(DEFAULT_NAME, DEFAULT_VALUE) { }

  public GroceryItem(string name, double value) {
    Name = name;
    Value = value;
  }

  public override bool Equals(object? obj) {
    return obj is GroceryItem item &&
           Name == item.Name &&
           Value == item.Value;
  }

  public override int GetHashCode() {
    return HashCode.Combine(Name, Value);
  }
}
