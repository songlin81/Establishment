using System;

namespace Command
{
    public interface IControl
    {
         event EventHandler OnCommand;
    }
}
