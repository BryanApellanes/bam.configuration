namespace Bam.Configuration;

public interface IDataPath
{
    string Value { get; }
    bool FileExists(string fileName, params string[] directorySegments);
    string ReadFile(string fileName, params string[] directorySegments);
    FileInfo WriteFile(string content, string fileName, params string[] directorySegments);
    string GetPath(string fileName, params string[] directorySegments);
}