﻿namespace State
{
using System;
    class Application
    {
        static void Main()
        {
            var pesho = new Account("Pesho", 500);
            pesho.Withdraw(500);
            pesho.Deposit(5500);
            pesho.Withdraw(100);
            pesho.Deposit(5000);
            pesho.PayInterest();
            Console.WriteLine(pesho.Ballance);
        }        
    }
}
