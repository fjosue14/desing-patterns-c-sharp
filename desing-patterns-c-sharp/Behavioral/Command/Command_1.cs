namespace desing_patterns_c_sharp.Behavioral.Command
{

    interface ICommand
    {
        void Execute();
    }

    class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is off");
        }
    }

    class Fan
    {
        public void On()
        {
            Console.WriteLine("Fan is on");
        }

        public void Off()
        {
            Console.WriteLine("Fan is off");
        }
    }

    class TurnOnLightCommand : ICommand
    {
        private Light _light;
        public TurnOnLightCommand(Light light) => _light = light;
        public void Execute() => _light.TurnOn();
    }

    class TurnOffLightCommand : ICommand
    {
        private Light _light;
        public TurnOffLightCommand(Light light) => _light = light;
        public void Execute() => _light.TurnOff();
    }

    class TurnOnFanCommand : ICommand
    {
        private Fan _fan;
        public TurnOnFanCommand(Fan fan) => _fan = fan;
        public void Execute() => _fan.On();
    }

    class TurnOffFanCommand : ICommand
    {
        private Fan _fan;
        public TurnOffFanCommand(Fan fan) => _fan = fan;
        public void Execute() => _fan.Off();
    }

    class RemoteControl
    {
        private Dictionary<string, ICommand> _commands = new();

        public void SetCommand(string button, ICommand command)
        {
            _commands[button] = command;
        }

        public void PressButton(string button)
        {
            if (_commands.TryGetValue(button, out ICommand command))
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("Button not found");
            }
        }
    }

    public static class Command_1
    {
        public static void Main()
        {
            var remote = new RemoteControl();
            var light = new Light();
            var fan = new Fan();

            remote.SetCommand("1", new TurnOnLightCommand(light));
            remote.SetCommand("2", new TurnOffLightCommand(light));
            remote.SetCommand("3", new TurnOnFanCommand(fan));
            remote.SetCommand("4", new TurnOffFanCommand(fan));

            while (true)
            {
                Console.WriteLine("\n1: Turn on light, 2: Turn off light, 3: Turn on fan, 4: Turn off fan, 5: Exit");
                Console.Write("Enter button: ");
                var button = Console.ReadLine();
                if (button == "5") break;
                remote.PressButton(button);
            }
        }
    }
}
