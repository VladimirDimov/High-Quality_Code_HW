namespace State
{
    public class Account
    {
        private string name;
        private State state;
        private decimal ballance;

        public Account(string name, decimal ballance)
        {
            this.Name = name;
            this.state = new SilverState(this, ballance);
            this.state.UpdateState();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public State State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
            }
        }

        public decimal Ballance
        {
            get
            {
                return this.state.Ballance;
            }
        }

        public void Deposit(decimal amount)
        {
            this.state.Deposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            this.state.Withdraw(amount);
        }

        public void PayInterest()
        {
            this.state.PayInterrest();
        }
    }
}
