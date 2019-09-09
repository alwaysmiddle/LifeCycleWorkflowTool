using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeCycleWorkflowLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WorksheetCustomSettings setting = new WorksheetCustomSettings();

            setting.FormulaeRow = 2;
            setting.HeaderRow = 3;
            setting.ReferenceRow = 4;

            WorksheetCustomSettingsHolder coll = new WorksheetCustomSettingsHolder();
            coll.SettingsCollection.Add("Haha", setting);
            coll.Save();

            WorksheetCustomSettingsHolder dict =  WorksheetCustomSettingsHolder.Load();

            foreach (var item in dict.SettingsCollection)
            {
                Console.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
            }
            

            Console.ReadKey();
        }
    }
}
