/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace Labs.Lab05;

public class ProcessScheduler {
  private readonly IQueue<Process> _processes;
  private Process? _currentProcess;

  public ProcessScheduler() {
    _processes = new LinkedListQueue<Process>();
    _currentProcess = null;
  }

  public Process? GetCurrentProcess() => _currentProcess;

  public void AddProcess(Process process) {
    if (_currentProcess is null) {
      _currentProcess = process;
      return;
    }

    _processes.Enqueue(process);
  }

  public void RunNextProcess() => _currentProcess = _processes.Dequeue();

  public void CancelCurrentProcess() {
    if (_currentProcess is not null) {
      _processes.Enqueue(_currentProcess);
      _currentProcess = _processes.Dequeue();
    }
  }

  public void PrintProcessQueue() => _processes.Print();
}
