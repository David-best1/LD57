using UnityEngine;

public class TapokDestroyer : MonoBehaviour
{
    // ���������� �����
    public string monsterTag = "Monster"; // ��� �������

    // ������ �� SceneTransitionManager
    public SceneTransitionManager transitionManager;

    void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������ � ����� "Monster"
        if (other.CompareTag(monsterTag))
        {
            Debug.Log($"������ {other.name} ���������� � ���������.");

            // ���������� �������
            Destroy(other.gameObject);
            Debug.Log($"������ {other.name} ���������.");

            // �������� ������� MonsterDestroyed � SceneTransitionManager
            transitionManager.MonsterDestroyed(other.gameObject);
            Debug.Log($"������� MonsterDestroyed ������� ��� ������� {other.name}.");
        }
    }
}