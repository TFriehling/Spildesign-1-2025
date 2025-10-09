using UnityEngine;
using UnityEngine.InputSystem;

public class NormalPlayerMovement : MonoBehaviour
{
    public float speed;
    Vector2 Dir = new Vector2(0, 0);
    public Rigidbody2D rb;
    public float maxSpeed;
    public float acceleration;
    public float deAcceleration;

    void Update()
    {
        
        //angle for move dir
        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (speed <= maxSpeed && speed >= -1)
            {
                speed += (Time.deltaTime * acceleration);

            }


            //rotate player
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        }
        
        if (speed >= 0 && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            speed -= Time.deltaTime * deAcceleration;
        }

        rb.linearVelocity = new Vector2(Dir.x, Dir.y).normalized*speed;
        Debug.Log(speed);

    }


}
