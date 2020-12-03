using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Ticketing.Helpers
{
    // questa classe per come è fatta poteva anche essere dichiarata statica, perchè ha solo metodi statici
    // se non metto static è perchè voglio lasciare la libertà di inserire delle proprietà di istanza
    public class Config
    {
        private static IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) //per far guardare in questa directory: quando il progamma sarà compilato, guarderà nella cartella debug
                .AddJsonFile("appsettings.json")
                .Build();

        public static string GetConnectionString(string ConnStringName)
        {
           return config.GetConnectionString("TicketDb"); 
        }

        public static IConfigurationSection GetSection(string sectionName) // se dovesse servirmi una sezione del file Json
        {
            return config.GetSection(sectionName);
        }

    }
}
