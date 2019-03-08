#load "./config.cake"
///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "CiBuild");
var configuration = Argument("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
   .Does(() =>
{
   DotNetCoreClean(
      Configurations.SolutionFile,
      new DotNetCoreCleanSettings
      {
         Configuration = configuration
      });
});
Task("Restore")
   .Does(() =>
{
   DotNetCoreRestore(
      Configurations.SolutionFile,
      new DotNetCoreRestoreSettings
      {
         Force = true
      }
   );
});
Task("Build")
   .Does(() =>
{
   DotNetCoreBuild(
      Configurations.SolutionFile,
      new DotNetCoreBuildSettings
      {
         Configuration = configuration
      });
   for (int i = 0; i < Configurations.GetFileNames.Length; i++)
   {
      var name = Configurations.GetFileNames[i];
      Information(name);
   }
});
Task("Test")
   .Does(() =>
{
   var testSettings = new DotNetCoreTestSettings
   {
      Configuration = configuration,
      NoBuild = true,
      NoRestore = true
   };
   
   for (int i = 1; i <= Configurations.UnitTestProjects.Length; i++)
   {
      var test = Configurations.UnitTestProjects[i - 1];
      
      DotNetCoreTest(
         test,
         testSettings
      ); 
   }
});

Task("CiBuild")
   .IsDependentOn("Clean")
   .IsDependentOn("Restore")
   .IsDependentOn("Build")
   .IsDependentOn("Test");

RunTarget(target);