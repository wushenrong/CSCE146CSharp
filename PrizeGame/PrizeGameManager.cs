namespace PrizeGame;

public class PrizeGameManager {
  public const int DEFAULT_PRIZE_SIZE = 20;
  public const int NUMBER_OF_GAME_PRIZES = 5;
  public const double PRICE_TOLERANCE = 1300;

  private readonly Random _rng = new(0);

  private Prize[] _prizes;
  private readonly Prize[] _gamePrizes = new Prize[NUMBER_OF_GAME_PRIZES];

  public PrizeGameManager() {
    Init(DEFAULT_PRIZE_SIZE);
  }

  public PrizeGameManager(int prizeSize) {
    Init(prizeSize);
  }

  public void Init(int prizeSize) {
    _prizes = prizeSize >= 1 ? new Prize[prizeSize] : new Prize[DEFAULT_PRIZE_SIZE];
  }

  public void AddPrize(Prize prize) {
    for (int i = 0; i < _prizes.Length; i++) {
      if (_prizes[i] is null) {
        _prizes[i] = prize;
        break;
      }
    }
  }

  public void NewGame() {
    int i = 0;

    while (i < _gamePrizes.Length) {
      int gamePrize = _rng.Next(_prizes.Length);

      if (_prizes[gamePrize] is not null || IsGamePrizeSelected(_prizes[gamePrize])) {
        continue;
      }

      _gamePrizes[i] = _prizes[gamePrize];
      i++;
    }
  }

  public double GetTotalPrizePrice() {
    double totalPrizePrice = 0.0;

    foreach (Prize prize in _gamePrizes) {
      totalPrizePrice += prize.Price;
    }

    return totalPrizePrice;
  }

  public bool CheckPriceGuess(double guess) {
    double totalPrizePrice = GetTotalPrizePrice();

    return guess >= totalPrizePrice - PRICE_TOLERANCE && guess <= totalPrizePrice;
  }

  public void PrintGamePrizes() {
    foreach (Prize prize in _gamePrizes) {
      Console.WriteLine(prize.Name);
    }
  }

  public void ReadPrizeList(string filename) {
    IEnumerable<string> lines = File.ReadLines(filename);

    Init(lines.Count());

    foreach (string line in lines) {
      string[] splitLines = line.Split(Prize.DELIMITER);

      if (splitLines.Length != Prize.NUMBER_OF_FIELDS) {
        continue;
      }

      string prizeName = splitLines[0];
      double prizePrice = double.Parse(splitLines[1]);

      AddPrize(new(prizeName, prizePrice));
    }
  }

  private bool IsGamePrizeSelected(Prize gamePrize) {
    foreach (Prize prize in _gamePrizes) {
      if (prize.Equals(gamePrize)) {
        return true;
      }
    }

    return false;
  }
}
