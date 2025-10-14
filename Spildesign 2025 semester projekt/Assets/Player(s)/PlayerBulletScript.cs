using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    private float horizontalPercent;
    private float verticalPercent;
    private float destructionTimer;
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

        rb.linearVelocity = new Vector2(horizontalPercent * speed, verticalPercent * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (destructionTimer >= 3)
        {
            Destroy(gameObject);
        }
        destructionTimer += Time.deltaTime;
    }
}
