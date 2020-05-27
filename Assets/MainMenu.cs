using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
  
    void Start()
    {
        
    }

    public void GotoGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }


}
