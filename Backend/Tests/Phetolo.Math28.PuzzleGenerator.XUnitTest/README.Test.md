# Run Code Coverage

## Install Depenedencies

1. Install Coverlet if not install. This package is installed by default if you select XUnit project template: 
```bash
dotnet add package coverlet.collector
```

2. Install Report viewer tool to view reports in html format: 
```bash
dotnet tool install -g dotnet-reportgenerator-globalTool
```

## Step 1: Run Tests
```bash
dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults/coverageresults --settings coverlet.runsettings
```
### Parameters:
1. "--collect:"XPlat Code Coverage": Used to collect code coverage data using the Cross-Platform Code Coverage tool which is part of the Coverlet package.
2. "--results-directory": set the directory where the coverage result are save
3. "--settings": uses the settings set in the "coverlet.runsettings" file


## Step 2: CodeCoverage report
To generate Code coverage report, run the below command
```bash
reportgenerator -reports:TestResults/**/coverage.cobertura* -targetdir:TestResults/coverageresults -reporttype html
```
