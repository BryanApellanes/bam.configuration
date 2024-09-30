using Bam;

namespace Bam.Configuration;

public class CurrentDirectoryDataPath : DataPath
{
    public override string Value
    {
        get
        {
            FileInfo currentExe = new FileInfo(ProcessInfo.Current?.FilePath ?? ".");
            string fileName = Path.GetFileNameWithoutExtension(currentExe.FullName);
            DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory);
            return Path.Combine(directory.FullName, $".{fileName}");
        }
    }
}