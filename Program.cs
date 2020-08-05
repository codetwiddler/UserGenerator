using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UserGenerator.Entities;
using UserGenerator.Helpers;

//C:\Users\cortex\AppData\Roaming\Microsoft\UserSecrets houses our secrets.json file

//https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows
//https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-3.1
//https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code
//https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli

//https://www.tektutorialshub.com/entity-framework-core/ef-core-console-application/#creating-the-entity-class
//https://ballardsoftware.com/adding-appsettings-json-configuration-to-a-net-core-console-application/
//https://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx
//https://gunnarpeipman.com/ef-core-console-application/
//https://medium.com/@martinrybak/how-to-mock-singletons-and-static-methods-in-unit-tests-cbe915933c7d


namespace UserGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Start...");
            //string path = args.Length == 0 ? defaultPath : args[0].ToString();

            /*-----------------------------------------------------------------------------------------------*/
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddUserSecrets<Program>()
               .AddEnvironmentVariables();

            /*-----------------------------------------------------------------------------------------------*/
            IConfigurationRoot configuration = builder.Build();
            var settingsConfiguration = new SettingsConfiguration();
            configuration.GetSection("AccountSettings").Bind(settingsConfiguration);
            configuration.GetSection("FileSettings").Bind(settingsConfiguration);
            configuration.GetSection("ConnectionStrings").Bind(settingsConfiguration);
            configuration.GetSection("AppControlSettings").Bind(settingsConfiguration);
            //TODO: determine a way to iterate over setting's children.

            /*-----------------------------------------------------------------------------------------------*/
            Console.WriteLine("Account Name from appsettings.json: " + settingsConfiguration.AccountName);
            Console.WriteLine("Connection string from appsettings.json: " + settingsConfiguration.DefaultConnection);
            Console.WriteLine("First name list from appsettings.json: " + settingsConfiguration.NameFirstFilePath);
            Console.WriteLine("Last name list from appsettings.json: " + settingsConfiguration.NameLastFilePath);
            Console.WriteLine("Word list from appsettings.json: " + settingsConfiguration.WordListFilePath);
            Console.WriteLine("API Secret from secrets.json: " + settingsConfiguration.ApiSecret);
            Console.WriteLine("Population Size: " + settingsConfiguration.PopulationSize);

            string currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Console.WriteLine("Current Directory: " + currentDirectory);

            /*-----------------------------------------------------------------------------------------------*/
            IEnumerable<string> listOfWords = Helpers.GetWordListFromFile.GetModifierWordList(settingsConfiguration.WordListFilePath);
            IEnumerable<string> listOfFirstNames = Helpers.GetNameListFromFile.GetNameList(settingsConfiguration.NameFirstFilePath);
            IEnumerable<string> listOfLastNames = Helpers.GetNameListFromFile.GetNameList(settingsConfiguration.NameLastFilePath);

            Console.WriteLine("Marker Words Count:" + listOfWords.Count().ToString());
            Console.WriteLine("First Names Count:" + listOfFirstNames.Count().ToString());
            Console.WriteLine("Last Names Count:" + listOfLastNames.Count().ToString());

            /*-----------------------------------------------------------------------------------------------*/
            IEnumerable<Person> people = PersonGenerator.GetPeople(listOfWords.ToList(), listOfFirstNames.ToList(), listOfLastNames.ToList(), settingsConfiguration.PopulationSize);

            /*-----------------------------------------------------------------------------------------------*/
            Console.WriteLine("Application End...");
        }
    }
}
