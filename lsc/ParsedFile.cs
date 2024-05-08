using BraunMisc;

namespace lsc;

public class ParsedFile
{
    private long _size;

    public long Size
    {
        get
        {
            (long s, string _) = CalculateMetricPref(_size);
            return s;
        }
        
        set { _size = value; }
    }

    public long FullSize
    {
        get => _size;
    }

    public string MetrixPrefix {
        get
        {
            (long _, string pref) = CalculateMetricPref(_size);
            return pref;
        }
   }
    public string? Name { get; set; }

    public string SizeAndMetric()
    {
        switch (Size.ToString().Length)
        {
            case 1:
                return Size +   "   "    + MetrixPrefix;
            case 2:
                return Size +   "  "     + MetrixPrefix;
            case 3:
                return Size +   " "      + MetrixPrefix;
            case 4:
                return Size +   ""       + MetrixPrefix;
            default:
                return Size +   ""       + MetrixPrefix;
        }
    }

    private (long, string) CalculateMetricPref (long size)
    {
        string[] metricPref = { "b", "kb", "mb", "gb" };
        foreach (var pref in metricPref)
        {
            if (size < 1000)
                return (size, pref);

            size /= 1000;
        }

        BraunAssert.Assert(size < 1000, "File ist über 1TB");
        throw new Exception();
    }
}
