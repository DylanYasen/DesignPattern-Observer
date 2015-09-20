using UnityEngine;
using System.Collections;

[System.Serializable]
public class MovementStats
{
    public float moveSpeed;
    public float jumpForce;
}

[RequireComponent(typeof(Rigidbody2D))]

public class Body2dEntity : Entity
{
    public MovementStats movementStats;

    public Rigidbody2D body2d { get; private set; }

    public enum State
    {
        Idle,
        Run,
        Hurt,
        Jump
    }

    public enum Direction
    {
        Left,
        Right
    }

    public State currentState { get; protected set; }
    public Direction currentDir { get; protected set; }

    public Vector2 Velocity { get { return body2d.velocity; } }

    protected override void Awake()
    {
        base.Awake();

        body2d = GetComponent<Rigidbody2D>();

        // call swtich instead
        currentDir = Direction.Right;
        currentState = State.Idle;
    }

    public void SwitchDir(Direction dir)
    {
        if (currentDir != dir)
        {
            Flip();

            currentDir = dir;
        }
    }

    public IEnumerator MoveTo(Vector2 pos, float speedMultiply = 1, Command.CommandExecuted executedCallback = null)
    {
        Vector2 distance = pos - position;
        Vector2 dir = distance.normalized;

        // calculate velocity     
        Vector2 vel = dir * movementStats.moveSpeed;

        while (Vector2.Distance(pos, position) >= 0.01)
        {
            // start moving with entity's speed in calculated direction
            // ***** this line of code has to be in the coroutine excecution block ***** // 
            body2d.velocity = vel;

            yield return null;
        }

        // movement finished, reset velocity
        body2d.velocity = Vector2.zero;
    }

    public IEnumerator MoveBy(float x, float y, float speedMultiply = 1, Command.CommandExecuted executedCallback = null)
    {
        // calculate distance
        Vector2 distance = Vector2.zero;
        distance.Set(x, y);

        // move direction
        Vector2 dir = distance.normalized;

        // destination pos
        Vector2 pos = position;
        pos.x += x;
        pos.y += y;

        // calculate velocity     
        Vector2 vel = dir * movementStats.moveSpeed * speedMultiply;

        while (Vector2.Distance(pos, position) >= 0.01)
        {
            // start moving with entity's speed in calculated direction
            // ***** this line of code has to be in the coroutine excecution block ***** // 
            body2d.velocity = vel;

            yield return null;
        }

        // movement finished, reset velocity
        body2d.velocity = Vector2.zero;

        if (executedCallback != null)
            executedCallback();
    }

    public void MoveByX(int dir, float speedMultiply = 1,Command.CommandExecuted executedCallback = null)
    {
        Vector2 vel = Vector2.zero;
        vel.x = dir * movementStats.moveSpeed * speedMultiply;
        vel.y = Velocity.y;

        body2d.velocity = vel;
    }

    public void MoveByY(int dir, Command.CommandExecuted executedCallback = null)
    {
        Vector2 velocity = Vector2.zero;
        velocity.x = dir * movementStats.moveSpeed;
    }

    public void Jump()
    {
        // get forec vector
        Vector2 forceVec = Vector2.zero;
        forceVec.y = movementStats.jumpForce;

        body2d.AddForce(forceVec);
    }
}
