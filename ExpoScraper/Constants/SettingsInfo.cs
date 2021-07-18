using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoScraper.Constants
{
    public class SettingsInfo
    {
        public readonly string SectionName;
        public readonly string EnvironmentPrefix;

        public SettingsInfo(string sectionName, string environmentPrefix = null)
        {
            SectionName = sectionName;
            EnvironmentPrefix = environmentPrefix;
        }
    }
}
