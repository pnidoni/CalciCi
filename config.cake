public static class Configurations
{
    public readonly static string SolutionFile = "./ExperimentCi.sln";
    public readonly static string PojectFile = "./src/CalciCi/bin";

    public static string[] UnitTestProjects
    {
        get
        {
            return System.IO.Directory.GetFiles(
                @".\",
                "*UnitTests.csproj",
                SearchOption.AllDirectories);
        }
    }

    public static string[] GetFileNames
    {
        get
        {
            return System.IO.Directory.GetFiles(
                PojectFile,
                "*",
                SearchOption.AllDirectories);
        }
    }
}
