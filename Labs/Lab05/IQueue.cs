/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace Labs.Lab05;

public interface IQueue<T> {
  void Enqueue(T data);

  T? Dequeue();

  T? Peek();

  void Print();
}
