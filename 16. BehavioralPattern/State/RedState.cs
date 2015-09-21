namespace State
{
    using System;

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
}
