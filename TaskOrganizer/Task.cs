namespace TaskOrganizer;

public class Task {
  public const string DELIMITER = "\t";
  public const int NUMBER_OF_FIELDS = 2;

  public const int NUMBER_OF_PRIORITIES = 5;
  public const int DEFAULT_PRIORITY = 4;
  public const string DEFAULT_ACTION = "none";

  public int Priority {
    get;
    set => field = value >= 0 && value < NUMBER_OF_PRIORITIES ? value : DEFAULT_PRIORITY;
  }
  public string Action { get; set => field = value ?? DEFAULT_ACTION; }

  public Task() : this(DEFAULT_PRIORITY, DEFAULT_ACTION) { }

  public Task(int priority, string action) {
    Priority = priority;
    Action = action;
  }

  public override string ToString() => $"{Priority}{DELIMITER}{Action}";

  public override bool Equals(object obj) {
    return obj is Task task &&
           Priority == task.Priority &&
           Action == task.Action;
  }

  public override int GetHashCode() => HashCode.Combine(Priority, Action);
}
