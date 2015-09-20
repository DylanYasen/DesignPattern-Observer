using UnityEngine;
using System.Collections;
using System;

public class MoveByXCommand : Command
{
    public override void execute(Entity entity)
    {
        Body2dEntity body2dEntity = (Body2dEntity)entity;

        int dir = (body2dEntity.currentDir == Body2dEntity.Direction.Right) ? 1 : -1;

        body2dEntity.MoveByX(dir);
    }
}
