/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace RobotSimulator;

using Labs.Lab05;

public class RobotSimulator {
  public const int BOARD_SIZE = 10;
  public const int START_POSITION = 0;

  public const char EMPTY = '_';
  public const char ROBOT = 'O';
  public const char OBSTACLE = 'X';

  public const string UP = "Move Up";
  public const string DOWN = "Move Down";
  public const string LEFT = "Move Left";
  public const string RIGHT = "Move Right";

  private char[,]? _board;
  private IQueue<string>? _commandsToRun;

  private int _commandCounter = 0;
  private int _robotXposition = START_POSITION;
  private int _robotYposition = START_POSITION;

  public RobotSimulator() {
    _board = null;
    _commandsToRun = null;
  }

  public int StartSimulation() {
    _commandCounter = 0;

    if (_board is null) {
      return -1;
    }

    if (IsPositionObstacle(_robotXposition, _robotYposition)) {
      return 1;
    }

    _robotXposition = START_POSITION;
    _robotYposition = START_POSITION;
    _board[_robotYposition, _robotXposition] = ROBOT;

    return 0;
  }

  public int RunNextCommand() {
    if (_board is null || _commandsToRun is null) {
      return -1;
    }

    string? command = _commandsToRun.Dequeue();
    _commandCounter++;

    if (command is null) {
      return 2;
    }

    Console.WriteLine("Command " + _commandCounter + ": " + command);

    int previousXposition = _robotXposition;
    int previousYposition = _robotYposition;

    switch (command) {
      case UP:
        _robotYposition -= 1;
        break;

      case DOWN:
        _robotYposition += 1;
        break;

      case LEFT:
        _robotXposition -= 1;
        break;

      case RIGHT:
        _robotXposition += 1;
        break;

      default:
        break;
    }

    if (!IsPositionValid(_robotXposition)
        || !IsPositionValid(_robotYposition)
        || IsPositionObstacle(_robotXposition, _robotYposition)) {
      return 1;
    }

    _board[_robotYposition, _robotXposition] = ROBOT;
    _board[previousYposition, previousXposition] = EMPTY;

    return 0;
  }

  private bool IsPositionValid(int position) {
    return _board is not null && position >= 0 && position < _board.GetLength(0);
  }

  private bool IsPositionObstacle(int xPosition, int yPosition) {
    return _board is not null && _board[yPosition, xPosition] == OBSTACLE;
  }

  public void PrintBoard() {
    if (_board is null) {
      return;
    }

    for (int row = 0; row < _board.GetLength(0); row++) {
      for (int column = 0; column < _board.GetLength(1); column++) {
        Console.Write(_board[row, column]);
      }

      Console.WriteLine();
    }

    Console.WriteLine();
  }

  public void ReadBoardFile(string filename) {
    _board = new char[BOARD_SIZE, BOARD_SIZE];

    int row = 0;

    foreach (string line in File.ReadLines(filename)) {
      for (int column = 0; column < line.Length; column++) {
        _board[row, column] = line.ElementAt(column);
      }

      row++;
    }
  }

  public void ReadCommandFile(string filename) {
    _commandsToRun = new GenericLinkedQueue<string>();

    foreach (string command in File.ReadLines(filename)) {
      _commandsToRun.Enqueue(command);
    }
  }
}
