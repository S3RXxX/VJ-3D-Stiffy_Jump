using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using NUnit.Framework.Interfaces;

public class LevelManager : MonoBehaviour
{
    string sceneToLoad;
    public TextMeshProUGUI highScoreText;
    void Start()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            sceneToLoad = "Level1"; //SceneManager.GetActiveScene().name;
        }
        else
        {
            sceneToLoad = "Level1";
        }
            
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            ShowHighScore();
        }
    }
    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("Level") == 1)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadSceneAsync("Level1");
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                SceneManager.LoadSceneAsync("Level2");
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                SceneManager.LoadSceneAsync("Level3");
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                SceneManager.LoadSceneAsync("Level4");
            }
            else if (Input.GetKey(KeyCode.Alpha5))
            {
                SceneManager.LoadSceneAsync("Level5");
            }
            else if (Input.GetKey(KeyCode.Alpha6))
            {
                SceneManager.LoadSceneAsync("Level6");
            }
            else if (Input.GetKey(KeyCode.Alpha7))
            {
                SceneManager.LoadSceneAsync("Level7");
            }
            else if (Input.GetKey(KeyCode.Alpha8))
            {
                SceneManager.LoadSceneAsync("Level8");
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadSceneAsync("Level9");
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                SceneManager.LoadSceneAsync("Level10");
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                SceneManager.LoadSceneAsync("Level11");
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                SceneManager.LoadSceneAsync("Level12");
            }
            else if (Input.GetKey(KeyCode.Alpha5))
            {
                SceneManager.LoadSceneAsync("Level13");
            }
            else if (Input.GetKey(KeyCode.Alpha6))
            {
                SceneManager.LoadSceneAsync("Level14");
            }
            else if (Input.GetKey(KeyCode.Alpha7))
            {
                SceneManager.LoadSceneAsync("Level15");
            }
            else if (Input.GetKey(KeyCode.Alpha8))
            {
                SceneManager.LoadSceneAsync("Level16");
            }

        }

    }

    public void RestartLevel(float delayTime)
    {
        StartCoroutine(RestartLevelAfterDelay(delayTime));
    }

    private IEnumerator RestartLevelAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadSceneAsync(sceneToLoad); // Restart the current scene
    }

    public void PlayGame()
    {
        PlayerPrefs.SetInt("Level", 1);
        //Debug.Log("pre if PlayGame");
        if (!PlayerPrefs.HasKey("PlayerSkin")) 
        {
            PlayerPrefs.SetInt("PlayerSkin", 1);
        }
        //Debug.Log("PlayGame");
        
        SceneManager.LoadSceneAsync("Level1");
        //SceneManager.LoadSceneAsync(0);
    }

    public void PlayGame2()
    {
        //Debug.Log("pre if PlayGame2");
        PlayerPrefs.SetInt("Level", 2);
        if (!PlayerPrefs.HasKey("PlayerSkin"))
        {
            PlayerPrefs.SetInt("PlayerSkin", 1);
        }
        //Debug.Log("post if PlayGame2");

        // posar pantalla 1 nivell 2
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void toMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void selectP1()
    {
        PlayerPrefs.SetInt("PlayerSkin",1);
    }

    public void selectP2()
    {
        PlayerPrefs.SetInt("PlayerSkin", 2);
    }

    public void selectP3()
    {
        PlayerPrefs.SetInt("PlayerSkin", 3);
    }

    private void ShowHighScore()
    {
        highScoreText.text = "HIGHEST SCORE:\n";
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            highScoreText.text += PlayerPrefs.GetInt("SavedHighScore").ToString();
        }
        else
        {
            highScoreText.text += "0";
        }
        
    }

    public void NextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex++;
        if ("Level8" == SceneManager.GetActiveScene().name)
        {
            PlayerPrefs.SetInt("Level", 2);
        }
        SceneManager.LoadSceneAsync(sceneIndex);

    }
}
