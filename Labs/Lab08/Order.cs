namespace Labs.Lab08;

public class Order : IComparable<Order> {
  public const string DEFAULT_VALUE = "none";
  public const int DEFAULT_COOKING_TIME = 1;
  public const int DEFAULT_ARRIVAL_TIME = 0;

  public string Customer { get; set => field = value ?? DEFAULT_VALUE; }
  public string FoodOrder { get; set => field = value ?? DEFAULT_VALUE; }
  public int CookingTime {
    get;
    set => field = value >= DEFAULT_COOKING_TIME ? value : DEFAULT_COOKING_TIME;
  }
  public int ArrivalTime {
    get;
    set => field = value >= DEFAULT_ARRIVAL_TIME ? value : DEFAULT_ARRIVAL_TIME;
  }
  public int CookingTimeLeft {
    get;
    set => field = value >= DEFAULT_COOKING_TIME ? value : DEFAULT_COOKING_TIME;
  }

  public Order() : this(DEFAULT_VALUE, DEFAULT_VALUE, DEFAULT_COOKING_TIME, DEFAULT_ARRIVAL_TIME) { }

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
