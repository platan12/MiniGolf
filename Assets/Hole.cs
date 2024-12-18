using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject ball;
    private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
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
            
            if (rb != null && rb.velocity.magnitude < 9)
            {
                Debug.Log("GOL!");
                Destroy(other.gameObject);
                gameManager.GetComponent<GameManager>().NextLevel();
            }
        }
    }

}
