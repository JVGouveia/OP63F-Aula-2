using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigerrController : MonoBehaviour
{
    public GameObject trapPrefab; // Prefab of the trap to be instantiated
    public float trapDuration = 5f; // Duration for which the trap is active

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource sound = GetComponent<AudioSource>();
            if (sound != null)
            {
                sound.Play(); // Play the sound effect
            }
            sound.Play();
            
            for (int i = 0; i < 5; i++)
            {
                float randomX = Random.Range(-10f, 10f);
                float randomZ = Random.Range(-10f, 10f);

                GameObject trapInstance = Instantiate(trapPrefab, new Vector3(randomX, 25, randomZ), Quaternion.identity);
                Destroy(trapInstance, trapDuration); // Destroy the trap after the specified duration
            }
        }
    }
}
