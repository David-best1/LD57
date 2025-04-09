using System.Linq;
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

    // ���������� ���������� ��������
    private int remainingMonsters;

    void Start()
    {
        // ������� ���������� ���� �������� �������� �� ������
        remainingMonsters = GameObject.FindGameObjectsWithTag(monsterTag).Length;
    }

    void Update()
    {
        if (remainingMonsters <= 0)
        {
            if (Vector3.Distance(player.transform.position, triggerPosition.position) < 2f)
            {
                LoadNextScene();
            }
        }
        remainingMonsters = GameObject.FindGameObjectsWithTag(monsterTag).Length;
    }

    // �������� ��������� �����
    void LoadNextScene()
    {
        SceneManager.LoadScene(1); // ��������� ��������� �����
    }
}