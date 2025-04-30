using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrapController : MonoBehaviour
{
    public AudioClip deathSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;

            // Desvincula a câmera
            Camera.main.transform.parent = null;

            // Toca o som de morte
            AudioSource audio = player.GetComponent<AudioSource>();
            if (audio != null && deathSound != null)
            {
                audio.PlayOneShot(deathSound);
            }

            Destroy(player, deathSound.length); // Destroi player
            Destroy(gameObject); // Destroi armadilha
        }
    }
}