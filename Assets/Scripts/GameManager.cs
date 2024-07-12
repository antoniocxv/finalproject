using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    public TextMeshProUGUI scoreText; // Referencia al texto UI
   

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        scoreText.SetText("Score: " + score);

        Debug.Log("Score: " + score);
        // Aquí puedes actualizar la UI del marcador si es necesario
    }
}
