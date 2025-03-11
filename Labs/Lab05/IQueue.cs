namespace Labs.Lab05;

public interface IQueue<T> {
  void Enqueue(T data);

  T? Dequeue();

  T? Peek();

  void Print();
}
