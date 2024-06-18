using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5;
    private bool isGrounded;



    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {   
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 5, rb.velocity.y);

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

            Invoke(nameof(Restart), 2);
        }

        if (collision.gameObject.tag == "Ground")  // Stelle sicher, dass der "Ground" Tag in Unity gesetzt ist
        {
            isGrounded = true;
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
