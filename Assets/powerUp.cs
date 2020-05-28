using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    public Game game;
    public GameObject snakePowerUp;
    public GameObject dragonPowerUp;
    public AudioSource audioSource;
    public Ball ballone;
    public Ball balltwo;

    private void OnTriggerEnter(Collider other)
    {
        
        if(game.playerActiveType == Player.types.PLAYER1){
                OnPowerUp(snakePowerUp);
                Invoke("OffPowerUpSnake", 5);
        }

        if(game.playerActiveType == Player.types.PLAYER2){
                OnPowerUp(dragonPowerUp);
                Invoke("OffPowerUpDragon", 2f);
        }
            

        transform.position = new Vector2(1000, 1000);
        Invoke("Repositionate", 10);
    }

    void Repositionate()
    {
        float _x = Random.Range(game.sizes.x, -game.sizes.x);
        float _y = Random.Range(game.sizes.y, -game.sizes.y);

        _x /= 3f;
        _y /= 1.2f;

        transform.position = new Vector2(_x, _y);
    }
    

    public void OnPowerUp(GameObject CharactergameObject)
    {
        CharactergameObject.SetActive(true);
        ballone.gameObject.SetActive(true);
        balltwo.gameObject.SetActive(true);
        audioSource.Play();
    }

    public void OffPowerUpSnake()
    {
        snakePowerUp.SetActive(false);
    }

     public void OffPowerUpDragon()
    {
        dragonPowerUp.SetActive(false);
        ballone.transform.position = new Vector3(1.6f, 2.5f, 0);
        balltwo.transform.position = new Vector3(1.6f, -0.75f, 0);        
        ballone.direction_x = -1f;
        balltwo.direction_x = -1f;
    }
}

