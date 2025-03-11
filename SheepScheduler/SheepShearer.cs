namespace SheepScheduler;

using Labs.Lab08;

public class SheepShearer {
  private readonly MinHeap<Sheep> _sheep;
  private Sheep? _currentSheep;
  private int _timeLeftToShear;

  public SheepShearer() {
    _sheep = new();
    _currentSheep = null;
    _timeLeftToShear = 0;
  }

  public void AddSheep(Sheep data) {

    if (_currentSheep == null) {
      _currentSheep = data;
      _timeLeftToShear = _currentSheep.ShearingTime;
      return;
    }

    _sheep.Add(data);
  }

  public Sheep? ShearSheep() {
    _timeLeftToShear--;

    if (_timeLeftToShear == 0) {
      Sheep? ret = _currentSheep;
      _currentSheep = _sheep.Remove();

      if (_currentSheep is not null) {
        _timeLeftToShear = _currentSheep.ShearingTime;
      }

      return ret;
    }

    return null;
  }

  public bool IsDone() {
    return _currentSheep is null;
  }
}
