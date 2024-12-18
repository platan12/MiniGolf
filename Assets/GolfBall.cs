using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolfBall : MonoBehaviour
{
    float force;
    private Vector2 direction;
    private Slider forceSlider;
    public Image fillImage;
    public float maxForce;
    private Color colorBarra;
    private GameObject gameManager;
    
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
        forceSlider = GameObject.FindWithTag("Slider").GetComponent<Slider>();
        fillImage = GameObject.FindWithTag("FillImage").GetComponent<Image>();
        ColorUtility.TryParseHtmlString("#FFC800", out colorBarra);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            // Obtenim la posició del ratolí en coordenades de món
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculem la direcció apuntant cap al ratolí
            direction = (mousePosition - transform.position).normalized;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            force += Time.deltaTime / 2;
            if (force > 1)
            {
                force = 1;
            }
        }    
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.6)
            {
                GetComponent<Rigidbody2D>().AddForce(direction.normalized*maxForce*force);
                gameManager.GetComponent<GameManager>().SumHits();
            }
            force = 0;
            forceSlider.value = force;
        }
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 0.6)
        {
            fillImage.color = Color.red;
        }
        if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.6)
        {
            forceSlider.value = force;
            fillImage.color = colorBarra;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
        }
        
    }


}
