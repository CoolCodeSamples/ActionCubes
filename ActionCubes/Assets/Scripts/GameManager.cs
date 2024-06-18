using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private CoinManager coinManager;

    public void EndRun()
    {
        int score = scoreManager.GetScore();
        int coinsToAdd = score / 10;  // Jeder 10. Punkt wird in einen Coin umgewandelt, da int: nur Ganzzahlen
        coinManager.AddCoins(coinsToAdd);
        scoreManager.ResetScore();
    }
}
