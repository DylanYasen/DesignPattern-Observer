using UnityEngine;
using System.Collections;
using System;

public class MoveToCommand : Command
{
    private Vector2 moveToDestination;
    private float duration;

    public MoveToCommand(Vector2 destPos)
    {
        moveToDestination = destPos;
    }

    public void SetMoveToDestination(Vector2 destPos)
    {
        moveToDestination = destPos;
    }

    public override void execute(Entity entity)
    {
        Body2dEntity body2dEntity = (Body2dEntity)entity;

        entity.StartCoroutine(body2dEntity.MoveTo(moveToDestination));
    }
}

public class MoveByCommand : Command
{
    private float moveByX;
    private float moveByY;

    public MoveByCommand(float moveByX, float moveByY)
    {
        this.moveByX = moveByX;
        this.moveByY = moveByY;
    }

    public void SetMoveToDestination(float moveByX, float moveByY)
    {
        this.moveByX = moveByX;
        this.moveByY = moveByY;
    }

    public override void execute(Entity entity)
    {
        Body2dEntity body2dEntity = (Body2dEntity)entity;

        entity.StartCoroutine(body2dEntity.MoveBy(moveByX, moveByY));
    }
}
