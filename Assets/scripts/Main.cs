using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    
    private void Start()
    {
        if(PlayerPrefs.GetString("CheckPoint") == "")
        {
            PlayerPrefs.SetString("CheckPoint", "SampleScene");
            Debug.Log("No checkPoints");
          
        }
    }
    public void PlayBtn()
    {
      
        SceneManager.LoadScene(PlayerPrefs.GetString("CheckPoint"));
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
