using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Skrotlog.DAL
{
    public class SettingsReader
    {
        string path = "settings.ini";
        string initials;
        decimal exchangeRate;

        public string Initials
        {
            get
            {
                if (initials == null)
                    initials = "";

                return initials;
            }
            set
            {
                initials = value;
                SaveValues();
            }
        }
        public decimal ExchangeRate
        {
            get { return exchangeRate; }
            set
            {
                exchangeRate = value;
                SaveValues();
            }
        }

        public SettingsReader()
        {
            if (!File.Exists(path))
                CreateFile();

            LoadSettings();
        }

        private void SaveValues()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(initials);
                sw.WriteLine(exchangeRate);
            }
        }

        private void CreateFile()
        {
            using(StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("JR");
                sw.WriteLine("7,5");
            }
        }

        private void LoadSettings()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                try
                {
                    initials = sr.ReadLine();
                    exchangeRate = decimal.Parse(sr.ReadLine());
                }
                catch (ArgumentNullException)
                {
                    initials = "JR";
                    exchangeRate = 7.5m;
                }
            }
        }
    }
}
