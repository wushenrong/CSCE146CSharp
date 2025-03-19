
namespace VideoGameDatabase;

public class VideoGame {
  public const string DEFAULT_GAME_VALUE = "unknown";
  public const string DELIMITER = "\t";
  public const int NUMBER_OF_FIELDS = 2;

  public string Name { get; set => field = value ?? DEFAULT_GAME_VALUE; }
  public string Console { get; set => field = value ?? DEFAULT_GAME_VALUE; }

  public VideoGame() : this(DEFAULT_GAME_VALUE, DEFAULT_GAME_VALUE) { }

  public VideoGame(string name, string console) {
    Name = name;
    Console = console;
  }

  public override string? ToString() => $"{Name}{DELIMITER}{Console}";

  public override bool Equals(object? obj) {
    return obj is VideoGame game &&
           Name == game.Name &&
           Console == game.Console;
  }

  public override int GetHashCode() => HashCode.Combine(Name, Console);
}
