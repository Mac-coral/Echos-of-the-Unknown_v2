using UnityEngine;

public class playerSFX : MonoBehaviour
{
    public AudioClip[] clips;

    public AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Step()
    {
        AudioClip clip = GetRandomClip();
        audio.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length - 1)];
    }
   
}
