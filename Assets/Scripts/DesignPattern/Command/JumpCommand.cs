using UnityEngine;
using System.Collections;
using System;

public class JumpCommand : Command
{
    public override void execute(Entity entity)
    {
        Body2dEntity body2dEntity = (Body2dEntity)entity;
        body2dEntity.Jump();
    }
}

