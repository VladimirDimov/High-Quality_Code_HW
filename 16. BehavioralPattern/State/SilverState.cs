using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State
{
    class SilverState : State
    {
        public SilverState(Account account, decimal ballance)
            :base(account, ballance)
        {
            base.interrest = 0;
        }

        internal override void UpdateState()
        {
            if (base.Account.Ballance < 1000)
            {
                base.Account.State = new RedState(base.Account,base.Ballance);
            }
            else if (base.Account.Ballance > 5000)
            {
                base.Account.State = new GoldenState(base.Account, base.Ballance);
            }
        }
    }
}
