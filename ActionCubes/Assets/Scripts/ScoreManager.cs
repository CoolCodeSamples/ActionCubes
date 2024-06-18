using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        InvokeRepeating(nameof(IncreaseScore), 1, 1);
    }

    private void IncreaseScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "SCORE: " + score;
    }
}
