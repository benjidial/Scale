using System;

static class Program
{
    private static int Main(string[ ] args)
    {
        System.Resources.ResourceManager rm = new System.Resources.ResourceManager("Benji.Scale.Resources.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        if (args.Length != 2)
        {
            if ((args.Length == 1) && (args[0] == "/?"))
            {
                Console.WriteLine(rm.GetString("CommandLineFormat"));
                return 1;
            }
            Console.WriteLine(rm.GetString("WrongNumberOfArguments"));
            Console.WriteLine();
            Console.WriteLine(rm.GetString("CommandLineFormat"));
            return -1;
        }
        int start;
        try
        {
            start = Int32.Parse(args[1]);
        }
        catch (FormatException)
        {
            Console.WriteLine(rm.GetString("NotAnInteger"), args[1]);
            Console.WriteLine();
            Console.WriteLine(rm.GetString("CommandLineFormat"));
            return -2;
        }
        catch (OverflowException)
        {
            Console.WriteLine(rm.GetString("NotInRange"), args[1], 37.ToString(System.Globalization.CultureInfo.CurrentCulture), 16383.ToString(System.Globalization.CultureInfo.CurrentCulture));
            Console.WriteLine();
            Console.WriteLine(rm.GetString("CommandLineFormat"));
            return -3;
        }
        if ((start < 37) || (start > 16383))
        {
            Console.WriteLine(rm.GetString("NotInRange"), args[1], 37.ToString(System.Globalization.CultureInfo.CurrentCulture), 16383.ToString(System.Globalization.CultureInfo.CurrentCulture));
            Console.WriteLine();
            Console.WriteLine(rm.GetString("CommandLineFormat"));
            return -3;
        }
        int[] cents;
        switch (args[0].ToLower(System.Globalization.CultureInfo.CurrentCulture))
        {
            case "whole tone":
                cents = new int[ ] { 0, 200, 400, 600, 800, 1000, 1200, 1000, 800, 600, 400, 200, 0 };
                break;
            case "phrygian":
                cents = new int[ ] { 0, 100, 300, 500, 700, 800, 1000, 1200, 1000, 800, 700, 500, 300, 100, 0 };
                break;
            case "pentatonic":
                cents = new int[ ] { 0, 200, 400, 700, 900, 1200, 900, 700, 400, 200, 0 };
                break;
            case "minor pentatonic":
                cents = new int[ ] { 0, 300, 500, 700, 1000, 1200, 1000, 700, 500, 300, 0 };
                break;
            case "locrian":
                cents = new int[ ] { 0, 100, 300, 500, 600, 800, 1000, 1200, 1000, 800, 600, 500, 300, 100, 0 };
                break;
            case "mixolydian":
                cents = new int[ ] { 0, 200, 400, 500, 700, 900, 1000, 1200, 1000, 900, 700, 500, 400, 200, 0 };
                break;
            case "aeolian":
            case "minor":
                cents = new int[ ] { 0, 200, 300, 500, 700, 800, 1000, 1200, 1000, 800, 700, 500, 300, 200, 0 };
                break;
            case "melodic minor":
                cents = new int[ ] { 0, 200, 300, 500, 700, 900, 1100, 1200, 1000, 800, 700, 500, 300, 200, 0 };
                break;
            case "harmonic minor":
                cents = new int[ ] { 0, 200, 300, 500, 700, 800, 1100, 1200, 1100, 800, 700, 500, 300, 200, 0 };
                break;
            case "ionian":
            case "major":
                cents = new int[ ] { 0, 200, 400, 500, 700, 900, 1100, 1200, 1100, 900, 700, 500, 400, 200, 0 };
                break;
            case "lydian":
                cents = new int[ ] { 0, 200, 400, 600, 700, 900, 1100, 1200, 1100, 900, 700, 600, 400, 200, 0 };
                break;
            case "dorian":
                cents = new int[ ] { 0, 200, 300, 500, 700, 900, 1000, 1200, 1000, 900, 700, 500, 300, 200, 0 };
                break;
            case "blues":
                cents = new int[ ] { 0, 300, 500, 600, 700, 1000, 1200, 1000, 700, 600, 500, 300, 0 };
                break;
            default:
                Console.WriteLine(rm.GetString("IncorrectScaleType"), args[0]);
                Console.WriteLine();
                Console.WriteLine(rm.GetString("CommandLineFormat"));
                return -4;
        }
        foreach (int key in cents)
        {
            Console.Beep((int)(start * Math.Pow(2, (double)key / 1200)), 750);
        }
        return -1;
    }
}