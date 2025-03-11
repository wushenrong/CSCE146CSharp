namespace TaskOrganizer;

using System;

using VideoGameDatabase;

public class TaskOrganizer {
  private GenericLinkedList<Task>[] _organizedTasks;

  public TaskOrganizer() {
    Init();
  }

  public void Init() {
    _organizedTasks = new GenericLinkedList<Task>[Task.NUMBER_OF_PRIORITIES];

    for (int priority = 0; priority < _organizedTasks.Length; priority++) {
      _organizedTasks[priority] = new();
    }
  }

  public void AddTask(Task data) {
    int taskPriority = data.Priority;

    if (_organizedTasks[taskPriority].Contains(data)) {
      Console.WriteLine($"""Task "{data.Action}" with priority {taskPriority} already exists""");
      Console.WriteLine($"""Skipping Task "{data.Action}" with priority {taskPriority}""");
      return;
    }

    _organizedTasks[taskPriority].Add(data);
  }

  public void RemoveTask(Task data) {
    int taskPriority = data.Priority;

    GenericLinkedList<Task> taskList = _organizedTasks[taskPriority];

    taskList.ResetCurrent();

    while (taskList.HasNext()) {
      if (taskList.GetCurrent().Equals(data)) {
        taskList.RemoveCurrent();
        return;
      }

      taskList.Next();
    }
  }

  public void ReadTaskFile(string filename) {
    Init();

    foreach (string entry in File.ReadLines(filename)) {
      String[] fields = entry.Split(Task.DELIMITER);

      if (fields.Length != Task.NUMBER_OF_FIELDS) {
        continue;
      }

      int taskPriority = int.Parse(fields[0]);
      string taskAction = fields[1];

      AddTask(new(taskPriority, taskAction));
    }
  }

  public void WriteTaskFile(string filename) {
    using StreamWriter fileWriter = new(filename);

    for (int priority = 0; priority < _organizedTasks.Length; priority++) {
      GenericLinkedList<Task> taskList = _organizedTasks[priority];

      taskList.ResetCurrent();

      while (taskList.HasNext()) {
        Task data = taskList.GetCurrent();
        fileWriter.WriteLine(data);
        taskList.Next();
      }
    }
  }
}
