using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Vector2 sizes = new Vector2(8, 5);

    public int gameStartTime = 3;

    public int score_player_1 = 100;
    public int score_player_2 = 100;
       //hago referencia a un objeto que tenga text
    public Text field_score_p1;
    public Text field_score_p2;

    public Animation cuerpo_player2;
    public Animation cuerpo_player1;
    public AudioSource audioSource;


    public Player.types playerActiveType;

    public ParticlesManager particlesManager;

    void Start()
    {
       
    }

    public void Win(int playerID, int score)
    {
        if (playerID == 1)
        {
            score_player_2 -= score;
             //acceso a la propiedad texto del objeto
             //pide un string y lo estoy pasando un interger, por eso lo transformamos con la funcion
            field_score_p2.text = score_player_2.ToString();
            cuerpo_player1.Play();
            audioSource.Play();
        }
        else
        {
            score_player_1 -= score;
            field_score_p1.text = score_player_1.ToString();
            cuerpo_player2.Play();
            audioSource.Play();
        }

        if (score_player_2 <= 0){
            Data.player_win_ID = 1; //como esa es clase estatica puedo llamarlo de cualquier lugar sin necesitar referenciar
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");

        }else if(score_player_1 <= 0){
            Data.player_win_ID = 2; 
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");

        }
            
    }
}
