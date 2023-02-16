using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordFly : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower;
    public float rotationPower;
    public static bool swordWay = false;
    float ratio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.angularVelocity);
        // transform.Rotate(new Vector3(0, 0, ratio));
        //ratio *= 0.97f;

        if(Input.GetMouseButtonDown(0)){

            // for(int i = 0; i < transform.childCount; i++)
            GetComponent<AudioSource>().Play();
            jumpSword();
            
            // if(swordWay)
            //     jumpSword();
            // else
            //     jumpSword(-1);
        }
    }

    public void jumpSword(int way = 1)
    {
        rb.angularVelocity = 0;
        float rotaPower = rotationPower + Random.Range(-10f,11f);
        rb.AddTorque(rotaPower * way, ForceMode2D.Force);
        //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);

        //if(rb.velocity.y <= 0)
        //    rb.drag
        rb.velocity = Vector2.up * jumpPower;
        //ratio = -10;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(Score.score > Score.bestScore){
            Score.bestScore = Score.score;
        }
        SceneManager.LoadScene("GameOverScene");
    }

}
