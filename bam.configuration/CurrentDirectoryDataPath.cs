using Bam;

namespace Bam.Configuration;

public class CurrentDirectoryDataPath : DataPath
{
    public static CurrentDirectoryDataPath Current => new CurrentDirectoryDataPath();

    private string _value;
    public override string Value
    {
        get
        {
            if (string.IsNullOrEmpty(_value))
            {
                FileInfo currentExe = new FileInfo(ProcessInfo.Current?.FilePath ?? ".");
                string fileName = Path.GetFileNameWithoutExtension(currentExe.FullName);
                DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory);
                _value = Path.Combine(directory.FullName, $".{fileName}");
            }

            return _value;
        }
    }
}