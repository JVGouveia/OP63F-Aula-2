using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{

    private GameObject player;
    public AudioClip deathSound;
    
    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            var hit = collision.gameObject;

            float randomX = UnityEngine.Random.Range(-15, 15);
            float randomZ = UnityEngine.Random.Range(-15, 15);

            GameObject iceCream = Instantiate(Resources.Load("IceCream", typeof(GameObject))) as GameObject; // Instancia o objeto atingido em uma nova posição aleatória
            iceCream.transform.position = new Vector3(randomX, 1f, randomZ); // Define a nova posição do objeto atingido
            
            if (player != null) {
                // Calcula a direção do iceCream em relação ao jogador
                Vector3 directionToPlayer = player.transform.position - iceCream.transform.position;
                directionToPlayer.y = 0; // Ignora a diferença de altura
                iceCream.transform.rotation = Quaternion.LookRotation(directionToPlayer);

                PointsController.instance.AddPoints(1); // Adiciona pontos ao jogador
            } else {
                Debug.LogWarning("Player não encontrado na cena.");
            }

            Destroy(hit); // Destroi o objeto atingido
            Destroy(gameObject); // Destroi a bala
        }else if (collision.gameObject.CompareTag("Player")){
            var hit = collision.gameObject;

            // Desvincula a câmera
            Camera.main.transform.parent = null;
            
            // Toca o som de morte
            AudioSource audio = player.GetComponent<AudioSource>();
            if (audio != null && deathSound != null)
            {
                audio.PlayOneShot(deathSound);
            }

            Destroy(hit, deathSound.length); // Destroi o objeto atingido
            Destroy(gameObject); // Destroi a bala
        }
    }
}