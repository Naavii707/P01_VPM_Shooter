using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyVariant1; // Asigna el prefab del enemigo 1 en el Inspector
    public GameObject enemyVariant2; // Asigna el prefab del enemigo 2 en el Inspector
    public GameObject victoryObject; // Asigna el objeto de victoria en el Inspector
    public GameObject winScreen; // Asigna el panel WinScreen en el Inspector
    public int spawnCount = 5;
    public float spawnInterval = 5f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
        ShowVictory();
    }

    void SpawnEnemy()
    {
        if (enemyVariant1 == null || enemyVariant2 == null)
        {
            Debug.LogError("Faltan prefabs de enemigos en el Inspector");
            return;
        }

        GameObject enemyToSpawn = Random.value > 0.5f ? enemyVariant1 : enemyVariant2;
        Instantiate(enemyToSpawn, Vector3.zero, Quaternion.identity);
    }

    void ShowVictory()
    {
        if (victoryObject != null)
        {
            victoryObject.SetActive(true);
        }
        else
        {
            Debug.LogError("No se ha asignado un objeto de victoria en el Inspector");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && victoryObject.activeSelf)
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("No se ha asignado el objeto WinScreen en el Inspector");
        }
    }
}

