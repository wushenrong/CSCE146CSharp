/*
 * SPDX-FileCopyrightText: 2025 Samuel Wu
 *
 * SPDX-License-Identifier: MIT
 */

namespace Fractal;

internal static class Program {
  /// <summary>
  ///  The main entry point for the application.
  /// </summary>
  [STAThread]
  static void Main() {
    // To customize application configuration such as set high DPI settings or default font,
    // see https://aka.ms/applicationconfiguration.
    ApplicationConfiguration.Initialize();
    Application.Run(new Fractal());
  }
}
