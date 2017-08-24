using System;

namespace Command
{
    class Program
    {
        static void Main()
        {
            OutCommnad outCommand = new OutCommnad();
            IControl con = (IControl)outCommand;
            con.OnCommand += new EventHandler(con_OnCommand);
            outCommand.Command();
        }

        private static void con_OnCommand(object sender, EventArgs e)
        {
            var commandArgs = e as CommandArgs;
            if (commandArgs != null)
            {
                string str = commandArgs.CommandName;
                Console.WriteLine(str);
            }
        }
    }
}
