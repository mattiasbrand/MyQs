using System.Collections.Generic;

namespace MyQs.Wpf
{
    public interface ISettings
    {
        HashSet<string> MachineNames { get; }
        void AddMachineName(string name);
    }
}