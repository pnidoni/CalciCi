public static class Configurations
{
    public readonly static string SolutionFile = "./ExperimentCi.sln";

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
}
