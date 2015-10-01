namespace ConsoleApplication1.Command
{
    using System;
    using System.Collections.Generic;

    public interface ICommand
    {
        void Execute(IList<String> parameters);
    }
}
