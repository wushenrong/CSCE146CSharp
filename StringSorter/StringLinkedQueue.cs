/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace StringSorter;

class StringLinkedQueue {
  private StringNode _head;
  private StringNode _tail;

  public StringLinkedQueue() {
    _head = null;
    _tail = null;
  }

  public void Enqueue(string data) {
    StringNode temp = new(data, null);

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

  public string Dequeue() {
    if (_head is null) {
      return null;
    }

    string data = _head.Data;
    _head = _head.Link;
    return data;
  }

  public int CountStrings() {
    int count = 0;

    for (StringNode temp = _head; temp is not null; temp = temp.Link) {
      count++;
    }

    return count;
  }

  private class StringNode(string data, StringNode link) {
    public string Data = data;
    public StringNode Link = link;
  }
}
