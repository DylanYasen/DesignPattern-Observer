using System.Collections.Generic;

public class Subject
{
    private List<Observer> observers = new List<Observer>();

    private Entity _attachedEntity;

    public Subject(Entity entity)
    {
        _attachedEntity = entity;
    }

    public void AddObserver(Observer obs)
    {
        observers.Add(obs);
    }

    public void RemoveObserver(Observer obs)
    {
        observers.Remove(obs);
    }

    public void Notify(byte notification)
    {
        foreach (var ob in observers)
        {
            ob.onNotify(_attachedEntity, notification);
        }
    }
}