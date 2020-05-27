using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Game game;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        int extra = 0;
        if(transform.localScale.x == 0.8f)
        {
            extra = 4;
        } 

        if(game.playerActiveType == Player.types.PLAYER1)
            game.Win(1, 1 + extra);
        else
            game.Win(2, 1 + extra);

        audioSource.Play();
        game.particlesManager.BallHitsLightning(transform.position);
        transform.position = new Vector2(1000, 1000);
        CancelInvoke();
        Invoke("Repositionate", 2);
    }
    void Repositionate()
    {
        float _x = Random.Range(game.sizes.x, -game.sizes.x);
        float _y = Random.Range(game.sizes.y, -game.sizes.y);

        _x /= 1.8f;
        _y /= 1.2f;

        transform.position = new Vector2(_x, _y);
    }
}
