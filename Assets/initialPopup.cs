using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initialPopup : MonoBehaviour
{
    public Game game;
    public Text countdownField;
    public AudioSource audioSource;

    int timer;

    void Start()
    {
        timer = game.gameStartTime;
        
        Invoke("Countdown", 1);
        countdownField.text = timer.ToString();
        //Time.timeScale = 0; freezeo el juego
    }

    
    void Reset()
    {
        gameObject.SetActive(false);

    }

    void Countdown(){
    
        if(timer > 1){
            audioSource.Play();
            timer -= 1;
            countdownField.text = timer.ToString();
            Invoke("Countdown", 1);
        }else{
            Reset();
        }
         
        
    }
}
