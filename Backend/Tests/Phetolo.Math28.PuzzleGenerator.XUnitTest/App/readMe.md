## Puzzle Generator Test Project
The Puzzle generator test project is created using Visual Studio Test project and then XUnit nuget package is added to the project.

## Dependencies
1. Install XUnit Nuget Package
```bash
   dotnet add package xunit -v 2.9.2
```
2. Install XUnit Runner for Visual Studio
```bash
   dotnet add package xunit.runner.visualstudio -v 2.8.2
```
3. Install Coverlet to collect code coverage
```bash
    dotnet add package coverlet.collector
```

NB: More information on how to run test and code coverage can be found in the [README.Test.md](../README.Test.md)