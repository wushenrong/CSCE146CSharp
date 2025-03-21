/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace Labs.Lab05;

public class Process {
  public const string DEFAULT_NAME = "none";
  public const double DEFAULT_COMPLETION_TIME = 0.0;

  public string Name { get; set => field = value ?? DEFAULT_NAME; }
  public double CompletionTime {
    get;
    set => field = value >= DEFAULT_COMPLETION_TIME ? value : DEFAULT_COMPLETION_TIME;
  }

  public Process() : this(DEFAULT_NAME, DEFAULT_COMPLETION_TIME) { }

  public Process(string name, double completionTime) {
    Name = name;
    CompletionTime = completionTime;
  }

  public override string ToString() {
    return $"Process Name: {Name} Completion Time: {CompletionTime}";
  }
}
