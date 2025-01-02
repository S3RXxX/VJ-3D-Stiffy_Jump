using UnityEngine;
using UnityEngine.SceneManagement;

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

    public AudioClip meow;
    public AudioClip chicken;
    public AudioClip ugh;
    

    void Start()
    {
        // m�sica inicial
        string escena = SceneManager.GetActiveScene().name;
        if (escena == "Main Menu")
        {
            musicSource.clip = menu;
            musicSource.Play();

        }
        else if (escena == "Credits")
        {
            musicSource.clip = credits;
            musicSource.Play();
        }
        else if (PlayerPrefs.GetInt("Level") == 1)
        {
            musicSource.clip = nivell1;
            musicSource.Play();
        }
        else
        {
            musicSource.clip = nivell2;
            musicSource.Play();
        }
        
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
