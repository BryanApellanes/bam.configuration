namespace Bam.Configuration;

/// <summary>
/// Returns the dot prefixed name of the current executable rooted in the home
/// directory of the user that owns the current process.
/// </summary>
public class UserProfileDataPath : DataPath
{
    public static UserProfileDataPath Current => new UserProfileDataPath();
    public override string Value
    {
        get
        {
            FileInfo currentExe = new FileInfo(ProcessInfo.Current?.FilePath ?? ".");
            string fileName = Path.GetFileNameWithoutExtension(currentExe.FullName);
            DirectoryInfo directory = new DirectoryInfo(BamProfile.UserHome);
            return Path.Combine(directory.FullName, $".{fileName}");
        }
    }
}