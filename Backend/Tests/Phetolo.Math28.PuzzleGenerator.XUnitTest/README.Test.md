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
dotnet test --collect:"XPlat Code Coverage"
```

## Step 2: CodeCoverage report
To generate Code coverage report, run the below command
```bash
reportgenerator -reports:TestResults/**/coverage.cobertura* -targetdir:TestResults/coverageresults -reporttype html
```
