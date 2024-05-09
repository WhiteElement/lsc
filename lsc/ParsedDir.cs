namespace lsc;

public class ParsedDir : IConsoleDisplay
{
    private string name;
    public string Info => "<DIR> ";

    public string Name
    {
        get => name;
        set
        {
            var dirInfo = new DirectoryInfo(value);
            name = dirInfo.Name;
        }
    }
}