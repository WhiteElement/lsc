using BraunMisc;
using lsc;

var currentDir = Environment.CurrentDirectory;
List<IConsoleDisplay> resultContainer = new();
if (args.Contains("-d"))
{
    // -d Flag filters for Directories only
    resultContainer.AddRange(AggregateDirs());
}
else
{
    resultContainer.AddRange(AggregateFiles());
    resultContainer.AddRange(AggregateDirs());
}

PrintEntries(resultContainer);

List<ParsedFile> AggregateFiles()
{
    var fileNames = Directory.GetFiles(currentDir);
    var parsedFiles = new List<ParsedFile>();

    foreach (var file in fileNames)
    {
        var formattedFile = new ParsedFile(file);
        parsedFiles.Add(formattedFile);
    }
    BraunAssert.Assert(parsedFiles.Count == fileNames.Length, "konnte nicht alle Files parsen");

    return parsedFiles;
}

List<ParsedDir> AggregateDirs()
{
    var dirNames = Directory.GetDirectories(currentDir);
    var parsedDirs = new List<ParsedDir>();
    
    foreach (var dir in dirNames)
    {
        var dirInfo = new ParsedDir
        {
            Name = dir
        };
        parsedDirs.Add(dirInfo);
    }

    return parsedDirs;
}

void PrintEntries(List<IConsoleDisplay> resultContainer)
{
    Console.WriteLine($"{resultContainer.Where(x => x is ParsedFile).ToArray().Length} files" +
                      $" & {resultContainer.Where(x => x is ParsedDir).ToArray().Length} directories" +
                      $" in {currentDir}");
    
    foreach (var result in resultContainer)
        Console.WriteLine(result.Info + "\t" + result.Name);
}