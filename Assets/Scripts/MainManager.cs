using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance {get;private set;} //Encapsulation
    public int lives = 2;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void LoseLife()
    {
        if(lives > 0)
        {
            lives -= 1;
        }
        else
        {
            lives = 0;
            //Gameover Here
        }
    }
}
