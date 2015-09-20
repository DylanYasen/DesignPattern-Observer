using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

[System.Serializable]
public class Sfx
{
    public AudioClip runSfx;
    public AudioClip hurtSfx;
}

public class Entity : MonoBehaviour
{
    public Sfx sfx;

    public Animator animator { get; private set; }
    public AudioSource audioSource { get; private set; }
    public SpriteRenderer spRenderer { get; private set; }

    public float sprite_width
    {
        get { return spRenderer.bounds.size.x; }
    }

    public float sprite_height
    {
        get { return spRenderer.bounds.size.y; }
    }

    public Sprite sprite
    {
        get { return spRenderer.sprite; }
    }

    public Vector2 position
    {
        get { return transform.position; }
    }

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spRenderer = GetComponent<SpriteRenderer>();
    }

    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }

    public IEnumerator TranslateTo(Vector2 pos, float duration)
    {
        // calculate distance & movement direction
        Vector2 distance = pos - position;
        Vector2 dir = distance.normalized;

        // calculate move speed by distrance & duration
        float speed = Mathf.Sqrt(Vector2.SqrMagnitude(distance)) / duration;

        while (Vector2.Distance(pos, position) >= 0.1)
        {
            transform.Translate(dir * speed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator TranslateBy(float x, float y, float duration)
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

        float speed = Vector3.Magnitude(distance) / duration;

        while (Vector2.Distance(pos, position) >= 0.1)
        {
            transform.Translate(dir * speed * Time.deltaTime);
            yield return null;
        }
    }

    public virtual void SetPosition(float x, float y)
    {
        Vector2 vec = Vector2.zero;
        vec.Set(x, y);
        transform.position = vec;
    }

    public virtual void SetPosition(Vector2 pos)
    {
        transform.position = pos;
    }



}

