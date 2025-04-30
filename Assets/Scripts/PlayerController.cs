using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    public float velocidadeHorizontal;
    public float velocidadeVertical;

    public float FireRate;  // The number of bullets fired per second
    private float lastfired;      // The value of Time.time at the last firing moment
    
    public int points;

    void Start(){
        PointsController.instance.ResetPoints(); // Reseta os pontos no início do jogo
    }

    // Update is called once per frame
    void Update()
    {
        // Movimentação do jogador
        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadeHorizontal;
        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * velocidadeVertical;
        
        transform.Rotate(0, horizontalInput, 0);
        transform.Translate(0, 0, verticalInput);


        // Atirar com o mouse
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Shoot();
        // }

        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastfired > 1 / FireRate)
            {
                lastfired = Time.time;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        // Instancia a bala na posição do ponto de spawn
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = bullet.transform.forward * 50; // Define a velocidade da bala
        Destroy(bullet, 2.0f); // Destroi a bala após 2 segundos
    }
}
