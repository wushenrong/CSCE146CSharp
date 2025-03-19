namespace SheepScheduler;

public class Sheep : IComparable<Sheep> {
  public const string DELIMITER = "\t";
  public const int NUMBER_OF_FIELDS = 3;

  public const string DEFAULT_NAME = "unknown";
  public const int DEFAULT_SHEARING_TIME = 1;
  public const int DEFAULT_ARRIVAL_TIME = 0;

  public string Name { get; set => field = value ?? DEFAULT_NAME; }
  public int ShearingTime {
    get;
    set => field = value >= DEFAULT_SHEARING_TIME ? value : DEFAULT_SHEARING_TIME;
  }
  public int ArrivalTime {
    get;
    set => field = value >= DEFAULT_ARRIVAL_TIME ? value : DEFAULT_ARRIVAL_TIME;
  }

  public Sheep() : this(DEFAULT_NAME, DEFAULT_SHEARING_TIME, DEFAULT_ARRIVAL_TIME) { }

  public Sheep(string name, int shearingTime, int arrivalTime) {
    Name = name;
    ShearingTime = shearingTime;
    ArrivalTime = arrivalTime;
  }

  public override string? ToString() {
    return $"Name: {Name}, Shear Time: {ShearingTime}, Arrival Time: {ArrivalTime}";
  }

  public int CompareTo(Sheep? other) {
    return other is null || ShearingTime < other.ShearingTime
      ? -1
      : ShearingTime > other.ShearingTime ? 1 : Name.CompareTo(other.Name);
  }
}
