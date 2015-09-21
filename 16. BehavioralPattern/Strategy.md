#Command
Щаблонът дефинира взаимно заменяеми алгоритми, които решават един и същи проблем, но по различни начини, позволявайки да променяме поведението на обекта, който ги използва, без да променяме самия него.

## Участници

**Стратегия (Strategy):** Декларира общ интерфейс за всички поддържани алгоритми (стратегии). Контекстът (Context) се обръща към този интерфейс, за да използва дадена конкретна имплементация (ConcreteStrategy).

**Конкретна стратегия (ConcreteStrategy):** Имплементира интерфейса Strategy, реализирайки конкретен алгоритъм (стратегия).

**Контекст (Context):** Конфигуриран е с подходяща инстанция на клас от тип Стратегия (Strategy), тоест държи референция към такъв клас.

##Принципна диаграма
![Принципна диаграма](images/strategy.png)

##Пример
В показания пример имаме обект Message, който съдържа текст и има метод, който принтира текста. В зависимост от зададената стратегия, текста се принтира на конзолата в различен цвят.

**Strategy**

	public abstract class Printer
    {
        public abstract void Print(string text);
    }

**ConcreteStrategy**

	public class DefaultPrinter : Printer
    {
        public override void Print(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }
    }

	public class RedPrinter : Printer
    {
        public override void Print(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
        }
    }

	public class BluePrinter : Printer
    {
        public override void Print(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
        }
    }

**Context**

	class Message
    {
        private Printer printer;
        private string text;

        public Message(string text)
        {
            this.Text = text;
        }

        public string Text
        {
            get
            {
                return this.text;
            }

            private set
            {
                this.text = value;
            }
        }

        public Printer Printer
        {
            get
            {
                return this.printer;
            }

            set
            {
                this.printer = value;
            }
        }

        public void Print()
        {
            this.printer.Print(this.text);
        }
    }

**Client**

	class Program
    {
        static void Main()
        {
            var message = new Message("Hello!");

            message.Printer = new DefaultPrinter();
            message.Print();

            message.Printer = new RedPrinter();
            message.Print();

            message.Printer = new BluePrinter();
            message.Print();
        }
    }