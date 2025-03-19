namespace Labs.Lab05;

class Process {
  public string Name { get; set => field = value ?? "none"; }
  public double CompletionTime { get; set => field = value >= 0.0 ? value : 0.0; }

  public Process() : this("none", 0.0) { }

  public Process(string name, double completionTime) {
    Name = name;
    CompletionTime = completionTime;
  }

  public override string ToString() {
    return $"Process Name: {Name} Completion Time: {CompletionTime}";
  }
}
