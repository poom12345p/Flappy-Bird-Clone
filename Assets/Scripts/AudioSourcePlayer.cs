using UnityEngine;

public class AudioSourcePlayer : MonoBehaviour,IPoolable
{
    [SerializeField] private AudioSource _audioSource;

    public GameObject OriginPref { get; set; }
    public void OnGet()
    {

    }

    public void OnRelease()
    {

    }

    public void OnDestroy()
    {
    }

    public void PlaySound(AudioClip clip,float volume)
    {
        _audioSource.volume = volume;
        _audioSource.PlayOneShot(clip);
    }
}
