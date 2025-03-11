namespace Labs.Lab03;

public class GroceryItem {
  public string Name { get; set => field = value ?? "none"; }

  public double Value {
    get;
    set => field = value >= 0.0 ? value : 0.0;
  }

  public GroceryItem() : this("none", 0.0) { }

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
