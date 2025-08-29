using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]private Rigidbody2D _rigidbody;
    [SerializeField]private Collider2D _collider;
    [SerializeField]private float _force;
    [SerializeField]AudioClip _flapSound;
    [SerializeField]AudioClip _deathSound;
    public void Reset()
    {
        _collider.isTrigger = true;
        _rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionY;
        transform.position = Vector2.zero;
    }

    public void Activate()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    public void Flap()
    {
        _rigidbody.linearVelocity = Vector2.zero;
        _rigidbody.AddRelativeForce(transform.up  * _force, ForceMode2D.Impulse);
       SoundManager.Instance.PlaySound(_flapSound);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Obstacle"))
        {
            if (other.TryGetComponent<ITriggerableObject>(out var triggerableObject))
            {
                triggerableObject.Trigger();
            }
        }
    }

    public void Dead()
    {
        SoundManager.Instance.PlaySound(_deathSound);
        _collider.isTrigger = false;
    }
}
