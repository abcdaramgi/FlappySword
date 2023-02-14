using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSystem : MonoBehaviour
{
    public List<GameObject> knifes = new List<GameObject>();
    public SwordFly swordFly;
    public GameObject knife;
    public int count = 0;
    public float knifePositionRange = 0.14f;
    public float hitPositionDefault = 0.085f;
    public float hitPositionRange = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Handle")
        {
            swordFly.jumpSword();

            GameObject k = Instantiate(knife,Vector3.zero,Quaternion.identity,transform.parent);
            k.GetComponent<knifeSystem>().hitSystem = this;
            knifes.Add(k);

            k.transform.localPosition = new Vector3(0,knifePositionRange * ++count,0);
            k.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
            gameObject.transform.localPosition = new Vector3(0,hitPositionDefault + (hitPositionRange * count),0);
        }
    }

    public void minusKnife()
    {
        swordFly.jumpSword(-1);

        //Destroy(knifes[--count]);
        knifes.RemoveAt(--count);
        gameObject.transform.localPosition = new Vector3(0, hitPositionDefault + (hitPositionRange * count), 0);
    }
}
