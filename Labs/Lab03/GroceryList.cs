namespace Labs.Lab03;

public class GroceryList {
  private ListNode? _head;
  private ListNode? _current;
  private ListNode? _previous;

  public GroceryList() {
    _head = new ListNode();
    _current = _head;
    _previous = null;
  }

  public void GoToNext() {
    if (_current is not null) {
      _previous = _current;
      _current = _current.Link;
    }
  }

  public GroceryItem? GetCurrent() {
    return _current?.Data;
  }

  public void SetCurrent(GroceryItem data) {
    if (_current is not null) {
      _current.Data = data;
    }
  }

  public void AddItem(GroceryItem data) {
    _head ??= new ListNode();

    if (_head.Data is null) {
      _head.Data = data;
      return;
    }

    ListNode? temp = _head;

    while (temp.Link is not null) {
      temp = temp.Link;
    }

    temp.Link = new ListNode(data, null);
  }

  public void AddItemAfterCurrent(GroceryItem data) {
    if (_head == null || _head.Data == null || _current == null) {
      return;
    }

    _current.Link = new ListNode(data, _current.Link);
  }

  public void RemoveCurrent() {
    if (_current == null) {
      return;
    }

    if (_current == _head) {
      _head = _head.Link;
      _current = _head;
      return;
    }

    if (_previous is not null) {
      _previous.Link = _current.Link;
    }

    _current = _current.Link;
  }

  public void ShowList() {
    for (ListNode? temp = _head; temp is not null; temp = temp.Link) {
      Console.WriteLine(temp.Data);
    }
  }

  public bool Contains(GroceryItem data) {
    for (ListNode? temp = _head; temp is not null; temp = temp.Link) {
      if (temp.Data is not null && temp.Data.Equals(data)) {
        return true;
      }
    }

    return false;
  }

  public double TotalCost() {
    double totalCost = 0.0;

    for (ListNode? temp = _head; temp is not null; temp = temp.Link) {
      if (temp.Data is not null) {
        totalCost += temp.Data.Value;
      }
    }

    return totalCost;
  }

  private class ListNode {
    public GroceryItem? Data;
    public ListNode? Link;

    public ListNode() {
      Data = null;
      Link = null;
    }

    public ListNode(GroceryItem? data, ListNode? link) {
      this.Data = data;
      this.Link = link;
    }
  }
}
