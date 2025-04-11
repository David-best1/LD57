using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Список точек спавна
    public List<Transform> spawnPoints;

    // Пул врагов (если нужен)
    public GameObject enemyPrefab;

    // Метод для запуска спавна
    public void SpawnEnemy()
    {
        // Проверяем, что у нас есть хотя бы одна точка спавна
        if (spawnPoints.Count > 0)
        {
            // Выбираем случайную точку из списка
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform selectedSpawnPoint = spawnPoints[randomIndex];

            // Спавним врага в выбранной точке
            Instantiate(enemyPrefab, selectedSpawnPoint.position, Quaternion.identity);

            // Удаляем использованную точку, чтобы она не использовалась повторно
            spawnPoints.RemoveAt(randomIndex);

            Debug.Log($"Враг спавнен в позиции {selectedSpawnPoint.name}");
        }
        else
        {
            Debug.LogWarning("Нет доступных точек спавна!");
        }
    }
}