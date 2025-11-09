using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform firingPosition;
    public GameObject bulletPrefab;
    public bool multiShot = false;
    float maxShootingCooldown = 0.5f;
    float shootingCooldown = 0;
    int shotsDuringCooldown = 0;
    int maxShotsDuringCooldown = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingCooldown > 0)
        {
            shootingCooldown -= Time.deltaTime;
        }
        else if (shootingCooldown <= 0)
        {
            shotsDuringCooldown = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && multiShot == false)

        {
            if (shotsDuringCooldown <= 0)
            {
                Shoot(0);
                shotsDuringCooldown += 1;
                shootingCooldown = maxShootingCooldown;
            }
            else if (shotsDuringCooldown < maxShotsDuringCooldown)
            {
                Shoot(0);
                shotsDuringCooldown += 1;
            }


        }
        else if (Input.GetKeyDown(KeyCode.Space) && multiShot == true)

        {
            if (shotsDuringCooldown <= 0)
            {
                Shoot(0);
                Shoot(45);
                Shoot(-45);
                shotsDuringCooldown += 1;
                shootingCooldown = maxShootingCooldown;
            }
            else if (shotsDuringCooldown < maxShotsDuringCooldown)
            {
                Shoot(0);
                Shoot(45);
                Shoot(-45);
                shotsDuringCooldown += 1;
            }
            

        }
    }


    public void Shoot(int angle)
    {
        firingPosition = gameObject.transform;
        Transform tempTrans = firingPosition;
        firingPosition.transform.localEulerAngles = new Vector3(firingPosition.rotation.x, firingPosition.rotation.y, firingPosition.rotation.z+angle);
        Instantiate(bulletPrefab, firingPosition.position, firingPosition.rotation);
        firingPosition.transform.localEulerAngles = new Vector3(tempTrans.rotation.x, tempTrans.rotation.y, tempTrans.rotation.z);
    }
}
