using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text fieldWinner;
    public GameObject SnakeWin;
    public GameObject DragonWin;
   

    void Start()
    {
       fieldWinner.text = "Jugador " + Data.player_win_ID;
      
       if (Data.player_win_ID == 1){
           SnakeWin.SetActive(true);
           DragonWin.SetActive(false);

       }else{
           DragonWin.SetActive(true);
           SnakeWin.SetActive(false);
       }
    }

    public void GotoGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void GotoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}


