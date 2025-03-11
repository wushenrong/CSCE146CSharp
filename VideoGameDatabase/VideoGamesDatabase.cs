namespace VideoGameDatabase;

class VideoGamesDatabase {
  private GenericLinkedList<VideoGame>? _videoGamesList;
  private GenericLinkedList<VideoGame>? _searchResults;

  public VideoGamesDatabase() {
    _videoGamesList = null;
    _searchResults = null;
  }

  public bool SearchVideoGames(string? gameQuery, string? consoleQuery) {
    if (_videoGamesList is null || gameQuery is null || consoleQuery is null) {
      return false;
    }

    _searchResults = new();

    _videoGamesList.ResetCurrent();

    while (_videoGamesList.HasNext()) {
      VideoGame? game = _videoGamesList.GetCurrent();

      if (game is null) {
        continue;
      }

      string gameName = game.Name.ToLower();
      string gameConsole = game.Console.ToLower();

      bool matchedGameName = false;
      bool matchedGameConsole = false;

      if (gameQuery.Equals("*") || gameName.Contains(gameQuery, StringComparison.OrdinalIgnoreCase)) {
        matchedGameName = true;
      }

      if (consoleQuery.Equals("*") || gameConsole.Contains(consoleQuery, StringComparison.OrdinalIgnoreCase)) {
        matchedGameConsole = true;
      }

      if (matchedGameName && matchedGameConsole) {
        _searchResults.Add(game);
      }

      _videoGamesList.Next();
    }

    return true;
  }

  public bool PrintVideoGamesSearchResults() {
    if (_searchResults is null) {
      return false;
    }

    _searchResults.ResetCurrent();

    while (_searchResults.HasNext()) {
      Console.WriteLine(_searchResults.GetCurrent());
      _searchResults.Next();
    }

    return true;
  }

  public void ReadVideoGameCollectionFile(string filename) {
    _videoGamesList = new();

    foreach (string entry in File.ReadLines(filename)) {
      string[] fields = entry.Split(VideoGame.DELIMITER);

      if (fields.Length != VideoGame.NUMBER_OF_FIELDS) {
        continue;
      }

      string videoGameName = fields[0];
      string videoGameConsole = fields[1];

      VideoGame newVideoGame = new(videoGameName, videoGameConsole);
      _videoGamesList.Add(newVideoGame);
    }
  }

  public bool WriteVideoGamesSearchResults(string filename, bool append) {
    if (_searchResults is null) {
      return false;
    }

    using StreamWriter fileWriter = new(filename, append);

    _searchResults.ResetCurrent();

    while (_searchResults.HasNext()) {
      fileWriter.WriteLine(_searchResults.GetCurrent());
      _searchResults.Next();
    }

    return true;
  }
}
