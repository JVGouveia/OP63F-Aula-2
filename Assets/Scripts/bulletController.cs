using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.CompareTag("Enemy")){
            var hit = collision.gameObject;

            float randomX = UnityEngine.Random.Range(-15, 15);
            float randomZ = UnityEngine.Random.Range(-15, 15);

            GameObject iceCream = Instantiate(Resources.Load("IceCream", typeof(GameObject))) as GameObject; // Instancia o objeto atingido em uma nova posição aleatória
            iceCream.transform.position = new Vector3(randomX, 1f, randomZ); // Define a nova posição do objeto atingido
            iceCream.transform.rotation = Quaternion.Euler(0,  UnityEngine.Random.Range(0, 360), 0); // Define a rotação do objeto atingido

            Destroy(hit); // Destroi o objeto atingido
            Destroy(gameObject); // Destroi a bala
        }
    }
}
