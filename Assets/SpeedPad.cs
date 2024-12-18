using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPad : MonoBehaviour
{
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
        if (other.gameObject.name == "GolfBall")
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log("Speeeeeed");
            Vector2 currentDirection = rb.velocity.normalized;
            rb.AddForce(currentDirection * 4, ForceMode2D.Impulse);
            
        }
    }
}
