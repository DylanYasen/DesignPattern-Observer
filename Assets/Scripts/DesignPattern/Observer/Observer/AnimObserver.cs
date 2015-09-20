
public class AnimObserver : Observer
{
    public override void onNotify(Entity entity, byte notification)
    {
        switch (notification)
        {
            case NotificationConstants.ENTER_RUN_STATE:
                entity.animator.Play("run");
                break;

            case NotificationConstants.ENTER_IDLE_STATE:
                entity.animator.Play("idle");
                break;

            default:
                break;
        }
    }
}
