using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
         #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    
    public void LoadDeathScene(){
        SceneManager.LoadScene("GameOverScene");
    }
}