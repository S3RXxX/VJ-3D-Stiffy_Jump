using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source ---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- background ---------")]
    public AudioClip menu;
    public AudioClip nivell1;
    public AudioClip nivell2;
    public AudioClip credits;

    [Header("-------- SFX ---------")]
    public AudioClip jumping;
    public AudioClip breaking;
    public AudioClip coining;
    public AudioClip swimming;

    void Start()
    {
        // música inicial
        musicSource.clip = nivell1;
        musicSource.Play();
        
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
