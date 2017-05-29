﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Skrotlog.DAL
{
    public class SettingsReader
    {
        //Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) == C:\Users\"Current User"\Documents\
        //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Skrotlog\\settings.ini";
        string path = "settings.ini";
        string initials = "MR";
        decimal exchangeRate = 7.5m;

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
                //SaveInitials(value);
            }
        }
        public decimal ExchangeRate
        {
            get { return exchangeRate; }
            set
            {
                exchangeRate = value;
                //SaveEurValue(value);
            }
        }

        public SettingsReader()
        {
            //using (StreamReader sr = new StreamReader(path))
            //{
            //    Initials = sr.ReadLine();
            //    ExchangeRate = decimal.Parse(sr.ReadLine());
            //}
        }

        private void SaveInitials(string initials)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(initials);
            }
        }

        private void SaveEurValue(decimal eurValue)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(initials);
                sw.WriteLine(eurValue);
            }
        }
    }
}
