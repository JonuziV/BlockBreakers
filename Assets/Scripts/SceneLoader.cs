using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    
	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {   
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }

    //The following Methods are for testing and prototyping only 
    public void LoadClassicScene(){
        SceneManager.LoadScene("Classic");
    }

    public void LoadRevengeScene(){
        SceneManager.LoadScene("Revenge");
    }

    public void LoadSomethingNew(){
        SceneManager.LoadScene("Something New");
    }

    //used to quit the application, doesn't work on Unity Editor
    public void QuitGame()
    {
        Application.Quit();
    }
}
