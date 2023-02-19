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
    public Vector3 center_of_mass;
    Vector3 targetPosition;
    public GameObject go;
    float ratio;
    public Transform headPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameObject.GetComponent<Rigidbody2D>().centerOfMass = center_of_mass;

        Vector2 gravityDirection = headPosition.position - transform.position;
        gravityDirection.Normalize();

        Physics2D.gravity = gravityDirection * Physics2D.gravity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 gravityDirection = headPosition.position - transform.position;
        gravityDirection.Normalize();

        Physics2D.gravity = gravityDirection * Physics2D.gravity.magnitude;
        // targetPosition = new Vector3(transform.position.x, transform.position.y, 180);
        // transform.LookAt(targetPosition);
        // gameObject.GetComponent<Rigidbody2D>().centerOfMass = center_of_mass;
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

    Quaternion downRotation = Quaternion.Euler(new Vector3(0,0,180));
    IEnumerator Rotate(float duration)
    {
        while(rb.velocity.y >= 0)
        {
            yield return null;
        }

        float startRotation = transform.eulerAngles.z % 360;
        float endRotation = Random.Range(170f,190f);

        if(0 <= startRotation && startRotation < 45)
        {
            endRotation = Random.Range(0f,10f);
        }
        if(315 <= startRotation && startRotation < 360)
        {
            endRotation = Random.Range(350f,360f);
        }

        float t = 0.0f;
            
        rb.angularVelocity = 0;
        
        while ( t  < duration )
        {
            t += Time.deltaTime * (-rb.velocity.y/5);
            float zRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(0, 0, zRotation);
            yield return null;
        }
    }

    public void jumpSword(int way = 1)
    {
        StopAllCoroutines();

        rb.angularVelocity = 0;
        float rotaPower = rotationPower + Random.Range(-10f,11f);
        rb.AddTorque(rotaPower * way, ForceMode2D.Force);
        //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);

        //if(rb.velocity.y <= 0)
        //    rb.drag
        rb.velocity = Vector2.up * jumpPower;


        //ratio = -10;

        StartCoroutine("Rotate",1.5f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(Score.score > Score.bestScore){
            Score.bestScore = Score.score;
        }
        SceneManager.LoadScene("GameOverScene");
    }

}