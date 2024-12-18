using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int level = 0;
    private int hits = 0;
    public TMP_Text hitsText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destrueix el duplicat
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Fa que aquest objecte no es destrueixi en canviar d'escena
    }
    
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        level += 1;
        SceneManager.LoadScene(level);
    }

    public void SumHits()
    {
        hits += 1;
        hitsText.SetText("Hits: " + hits);
    }
}
