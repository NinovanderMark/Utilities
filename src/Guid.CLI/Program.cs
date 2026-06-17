using System.Reflection;

namespace Guid.CLI
{
    internal class Program
    {
        internal static string? Version = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

        static void Main(string[] args)
        {
            if ( args.Length < 1 )
            {
                Console.WriteLine(System.Guid.NewGuid());
                return;
            }

            Console.WriteLine($"{nameof(Guid)} v{Version} - Created by Nino van der Mark");
            Console.WriteLine("Program currently accepts no parameters");
        }
    }
}
