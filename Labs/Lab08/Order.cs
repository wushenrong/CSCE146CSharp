namespace Labs.Lab08;

public class Order : IComparable<Order> {
  public const String DEFAULT_VALUE = "none";

  public string Customer { get; set => field = value ?? DEFAULT_VALUE; }
  public string FoodOrder { get; set => field = value ?? DEFAULT_VALUE; }
  public int CookingTime { get; set => field = value >= 1 ? value : 1; }
  public int ArrivalTime { get; set => field = value >= 0 ? value : 0; }
  public int CookingTimeLeft { get; set => field = value >= 1 ? value : 1; }

  public Order() : this(DEFAULT_VALUE, DEFAULT_VALUE, 1, 0) { }

  public Order(string customer, string foodOrder, int cookingTime, int arrivalTime) {
    Customer = customer;
    FoodOrder = foodOrder;
    CookingTime = cookingTime;
    ArrivalTime = arrivalTime;
    CookingTimeLeft = cookingTime;
  }

  public void CookForOneMinute() => CookingTimeLeft--;

  public bool IsDone() => CookingTimeLeft == 0;

  public override string? ToString() {
    return $"Customer: {Customer}, Order: {FoodOrder}, Cooking Time Left: {CookingTimeLeft}";
  }

  public int CompareTo(Order? other) {
    return other is null
      || CookingTime < other.CookingTime ? -1
      : CookingTime > other.CookingTime ? 1 : 0;
  }
}
