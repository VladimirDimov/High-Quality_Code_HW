using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    class GoldenState : State
    {
        private Account account;

        public GoldenState(Account account, decimal ballance)
            :base(account, ballance)
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
}
