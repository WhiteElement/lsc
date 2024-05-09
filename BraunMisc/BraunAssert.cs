namespace BraunMisc;

public static class BraunAssert
{
    public static void Assert(bool assertion, string message)
    {
        if (!assertion)
        {
            Console.WriteLine($"CRITICAL {DateTime.Now}: {message}");
            Environment.Exit(1);
        }
    }
}