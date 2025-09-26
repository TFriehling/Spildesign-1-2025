using UnityEngine;

public class PlayerMovementNonTank : MonoBehaviour
{
    float verticalMovement;
    float horizontalMovement;
    public float movementSpeed;
    private Rigidbody2D rb;
    private Vector2 movementDirectionP2;
    private Vector2 zeroVector = Vector2.zero;
    public float rotateSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        movementDirectionP2 = new Vector2(horizontalMovement, verticalMovement);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = (movementDirectionP2.normalized * (movementSpeed*10) * Time.deltaTime);
        }
        else
        {
            rb.linearVelocity = zeroVector;
        }

        if (Input.GetKey(KeyCode.N))
        {
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.M))
        {
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
        }

    }
}
