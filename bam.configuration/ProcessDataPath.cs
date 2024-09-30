using System.Reflection;

namespace Bam.Configuration;

public class ProcessDataPath
{
    static ProcessDataPath _current;
    private static readonly object _currentLock = new object();
    public static ProcessDataPath Current
    {
        get
        {
            return _currentLock.DoubleCheckLock(ref _current, () => new ProcessDataPath());
        }
        set => _current = value;
    }

    public string Value
    {
        get
        {
            FileInfo currentExe = new FileInfo(ProcessInfo.Current.FilePath);
            string fileName = Path.GetFileNameWithoutExtension(currentExe.FullName);
            DirectoryInfo directory = currentExe.Directory ?? new DirectoryInfo(Environment.CurrentDirectory);
            return Path.Combine(directory.FullName, $".{fileName}");
        }
    }

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
        file.FullName.SafeWriteFile(content);
        return file;
    }

    public string GetPath(string fileName, params string[] directorySegments)
    {
        List<string> parts = new List<string>(directorySegments);
        parts.Insert(0, Value);
        parts.Add(fileName);
        return Path.Combine(parts.ToArray());
    }
}