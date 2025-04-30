using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigerrController : MonoBehaviour
{
    public GameObject trapPrefab; // Prefab da armadilha a ser instanciado
    public float trapDuration = 5f; // Tempo que a armadilha fica ativa

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource sound = GetComponent<AudioSource>();
            if (sound != null)
            {
                sound.Play(); // Toca o som da armadilha
            }

            // Verifica o nome do prefab para definir o comportamento
            if (trapPrefab.name.Contains("Cube"))
            {
                for (int i = 0; i < 5; i++)
                {
                    float randomX = Random.Range(-10f, 10f);
                    float randomZ = Random.Range(-10f, 10f);

                    GameObject trapInstance = Instantiate(trapPrefab, new Vector3(randomX, 25, randomZ), Quaternion.identity);
                    Destroy(trapInstance, trapDuration);
                }
            }
            else if (trapPrefab.name.Contains("Flame_03_Hollow"))
            {
                StartCoroutine(ActivateFlameTrap());
            }
        }
    }

    private IEnumerator ActivateFlameTrap()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = true; // Ativa o MeshRenderer
        }
        
        yield return new WaitForSeconds(1f); // Espera 1 segundo
        
        Vector3 spawnPosition = transform.position + Vector3.up * 1f; // 1 unidade acima do chão
        GameObject trapInstance = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);
        Destroy(trapInstance, trapDuration);
        
        yield return new WaitForSeconds(trapDuration); // Espera o tempo de duração da armadilha
        
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false; // Desativa o MeshRenderer
        }
    }
}
