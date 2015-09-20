using UnityEngine;

public class AudioObserver : Observer
{
    public override void onNotify(Entity entity, byte notification)
    {
        entity.audioSource.Stop();

        switch (notification)
        {
            case NotificationConstants.ENTER_RUN_STATE:
                entity.audioSource.clip = entity.sfx.runSfx;
                entity.audioSource.Play();
                break;

            default:
                break;
        }
    }
}
