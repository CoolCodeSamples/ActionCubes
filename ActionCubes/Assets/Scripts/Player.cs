using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Material[] materials;

    private bool isGrounded;


    void Start()
    {
        int materialIndex = PlayerPrefs.GetInt("SkinIndex", 0);
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && materials.Length > materialIndex)
        {
            renderer.material = materials[materialIndex];
        }
    }

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {   
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 5, rb.velocity.y);

        if(transform.position.y < -0.5)
        {
            GameOver();
        }

        // Sprungmechanik
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;  // Aktualisiere den Bodenkontakt-Status
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            rb.constraints = RigidbodyConstraints.None;
            GameOver();
        }

        if (collision.gameObject.tag == "Ground")  // Stelle sicher, dass der "Ground" Tag in Unity gesetzt ist
        {
            isGrounded = true;
        }
    }

    private void GameOver()
    {
        gameManager.GameOver();
    }
}
