using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "GolfBall")
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Transform tf = other.gameObject.GetComponent<Transform>();
            
            if (rb != null && rb.velocity.magnitude == 0)
            {
                Debug.Log("YOU DIED");
                tf.position = new Vector3(19.43f, 18.26f, 0);
            }
        }
    }
}
