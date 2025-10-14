using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform firingPosition;
    public GameObject bulletPrefab;
    void Start()
    {
        firingPosition = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))

        {
            Shoot();

        }
    }


    public void Shoot()
    {
        Instantiate(bulletPrefab, firingPosition.position, firingPosition.rotation);

    }
}
