using UnityEngine;

public class IceCreamController : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    private float lastFired;
    private float fireInterval = 3.0f; // Intervalo de 3 segundos para disparo

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastFired = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastFired >= fireInterval)
        {
            lastFired = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = bullet.transform.forward * 50;
        Destroy(bullet, 2.0f);
    }
}
