using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static float obstacleSpeed = 20;

    [SerializeField] private float spawnRate = 1;
    [SerializeField] private GameObject obstacle;

    private void SpeedUp()
    {
        spawnRate *= 0.99f;
        obstacleSpeed *= 1.01f;
    }

    private void CreateObstacle()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-1, 2) * 4, 0);
        Instantiate(obstacle, transform.position + randomOffset, transform.rotation);
        SpeedUp();

        Invoke(nameof(CreateObstacle), spawnRate);
    }

    private void Start()
    {
        CreateObstacle();
    }
}
