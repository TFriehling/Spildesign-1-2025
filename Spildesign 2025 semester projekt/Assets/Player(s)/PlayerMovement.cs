using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;
    private float speed = 0;
    public float backingSpeed;
    public Vector3 startRotation;
    public float rotateSpeed = 20;
    float horizontalPercent = 0.00f;
    private float verticalPercent = 0.00f;
    private float rotationPercent = 0.00f;
    public float acceleration = 1;
    public float deacceleration = 0.5f;
    private bool NE = false;
    private bool SE = false;
    //private Vector2 movementDirectionP1;
    public float maxSpeed = 8;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (transform.rotation.eulerAngles.z >= 0f && transform.rotation.eulerAngles.z <= 180f)
        {
            if (transform.rotation.eulerAngles.z < 90f)
            {
                horizontalPercent = (transform.rotation.eulerAngles.z / 90f) * -1;
                verticalPercent = 1 - (transform.rotation.eulerAngles.z / 90f);
            }
            if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z < 180)
            {
                horizontalPercent = (1 - (transform.rotation.eulerAngles.z - 90f) / 90f) * -1;
                verticalPercent = ((transform.rotation.eulerAngles.z - 90f) / 90f) * -1;
            }

        }
        else
        {
            if ((transform.rotation.eulerAngles.z) >= 180 && transform.rotation.eulerAngles.z < 270)
            {

                horizontalPercent = ((transform.rotation.eulerAngles.z - 180) / 90f);
                verticalPercent = (1 - ((transform.rotation.eulerAngles.z - 180) / 90f)) * -1;
                //Debug.Log(horizontalPercent);
                //Debug.Log(verticalPercent);
            }
            else if (transform.rotation.eulerAngles.z > 270f)
            {
                //Debug.Log("T2");
                horizontalPercent = (1 - (transform.rotation.eulerAngles.z - 270) / 90f);
                verticalPercent = ((transform.rotation.eulerAngles.z - 270) / 90f);
            }


        }


        rb = GetComponent<Rigidbody2D>();

        //Debug.Log(horizontalPercent);
        //Debug.Log(verticalPercent);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(horizontalPercent);
        //Debug.Log(verticalPercent);
        //Debug.Log(verticalPercent);
        //Debug.Log(transform.rotation.eulerAngles.z);




        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotateSpeed*Time.deltaTime);
            
            //Ændre horizontalP og verticalP således at de passer til objektets rotation
            if (transform.rotation.eulerAngles.z >= 0f && transform.rotation.eulerAngles.z <= 180f)
            {
                if (transform.rotation.eulerAngles.z < 90f)
                {
                    horizontalPercent = (transform.rotation.eulerAngles.z / 90f) * -1;
                    verticalPercent = 1 - (transform.rotation.eulerAngles.z / 90f);
                }
                if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z <180 )
                {
                    horizontalPercent = (1-(transform.rotation.eulerAngles.z-90f) / 90f) * -1;
                    verticalPercent = ((transform.rotation.eulerAngles.z-90f) / 90f) * -1 ;
                }

            }
            else
            {
                if ((transform.rotation.eulerAngles.z) >= 180 && transform.rotation.eulerAngles.z < 270)
                {
                    
                    horizontalPercent = ((transform.rotation.eulerAngles.z-180) / 90f);
                    verticalPercent = (1 - ((transform.rotation.eulerAngles.z-180) / 90f)) * -1;
                    //Debug.Log(horizontalPercent);
                    //Debug.Log(verticalPercent);
                }
                else if (transform.rotation.eulerAngles.z > 270f)
                {
                    //Debug.Log("T2");
                    horizontalPercent = (1 - (transform.rotation.eulerAngles.z - 270) / 90f);
                    verticalPercent = ((transform.rotation.eulerAngles.z - 270) / 90f);
                }
               

            }

            


        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);

            //Ændre horizontalP og verticalP således at de passer til objektets rotation
            if (transform.rotation.eulerAngles.z >= 0f && transform.rotation.eulerAngles.z <= 180f)
            {
                if (transform.rotation.eulerAngles.z < 90f)
                {
                    horizontalPercent = (transform.rotation.eulerAngles.z / 90f) * -1;
                    verticalPercent = 1 - (transform.rotation.eulerAngles.z / 90f);
                }
                if (transform.rotation.eulerAngles.z >= 90 && transform.rotation.eulerAngles.z < 180)
                {
                    horizontalPercent = (1 - (transform.rotation.eulerAngles.z - 90f) / 90f) * -1;
                    verticalPercent = ((transform.rotation.eulerAngles.z - 90f) / 90f) * -1;
                }

            }
            else
            {
                if ((transform.rotation.eulerAngles.z) >= 180 && transform.rotation.eulerAngles.z < 270)
                {

                    horizontalPercent = ((transform.rotation.eulerAngles.z - 180) / 90f);
                    verticalPercent = (1 - ((transform.rotation.eulerAngles.z - 180) / 90f)) * -1;
                    //Debug.Log(horizontalPercent);
                    //Debug.Log(verticalPercent);
                }
                else if (transform.rotation.eulerAngles.z > 270f)
                {
                    //Debug.Log("T2");
                    horizontalPercent = (1 - (transform.rotation.eulerAngles.z - 270) / 90f);
                    verticalPercent = ((transform.rotation.eulerAngles.z - 270) / 90f);
                }


            }




        }

        if (Input.GetKey(KeyCode.W) && speed <= maxSpeed)
        {
             speed += Time.deltaTime * acceleration;
            
        }
        else if (Input.GetKey(KeyCode.S) && speed >= maxSpeed *-1)
        {

            speed -= Time.deltaTime * backingSpeed;
        }

        //bruger horizontalP og verticalP samt speed og acceleration til at bevæge player
        

            rb.linearVelocity = new Vector2(horizontalPercent * speed, verticalPercent * speed);
        

        if (speed <= maxSpeed && !Input.GetKey(KeyCode.W) && speed >= 0)

        {
            speed -= Time.deltaTime * deacceleration;
        }
        else if (speed >= maxSpeed * -1 && !Input.GetKey(KeyCode.S) && speed < 0)
         {
            speed += Time.deltaTime * deacceleration;

        }



    }
}
