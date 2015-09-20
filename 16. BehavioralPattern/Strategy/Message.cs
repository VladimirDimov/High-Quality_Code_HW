namespace Strategy
{
    using System;

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
}
