namespace SheepScheduler;

public class Sheep : IComparable<Sheep> {
  public const string DELIMITER = "\t";
  public const int NUMBER_OF_FIELDS = 3;

  public const string DEFAULT_NAME = "unknown";

  public string Name { get; set => field = value ?? DEFAULT_NAME; }
  public int ShearingTime { get; set => field = value >= 1 ? value : 1; }
  public int ArrivalTime { get; set => field = value >= 0 ? value : 0; }

  public Sheep() {
    Name = DEFAULT_NAME;
    ShearingTime = 1;
    ArrivalTime = 0;
  }

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
