using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance {get;private set;} //Encapsulation
    public int lives = 2;
    public int score = 0;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public bool gameOver = false;
    private AudioSource crowdScream;

    private void Awake()
    {
       // if(Instance != null)
      //  {
         //   Destroy(gameObject);
          //  return;
        //}

        Instance = this;
        crowdScream = gameObject.GetComponent<AudioSource>();

        //DontDestroyOnLoad(gameObject);
    }


    public void LoseLife()
    {
        if(lives > 0)
        {
            lives -= 1;
            livesText.text = "Lives: " + lives;

        }
        else
        {
            lives = 0;
            crowdScream.Play();
            gameOverText.SetActive(true);
            gameOver = true;
        }
    }
}
