using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score;

    private void IncreaseScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
    }

    private void Start()
    {
        InvokeRepeating(nameof(IncreaseScore), 1, 1);
    }
}
