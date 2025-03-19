namespace Labs.Lab08;

public class MinHeap<T> where T : IComparable<T> {
  public const int DEFAULT_SIZE = 64;

  private T[]? _heap;
  private int _lastIndex;

  public MinHeap() {
    Init(DEFAULT_SIZE);
  }

  public MinHeap(int size) {
    Init(size);
  }

  public void Init(int size) {
    _heap = size >= 2 ? new T[size] : new T[DEFAULT_SIZE];
    _lastIndex = 0;
  }

  public void Add(T data) {
    if (_heap is null) {
      return;
    }

    if (_lastIndex >= _heap.Length) {
      return;
    }

    _heap[_lastIndex] = data;
    BubbleUp();
    _lastIndex++;
  }

  public T? Remove() {
    if (_lastIndex <= 0 || _heap is null) {
      return default;
    }

    T ret = _heap[0];
    _heap[0] = _heap[_lastIndex - 1];
    _lastIndex--;

    BubbleDown();

    return ret;
  }

  public T? Peek() => _heap is null ? default : _heap[0];

  public void Print() {
    if (_heap is null) {
      return;
    }

    for (int i = 0; i < _lastIndex; i++) {
      Console.WriteLine(_heap[i]);
    }
  }

  private void BubbleUp() {
    if (_heap is null) {
      return;
    }

    int index = _lastIndex;

    while (index > 0 && _heap[ParentIndex(index)].CompareTo(_heap[index]) > 0) {
      (_heap[index], _heap[ParentIndex(index)]) = (_heap[ParentIndex(index)], _heap[index]);
      index = ParentIndex(index);
    }
  }

  private void BubbleDown() {
    if (_heap is null) {
      return;
    }

    int index = 0;

    while (LeftIndex(index) < _lastIndex) {
      int smallestIndex = LeftIndex(index);

      if (RightIndex(index) < _lastIndex
          && _heap[LeftIndex(index)].CompareTo(_heap[RightIndex(index)]) > 0) {
        smallestIndex = RightIndex(index);
      }

      if (_heap[index].CompareTo(_heap[smallestIndex]) > 0) {
        (_heap[smallestIndex], _heap[index]) = (_heap[index], _heap[smallestIndex]);
      } else {
        break;
      }

      index = smallestIndex;
    }
  }

  private static int ParentIndex(int index) => (index - 1) / 2;

  private static int LeftIndex(int index) => index * 2 + 1;

  private static int RightIndex(int index) => index * 2 + 2;
}
