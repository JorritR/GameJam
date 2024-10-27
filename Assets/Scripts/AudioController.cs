using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Music
    [SerializeField] private AudioSource introSource;
    [SerializeField] private AudioSource loopSource; 
    
    private AudioClip currentIntroClip;
    private AudioClip currentLoopClip;

    [SerializeField] private AudioClip introClipEvo2;
    [SerializeField] private AudioClip loopClipEvo2;

    [SerializeField] private AudioClip introClipEvo3;
    [SerializeField] private AudioClip loopClipEvo3;



    // Kill sound
    [SerializeField] private AudioSource killSoundSource;

    // Death sound
    [SerializeField] private AudioSource deathSoundSource;


    private void Start()
    {
        currentIntroClip = introSource.clip;
        currentLoopClip = loopSource.clip;

        PlayTrackSet(currentIntroClip, currentLoopClip);
    }

    private void PlayTrackSet(AudioClip introClip, AudioClip loopClip)
    {
        introSource.Stop();
        loopSource.Stop();

        introSource.clip = introClip;
        loopSource.clip = loopClip;

        introSource.Play();

        loopSource.loop = true;
        loopSource.PlayScheduled(AudioSettings.dspTime + introClip.length);
    }

    public void PlayEvo2()
    {
        PlayTrackSet(introClipEvo2, loopClipEvo2);
    }

    public void PlayEvo3()
    {
        PlayTrackSet(introClipEvo3, loopClipEvo3);
    }

    public void PlayDeathSound()
    {
        deathSoundSource.Play();
    }

    public void PlayKillSound()
    {
        killSoundSource.Play();
    }

}
