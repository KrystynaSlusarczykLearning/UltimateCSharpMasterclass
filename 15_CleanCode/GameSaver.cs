public class GameSaver
{
    private GameDataWriter _gameDataWriter = new GameDataWriter();

    public void Save(GameData data, string saveFileFinalPath)
    {
        _gameDataWriter.WriteTo(saveFileFinalPath, data);
    }

    public string BuildFileName(
        string fileName,
        string extension)
    {
        return fileName + "." + extension;
    }
}

public class GameData
{

}

public class GameDataWriter
{
    internal void WriteTo(string saveFileFinalPath1, GameData saveFileFinalPath2)
    {
        //imagine this is the real implmentation
    }
}
