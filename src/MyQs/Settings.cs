using System;
using System.Collections.Generic;
using System.Configuration;

namespace MyQs.Wpf
{
    public class Settings : ISettings
    {
        public HashSet<string> MachineNames
        {
            get
            {
                var machineNames = new HashSet<string>();
                var machineNamesString = ConfigurationManager.AppSettings["MachineNames"];

                if (string.IsNullOrEmpty(machineNamesString) == false)
                {
                    foreach (var machineName in machineNamesString.Split(','))
                    {
                        if (machineNames.Contains(machineName) == false) machineNames.Add(machineName);
                    }
                }

                if (machineNames.Contains(Environment.MachineName) == false) machineNames.Add(Environment.MachineName);

                return machineNames;
            }
        }

        public void AddMachineName(string name)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var newMachineNameString = config.AppSettings.Settings["MachineNames"].Value;
            if (string.IsNullOrEmpty(newMachineNameString) == false) newMachineNameString += ",";
            newMachineNameString += name;
            config.AppSettings.Settings.Remove("MachineNames");
            config.AppSettings.Settings.Add("MachineNames", newMachineNameString);
            config.Save();
        }

        public void RemoveMachineName(string name)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var newMachineNameString = config.AppSettings.Settings["MachineNames"].Value;
            if (string.IsNullOrEmpty(newMachineNameString)) return;
            var machineNames = new HashSet<string>(newMachineNameString.Split(','));
            machineNames.Remove(name);
            config.AppSettings.Settings.Remove("MachineNames");
            config.AppSettings.Settings.Add("MachineNames", string.Join(",", machineNames));
            config.Save();
        }
    }
}