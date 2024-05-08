﻿using BraunMisc;
using lsc;

var currentDir = Environment.CurrentDirectory;
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


foreach (var parsedFile in parsedFiles)
{
    Console.WriteLine(parsedFile.SizeAndMetric() + "\t" + parsedFile.Name);
    
}