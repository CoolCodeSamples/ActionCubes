using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back * Spawner.obstacleSpeed;
    }
}
