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
        double step = Math.Pow(2, 1d / 12d);
        int[] keys;
        switch (args[0].ToLower(System.Globalization.CultureInfo.CurrentCulture))
        {
            case "minor":
                keys = new int[ ] { 0, 2, 3, 5, 7, 8, 10, 12, 10, 8, 7, 5, 3, 2, 0 };
                break;
            case "major":
                keys = new int[ ] { 0, 2, 4, 5, 7, 9, 11, 12, 11, 9, 7, 5, 4, 2, 0 };
                break;
            default:
                Console.WriteLine(rm.GetString("IncorrectScaleType"), args[0]);
                Console.WriteLine();
                Console.WriteLine(rm.GetString("CommandLineFormat"));
                return -4;
        }
        foreach (int key in keys)
        {
            Console.Beep((int)(start * Math.Pow(step, key)), 750);
        }
        return -1;
    }
}