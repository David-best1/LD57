using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // ��� ��� ��������
    public string monsterTag = "Monster";

    // ������� ��� �������� �� ��������� �����
    public Transform triggerPosition;

    // �����
    public GameObject player;

    // ������ �������� ��������
    private List<GameObject> monsters = new List<GameObject>();

    void Start()
    {
        // ������� ���� �������� �������� �� ������
        foreach (var monster in GameObject.FindGameObjectsWithTag(monsterTag))
        {
            monsters.Add(monster);
            Debug.Log($"������ {monster.name} �������� � ������.");
        }
    }

    void Update()
    {
        if (monsters.Count <= 0 && IsPlayerNearTrigger())
        {
            Debug.Log("��� ������� ���������� � ����� ����� ��������. ��������� ����� �����...");
            LoadNextScene();
        }
    }

    // ���������, ��������� �� ����� ����� � ���������
    bool IsPlayerNearTrigger()
    {
        var distanceToTrigger = Vector3.Distance(player.transform.position, triggerPosition.position);
        Debug.Log($"���������� �� ��������: {distanceToTrigger}");
        return distanceToTrigger < 5f;
    }

    // ���������� ���������� ���������� �������� ��� �����������
    public void MonsterDestroyed(GameObject monster)
    {
        if (monsters.Contains(monster))
        {
            monsters.Remove(monster);
            Debug.Log($"������ {monster.name} ������ �� ������. �������� ��������: {monsters.Count}");
        }
    }

    // �������� ��������� �����
    void LoadNextScene()
    {
        Debug.Log("�������� ��������� �����...");
        SceneManager.LoadScene(1); // ��������� ��������� �����
    }
}