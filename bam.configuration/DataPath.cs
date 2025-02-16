namespace Bam.Configuration;

public abstract class DataPath : IDataPath
{
    public abstract string Value { get; }
    
    public bool FileExists(string fileName, params string[] directorySegments)
    {
        return File.Exists(GetPath(fileName, directorySegments));
    }
    
    public string ReadFile(string fileName, params string[] directorySegments)
    {
        return GetPath(fileName, directorySegments).SafeReadFile();
    }

    public FileInfo WriteFile(string content, string fileName, params string[] directorySegments)
    {
        FileInfo file = new FileInfo(GetPath(fileName, directorySegments));
        file.FullName.SafeWriteFile(content, true);
        return file;
    }

    public string GetPath(string fileName, params string[] directorySegments)
    {
        List<string> parts = new List<string>(directorySegments);
        parts.Insert(0, Value);
        parts.Add(fileName);
        return Path.Combine(parts.ToArray());
    }

    /// <summary>
    /// Gets the full path to the specified directory.
    /// </summary>
    /// <param name="directorySegments"></param>
    /// <returns></returns>
    public string GetDirectory(params string[] directorySegments)
    {
        List<string> parts = new List<string>(directorySegments);
        parts.Insert(0, Value);
        return Path.Combine(parts.ToArray());
    }
}