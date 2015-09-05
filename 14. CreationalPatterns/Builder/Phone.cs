namespace Builder
{
    using System;
    using System.Text;
    using Builder.Enumerations;

    class Phone
    {
        public Phone(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public BatteryTypes Batery { get; set; }
        public OperatingSystemTypes OperatingSystem { get; set; }
        public ScreenTypes Screen { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Name..............." + this.Name);
            builder.AppendLine("Batery............." + this.Batery);
            builder.AppendLine("OperatingSystem...." + this.OperatingSystem);
            builder.AppendLine("Screen............." + this.Screen);

            return builder.ToString();
        }
    }
}
