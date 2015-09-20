using UnityEngine;
using System.Collections;

// could add callback for command finish

public abstract class Command
{
    // delegate for command finished callback
    public delegate void CommandExecuted();
    public CommandExecuted commandExecutedCallback { get; private set; }

    public void AddCommandExecutedCallback(CommandExecuted callback)
    {
        commandExecutedCallback += callback;
    }

    public abstract void execute(Entity entity);
}
