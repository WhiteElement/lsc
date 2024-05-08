using System.Security.Cryptography;
using BraunMisc;
using lsc;

var currentDir = Environment.CurrentDirectory;
if (args.Contains("-d"))
{
    Console.WriteLine("Directory Mode -d");
    var parsedDirs = AggregateDirs(currentDir);
    PrintDirs(parsedDirs);
}
else
{
    Console.WriteLine("Normal Mode");
}
var fileNames = Directory.GetFiles(currentDir);

var parsedFiles = new List<ParsedFile>();

foreach (var file in fileNames)
{
    var fileInfo = new FileInfo(file);

    var formattedFile = new ParsedFile()
    {
        Name = fileInfo.Name,
        Size = fileInfo.Length
    }; 
    parsedFiles.Add(formattedFile);
}

BraunAssert.Assert(parsedFiles.Count == fileNames.Length, "konnte nicht alle Files parsen");


Console.WriteLine($"{parsedFiles.Count} files & {parsedDirs.Count} folders in {currentDir}");


foreach (var parsedFile in parsedFiles)
    Console.WriteLine(parsedFile.SizeAndMetric() + "\t" + parsedFile.Name);

void PrintDirs(List<DirectoryInfo> parsedDirs)
{
    foreach (var parsedDir in parsedDirs)
        Console.WriteLine($"<DIR>  {parsedDir.Name}");
}

List<DirectoryInfo> AggregateDirs(string directory)
{
    var dirNames = Directory.GetDirectories(directory);
    var parsedDirs = new List<DirectoryInfo>();
    
    foreach (var dir in dirNames)
    {
        var dirInfo = new DirectoryInfo(dir);
        parsedDirs.Add(dirInfo);
    }

    return parsedDirs;
}