using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 7;
    public float smooth = 1;
    public float direction_x = 1f;
    public float direction_y = 1f;
    float bodysize = 2.6f;

    public Player player1;
    public Player player2;

    public GameObject ballAcid;
    public GameObject ballFire;

    public Game game;
    float _x;
    float _y;
    public AudioSource audioSource;

    public bool isRealball;

    bool locked = true;

    private void Start(){
        Invoke("InitMovement", game.gameStartTime);
    }

    void InitMovement(){
        locked = false;
    }

    
    void Update()
    {
       
        if (locked && isRealball){
            return;
        }

        _x = transform.position.x + speed * direction_x * Time.deltaTime;
        _y = transform.position.y + speed * direction_y * Time.deltaTime;

        if(game.playerActiveType == Player.types.PLAYER1){
                ballAcid.SetActive(true);
                ballFire.SetActive(false);
        }

         if(game.playerActiveType == Player.types.PLAYER2){
                ballFire.SetActive(true);
                ballAcid.SetActive(false);
        }
         
        if (_x >= game.sizes.x - bodysize)
        {
            game.particlesManager.BallHitsBody(transform.position);
            game.Win(1, 10);
            if(isRealball == true)
            Reset();
            else
            gameObject.SetActive(false);
        }
        else if (_x <= -game.sizes.x + bodysize)
        {
            game.particlesManager.BallHitsBody(transform.position);
            game.Win(2, 10);
            if(isRealball == true)
            Reset();
            else
            gameObject.SetActive(false);
        }

        if (_y >= game.sizes.y){
            ChangeYDirection(1);
            audioSource.Play();
        }else if (_y <= -game.sizes.y){
            ChangeYDirection(-1);
            audioSource.Play();
        }
            

        transform.position = new Vector2(_x, _y);

       
    }
    private void Reset()
    {
        int rand = Random.Range(0, 100);
        if (rand > 50)
            direction_x = 1;
        else
            direction_x = -1;
        rand = Random.Range(0, 100);
        if (rand > 50)
            direction_y = 1;
        else
            direction_y = -1;

        _x = _y = 0;
        transform.position = Vector3.zero;

    }
   
    private void ChangeYDirection(int direction)
    {
        _y = game.sizes.y * direction;
        direction_y *= -1;
    }

}
