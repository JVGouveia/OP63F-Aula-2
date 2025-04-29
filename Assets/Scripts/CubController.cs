using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.CompareTag("Player")){
            var hit = collision.gameObject;

            float randomX = UnityEngine.Random.Range(-15, 15);
            float randomZ = UnityEngine.Random.Range(-15, 15);

            Destroy(hit); // Destroi o objeto atingido
            Destroy(gameObject); // Destroi a bala
        }
    }
}
