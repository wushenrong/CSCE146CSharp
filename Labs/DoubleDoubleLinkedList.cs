/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace Labs;

public class DoubleDoubleLinkedList {
  private DoubleNode? _head;
  private DoubleNode? _current;

  public DoubleDoubleLinkedList() {
    _head = null;
    _current = null;
  }

  public void Add(double data) {
    if (_head is null) {
      _head = new DoubleNode(data, null, null);
      _current = _head;
      return;
    }

    DoubleNode temp = _head;

    while (temp.NextLink is not null) {
      temp = temp.NextLink;
    }

    temp.NextLink = new DoubleNode(data, null, temp);
  }

  public void Remove(double data) {
    if (_head is null) {
      return;
    }

    DoubleNode? temp = _head;

    while (temp is not null) {
      if (temp.Data == data) {
        break;
      }

      temp = temp.NextLink;
    }

    if (temp is null) {
      return;
    }

    if (temp.PreviousLink is not null) {
      temp.PreviousLink.NextLink = temp.NextLink;
    }

    if (temp.NextLink is not null) {
      temp.NextLink.PreviousLink = temp.PreviousLink;
    }
  }

  public void GoToNext() {
    if (_current is null) {
      return;
    }

    _current = _current.NextLink;
  }

  public void GoToPrevious() {
    if (_current is null) {
      return;
    }

    _current = _current.PreviousLink;
  }

  public void Reset() {
    _current = _head;
  }

  public void GoToEnd() {
    if (_head is null) {
      _current = _head;
      return;
    }

    DoubleNode temp = _head;

    while (temp.NextLink is not null) {
      temp = temp.NextLink;
    }

    _current = temp;
  }

  public bool HasMore() {
    return _current is not null;
  }

  public void AddAfterCurrent(double data) {
    if (_current is null) {
      return;
    }

    DoubleNode? temp = _current.NextLink;

    _current.NextLink = new DoubleNode(data, temp, _current);

    if (temp is not null) {
      temp.PreviousLink = _current.NextLink;
    }
  }

  public void RemoveCurrent() {
    if (_current is null) {
      return;
    }

    if (_current == _head) {
      _head = _head.NextLink;

      if (_head is not null) {
        _head.PreviousLink = null;
      }

      _current = _head;
      return;
    }

    if (_current.NextLink is null) {
      _current = _current.PreviousLink;

      if (_current is not null) {
        _current.NextLink = null;
      }

      return;
    }

    if (_current.PreviousLink is not null) {
      _current.PreviousLink.NextLink = _current.NextLink;
    }

    _current.NextLink.PreviousLink = _current.PreviousLink;
    _current = _current.NextLink;
  }

  public double? GetCurrent() {
    return _current?.Data;
  }

  public void SetCurrent(double data) {
    if (_current is not null) {
      _current.Data = data;
    }
  }

  public void Print() {
    for (DoubleNode? temp = _head; temp is not null; temp = temp.NextLink) {
      Console.WriteLine(temp.Data);
    }
  }

  public bool Contains(double data) {
    for (DoubleNode? temp = _head; temp is not null; temp = temp.NextLink) {
      if (temp.Data == data) {
        return true;
      }
    }

    return false;
  }

  private class DoubleNode(double data, DoubleNode? nextLink, DoubleNode? previousLink) {
    public double Data = data;
    public DoubleNode? NextLink = nextLink;
    public DoubleNode? PreviousLink = previousLink;
  }
}
