using UnityEngine;

public class TapokDestroyer : MonoBehaviour
{
    // ���������� �����
    public string monsterTag = "Monster"; // ��� �������

    void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������ � ����� "Monster"
        if (other.CompareTag(monsterTag))
        {
            // ���������� �������
            Destroy(other.gameObject);
        }
    }
}