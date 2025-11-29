using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }


    public void QuitGame()
    {
        Debug.Log("Game is Quitting..."); 

        
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        
        Application.Quit();
#endif
    }
}