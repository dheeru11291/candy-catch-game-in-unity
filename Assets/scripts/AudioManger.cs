using UnityEngine;

public class AudioManger : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip gameOverSound;
    public AudioClip eatCandy;
    public AudioClip lossLives;
    void Start()
    {
        musicSource.clip=background;
        musicSource.Play();
    }
    void Update()
    {
        
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
