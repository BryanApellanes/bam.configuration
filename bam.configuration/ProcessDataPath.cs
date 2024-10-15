using System.Reflection;

namespace Bam.Configuration;

public class ProcessDataPath : DataPath
{
    static ProcessDataPath? _current;
    private static readonly object _currentLock = new object();
    public static ProcessDataPath Current
    {
        get
        {
            return _currentLock.DoubleCheckLock(ref _current, () => new ProcessDataPath());
        }
        set => _current = value;
    }

    public override string Value
    {
        get
        {
            FileInfo currentExe = new FileInfo(ProcessInfo.Current?.FilePath ?? ".");
            string fileName = Path.GetFileNameWithoutExtension(currentExe.FullName);
            DirectoryInfo directory = currentExe.Directory ?? new DirectoryInfo(Environment.CurrentDirectory);
            return Path.Combine(directory.FullName, $".{fileName}");
        }
    }
}