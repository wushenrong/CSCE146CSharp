namespace FruitTree;

public class LinkedBinarySearchTree<T> where T : IComparable<T> {
  private Node? _root;

  public void Add(T data) => _root = Add(_root, data);

  private static Node Add(Node? node, T data) {
    if (node is null) {
      node = new Node(data);
    } else if (data.CompareTo(node.Data) > 0) {
      node.RightChild = Add(node.RightChild, data);
    } else if (data.CompareTo(node.Data) < 0) {
      node.LeftChild = Add(node.LeftChild, data);
    }

    return node;
  }

  public void Remove(T data) => _root = Remove(_root, data);

  private static Node? Remove(Node? node, T data) {
    if (node is null) {
      return null;
    }

    if (data.CompareTo(node.Data) > 0) {
      node.RightChild = Remove(node.RightChild, data);
    } else if (data.CompareTo(node.Data) < 0) {
      node.LeftChild = Remove(node.LeftChild, data);
    } else {
      if (node.RightChild == null) {
        return node.LeftChild;
      }

      if (node.LeftChild == null) {
        return node.RightChild;
      }

      Node? temp = FindMinNode(node.RightChild);

      if (temp is not null) {
        node.Data = temp.Data;
      }

      node.RightChild = Remove(node.RightChild, data);
    }

    return node;
  }

  private static Node? FindMinNode(Node node) {
    return node is null ? null : node.LeftChild is null ? node : FindMinNode(node.LeftChild);
  }

  public bool Search(T data) => Search(_root, data);

  private static bool Search(Node? node, T data) {
    return node is not null && (data.CompareTo(node.Data) > 0
      ? Search(node.RightChild, data)
      : data.CompareTo(node.Data) >= 0 || Search(node.LeftChild, data));
  }

  public void PrintPreOrder() => PrintPreOrder(_root);

  private static void PrintPreOrder(Node? node) {
    if (node is null) {
      return;
    }

    Console.WriteLine(node.Data);
    PrintPreOrder(node.LeftChild);
    PrintPreOrder(node.RightChild);
  }

  public void PrintInOrder() {
    PrintInOrder(_root);
  }

  private static void PrintInOrder(Node? node) {
    if (node is null) {
      return;
    }

    PrintInOrder(node.LeftChild);
    Console.WriteLine(node.Data);
    PrintInOrder(node.RightChild);
  }

  public void PrintPostOrder() => PrintPostOrder(_root);

  private static void PrintPostOrder(Node? node) {
    if (node is null) {
      return;
    }

    PrintPostOrder(node.LeftChild);
    PrintPostOrder(node.RightChild);
    Console.WriteLine(node.Data);
  }

  private class Node(T data) {
    public T Data = data;
    public Node? LeftChild = null;
    public Node? RightChild = null;
  }
}
