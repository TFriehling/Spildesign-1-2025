using UnityEngine;
using UnityEngine.InputSystem;

public class NormalPlayerMovement : MonoBehaviour
{
    public float speed;
    Vector2 Dir = new Vector2(0, 0);
    public Rigidbody2D rb;

    void Update()
    {
        Dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            //angle for move dir
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            //rotate player
            transform.rotation = Quaternion.Euler(0, 0, angle-90);

        }


    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(Dir.x, Dir.y).normalized * speed;
    }




}
