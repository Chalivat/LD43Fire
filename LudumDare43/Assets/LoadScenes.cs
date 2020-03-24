using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour {
    
	void Start () {
        Time.timeScale = 1;
	}

    public void LoadGame()
    {
        SceneManager.LoadScene("Alpha01");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
