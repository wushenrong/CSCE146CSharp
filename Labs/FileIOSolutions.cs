namespace Labs;

public class FileIOSolutions {
  public static void PastTense(string inputFileName, string outputFileName) {
    try {
      using StreamReader fileReader = new(inputFileName);
      using StreamWriter fileWriter = new(outputFileName);

      string text = fileReader.ReadToEnd();
      string output = text.Replace("is", "was").Replace("Is", "Was");

      Console.WriteLine(output);
      fileWriter.WriteLine(output);
    } catch (IOException e) {
      Console.WriteLine(e);
    }
  }

  public static double TotalTubeVolume(string filename) {
    const string delimiter = "\t";
    const int numberOfFields = 3;

    double totalVolume = 0.0;

    foreach (var line in File.ReadLines(filename)) {
      string[] splitLines = line.Split(delimiter);

      if (splitLines.Length != numberOfFields) {
        continue;
      }

      double radius = double.Parse(splitLines[1]);
      double height = double.Parse(splitLines[2]);
      totalVolume += Math.Pow(radius, 2) * Math.PI * height;
    }

    return totalVolume;
  }
}
