using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    abstract class State
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
}
