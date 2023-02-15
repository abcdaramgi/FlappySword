using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    private bool isHit = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(!isHit){
            if(other.gameObject.tag == "Knife"){
                isHit = true;
                Score.score++;
                // Destroy(other.gameObject);
                // HitSystem.instance.knifes.Clear();
                HitSystem.instance.minusKnife();
                Destroy(gameObject);
            }
        }
    }

    // private void OnCollisionEnter2D(Collider other){
    //     if (Score.score > Score.bestScore)
    //     {
    //         Score.bestScore = Score.score;
    //     }
    //     SceneManager.LoadScene("GameOverScene");
    // }
}
