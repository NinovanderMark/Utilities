using System.Reflection;

namespace Recoder.CLI
{
    internal class Program
    {
        internal static string? Version = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        static int Main(string[] args)
        {
            Console.WriteLine($"{nameof(Recoder)} v{Version} - Created by Nino van der Mark");

            if (args.Length < 2)
            {
                Console.WriteLine("Program requires at least 2 arguments, whether to (e)ncode or (d)ecode and the string to en-/decode");
                return (int) ReturnCodes.InvalidArguments;
            }

            if ( args.Length > 2)
            {
                Console.WriteLine("Program currently only supports base64 encoding");
                return (int) ReturnCodes.UnsupportedFeature;
            }

            string? output = null;
            switch (args[0])
            {
                case "e":
                case "E":
                case "-e":
                case "-E":
                    output = new Base64().Encode(args[1]);
                    break;

                case "d":
                case "D":
                case "-d":
                case "-D":
                    output = new Base64().Decode(args[1]);
                    break;
            }

            Console.WriteLine(output);
            return (int) ReturnCodes.Success;
        }
    }
}
