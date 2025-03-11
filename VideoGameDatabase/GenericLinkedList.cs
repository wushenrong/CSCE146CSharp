namespace VideoGameDatabase;

public class GenericLinkedList<T> {
  private Node? _head;
  private Node? _current;
  private Node? _previous;

  public GenericLinkedList() {
    _head = null;
    _current = null;
    _previous = null;
  }

  public void Add(T data) {
    if (_head is null) {
      _head = new Node(data, null);
      _current = _head;
      return;
    }

    Node temp = _head;

    while (temp.Link is not null) {
      temp = temp.Link;
    }

    temp.Link = new Node(data, null);
  }

  public void Next() {
    if (_current is not null) {
      _previous = _current;
      _current = _current.Link;
    }
  }

  public bool HasNext() {
    return _current is not null;
  }

  public T? GetCurrent() {
    return _current == null ? default : _current.Data;
  }

  public void SetCurrent(T data) {
    if (_current is not null) {
      _current.Data = data;
    }
  }

  public void RemoveCurrent() {
    if (_current is null) {
      return;
    }

    if (_current == _head) {
      _head = _head.Link;
      _current = _head;
      _previous = null;
      return;
    }

    if (_previous is not null) {
      _previous.Link = _current.Link;
    }

    _current = _current.Link;
  }

  public void ResetCurrent() {
    _current = _head;
    _previous = null;
  }

  public bool Contains(T data) {
    for (Node? temp = _head; temp != null; temp = temp.Link) {
      if (temp.Data is not null && temp.Data.Equals(data)) {
        return true;
      }
    }

    return false;
  }

  private class Node(T data, Node? link) {
    public T Data = data;
    public Node? Link = link;
  }
}
