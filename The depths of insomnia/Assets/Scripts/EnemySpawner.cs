using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // ������ ����� ������
    public List<Transform> spawnPoints;

    // ��� ������ (���� �����)
    public GameObject enemyPrefab;

    // ����� ��� ������� ������
    public void SpawnEnemy()
    {
        // ���������, ��� � ��� ���� ���� �� ���� ����� ������
        if (spawnPoints.Count > 0)
        {
            // �������� ��������� ����� �� ������
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Transform selectedSpawnPoint = spawnPoints[randomIndex];

            // ������� ����� � ��������� �����
            Instantiate(enemyPrefab, selectedSpawnPoint.position, Quaternion.identity);

            // ������� �������������� �����, ����� ��� �� �������������� ��������
            spawnPoints.RemoveAt(randomIndex);

            Debug.Log($"���� ������� � ������� {selectedSpawnPoint.name}");
        }
        else
        {
            Debug.LogWarning("��� ��������� ����� ������!");
        }
    }
}