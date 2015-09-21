#Command
Позволява един обект да промени поведението си при промяна на текущото състояние. 

Може да използвате шаблона Състояние (State) при:

- Даден обект има сравнително малък на брой състояния като в даден момент може да бъде само в едно от тях и трябва да се извършват преходи от едно състояние в друго по време на изпълнението вашата програмата.

- Всяка операция на този обект съдържа логика за разклонение чрез използването на оператор за условен преход (if, switch) като моментното състояние се описва чрез на една или повече локални променливи и техните текущи стойности. Често едно и също разклонение се среща в повече от една операция на този обект.  

## Участници

**Контекст (Context):** дефинира интерфейс за ползване за клиентите на този клас.

**Състояние (State):** дефинира базов интерфейс описващ операциите, който се поддържат във всички състояния на обекта.

**Kонкретни състояния (ConcreteState classes):** всеки такъв клас описва едно конкретно състояние и е имплементация на специфичната логика в това състояние.  

##Принципна диаграма
![Принципна диаграма](images/state.png)

##Пример
В показания пример е представен банков клиент, който в зависимост от паричния баланс приема различни състояния(red, silver, golden). Следните класове имплементират показаната по-горе схема на шаблона:

**Context**

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

**State**

	public abstract class State
    {
        protected decimal interrest;
        private decimal ballance;
        private Account account;

        public State(Account account, decimal ballance)
        {
            this.Account = account;
            this.Ballance = ballance;
        }

        public Account Account
        {
            get
            {
                return this.account;
            }

            set
            {
                this.account = value;
            }
        }

        public decimal Ballance
        {
            get
            {
                return this.ballance;
            }

            private set
            {
                this.ballance = value;
            }
        }

        public virtual void Deposit(decimal deposit)
        {
            this.ballance += deposit;
            this.UpdateState();
        }

        public virtual void Withdraw(decimal withdraw)
        {
            this.ballance -= withdraw;
            UpdateState();
        }

        public virtual void PayInterrest()
        {
            this.ballance += this.interrest * this.account.Ballance;
        }

        internal abstract void UpdateState();
    }

**Concrete state**

	public class RedState : State
    {
        public RedState(Account account, decimal ballance)
            : base(account, ballance)
        {
            base.interrest = 0;
        }

        internal override void UpdateState()
        {
            var ballance = base.Account.Ballance;

            if (1000 <= ballance && ballance < 5000)
            {
                this.Account.State = new SilverState(this.Account, base.Ballance);
            }
            else if (5000 <= ballance)
            {
                this.Account.State = new GoldenState(this.Account, base.Ballance);
            }
        }

        public override void Withdraw(decimal withdraw)
        {
            Console.WriteLine("Red accounts cannot withdraw!");
            this.UpdateState();
        }
    }

	public class SilverState : State
    {
        public SilverState(Account account, decimal ballance)
            : base(account, ballance)
        {
            base.interrest = 0;
        }

        internal override void UpdateState()
        {
            if (base.Account.Ballance < 1000)
            {
                base.Account.State = new RedState(base.Account, base.Ballance);
            }
            else if (base.Account.Ballance > 5000)
            {
                base.Account.State = new GoldenState(base.Account, base.Ballance);
            }
        }
    }

	public class GoldenState : State
    {
        private Account account;

        public GoldenState(Account account, decimal ballance)
            : base(account, ballance)
        {
            base.interrest = 0.05m;
        }

        internal override void UpdateState()
        {
            var ballance = base.Account.Ballance;

            if (ballance < 1000)
            {
                this.Account.State = new RedState(base.Account, base.Ballance);
            }
            else if (1000 <= ballance && ballance < 5000)
            {
                this.Account.State = new SilverState(base.Account, base.Ballance);
            }
        }
    }