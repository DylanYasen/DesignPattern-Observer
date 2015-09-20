using UnityEngine;
using System.Collections;

public abstract class Observer
{
    public abstract void onNotify(Entity entity, byte notification);
}
