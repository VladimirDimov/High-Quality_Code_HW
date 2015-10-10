namespace Computers
{
    using System;
    using System.Collections.Generic;

    class Computers
    {
        public static void Main()
        {
            var manufacturerFactory = new ManufacturerFactory();
            var manufacturerName = Console.ReadLine();
            IManufacturer manufacturer = manufacturerFactory.GetManufacturer(manufacturerName);

            var personalComputer = manufacturer.GetPersonalComputer();
            var laptop = manufacturer.GetLaptop();
            var server = manufacturer.GetServer();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == null || command.StartsWith("Exit"))
                {
                    break;
                }

                var commandSplit = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandSplit.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = commandSplit[0];
                var commandArgument = int.Parse(commandSplit[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArgument);
                }
                else if (commandName == "Play")
                {
                    personalComputer.Play(commandArgument);
                }
            }
        }
    }
}
