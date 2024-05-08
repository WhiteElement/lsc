using BraunMisc;
using lsc;

var currentDir = Environment.CurrentDirectory;
var dirNames = Directory.GetDirectories(currentDir);
var fileNames = Directory.GetFiles(currentDir);

var parsedFiles = new List<ParsedFile>();

// "4 Files in /temp/..."

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

var parsedDirs = new List<DirectoryInfo>();
foreach (var dir in dirNames)
{
    var dirInfo = new DirectoryInfo(dir);
    parsedDirs.Add(dirInfo);
}

Console.WriteLine($"{parsedFiles.Count} files & {parsedDirs.Count} folders in {currentDir}");

foreach (var parsedDir in parsedDirs)
    Console.WriteLine($"<DIR>  {parsedDir.Name}");

foreach (var parsedFile in parsedFiles)
    Console.WriteLine(parsedFile.SizeAndMetric() + "\t" + parsedFile.Name);