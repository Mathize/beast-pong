using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public Game game;
    public ParticleSystem ballHitSnake;
    public ParticleSystem ballHitDragon;
    public ParticleSystem lightning;

    public void BallHitsBody(Vector3 pos)
    {
         if(game.playerActiveType == Player.types.PLAYER1){
            ballHitDragon.transform.position = pos;
            ballHitDragon.Play();
        }else{
            ballHitSnake.transform.position = pos;
            ballHitSnake.Play();

        }
        
    }

    public void BallHitsLightning(Vector3 pos)
    {
        lightning.transform.position = pos;
        lightning.Play();
    }

}
