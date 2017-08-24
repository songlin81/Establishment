using System;

namespace Command
{
    public class OutCommnad : IControl
    {
        public OutCommnad() { }

        event EventHandler CommandEvent;
        event EventHandler IControl.OnCommand
        {
            add
            {
                if (CommandEvent != null)
                {
                    lock (CommandEvent)
                    {
                        CommandEvent += value;
                    }
                }
                else
                {
                    CommandEvent = new EventHandler(value);
                }
            }
            remove
            {
                if (CommandEvent != null)
                {
                    lock (CommandEvent)
                    {
                        CommandEvent -= value;
                    }
                }
            }
        }

        public void Command()
        {
            EventHandler handler = CommandEvent;
            if (handler != null)
            {
                CommandArgs cmd = new CommandArgs();
                cmd.CommandName = "Test Application event.";
                handler(this, cmd);
            }
        }
    }
}
