using DbUp;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace DBUpDemo
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault()
                    ?? ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; 

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())                    
                    .LogToConsole()                    
                    .Build();

            var upgradeRequired = upgrader.IsUpgradeRequired();
            if (!upgradeRequired) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No upgrade required!");

                #if DEBUG 
                         Console.Read();
                #endif
                return 0;
            }

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                #if DEBUG
                          Console.ReadLine();
                #endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Upgrade completed successfully!");
            Console.ResetColor();
            Console.Read();
            return 0;
        }
    }
}
