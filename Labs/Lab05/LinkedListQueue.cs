namespace Labs.Lab05;

public class LinkedListQueue<T> : IQueue<T> {
  private Node? _head;
  private Node? _tail;

  public LinkedListQueue() {
    _head = null;
    _tail = null;
  }

  public void Enqueue(T data) {
    Node temp = new(data, null);

    if (_head is null) {
      _head = temp;
      _tail = _head;
      return;
    }

    if (_tail is not null) {
      _tail.Link = temp;
      _tail = _tail.Link;
    }
  }

  public T? Dequeue() {
    if (_head == null) {
      return default;
    }

    T data = _head.Data;
    _head = _head.Link;
    return data;
  }

  public T? Peek() => _head is null ? default : _head.Data;

  public void Print() {
    for (Node? temp = _head; temp is not null; temp = temp.Link) {
      Console.WriteLine(temp.Data);
    }
  }

  private class Node(T data, Node? link) {
    public T Data = data;
    public Node? Link = link;
  }
}
