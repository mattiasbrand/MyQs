namespace MyQs.Wpf.Events
{
    public class MachineSelected
    {
        public string MachineName { get; set; }

        public MachineSelected(string machineName)
        {
            MachineName = machineName;
        }
    }
}