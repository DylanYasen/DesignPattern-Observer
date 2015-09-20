using UnityEngine;
using System.Collections.Generic;

public class Player : Body2dEntity
{
    // subject to observers
    private Subject subject;

    private MoveByXCommand moveByXCommand;

    public Vector2 testVel;

    void Start()
    {
        // set up subject for observer
        subject = new Subject(this);

        // register observers
        var animOb = new AnimObserver();
        var audioOb = new AudioObserver();

        subject.AddObserver(animOb);
        subject.AddObserver(audioOb);

        // init command
        moveByXCommand = new MoveByXCommand();
        /*
        MoveByCommand command = new MoveByCommand(0.5f, 0);
        command.AddCommandExecutedCallback(CommandFinishCallback);
        command.execute(this);
        */

        //body2d.velocity = new Vector2(5, 0);
    }

    void CommandFinishCallback()
    {
        Debug.Log("command finished");
    }

    void Update()
    {
        testVel = Velocity;

        // abstract out input
        float inputX = Input.GetAxisRaw("Horizontal");

        if (inputX != 0)
        {
            SwitchState(State.Run);

            if (inputX < 0)
                SwitchDir(Direction.Left);
            else
                SwitchDir(Direction.Right);

            moveByXCommand.execute(this);
        }
        else
        {

            SwitchState(State.Idle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpCommand j = new JumpCommand();
            j.execute(this);
        }
    }

    void SwitchState(State state)
    {
        if (currentState != state)
        {
            currentState = state;

            // notify observers
            switch (state)
            {
                case State.Run:
                    subject.Notify(NotificationConstants.ENTER_RUN_STATE);
                    break;

                case State.Idle:
                    subject.Notify(NotificationConstants.ENTER_IDLE_STATE);
                    body2d.velocity = new Vector2(0, Velocity.y);
                    break;

                default:
                    break;
            }
        }
    }
}



