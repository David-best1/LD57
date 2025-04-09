using UnityEngine;

public class TapokDestroyer : MonoBehaviour
{
    // Назначение тегов
    public string monsterTag = "Monster"; // Тег монстра

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, касается ли объект с тегом "Monster"
        if (other.CompareTag(monsterTag))
        {
            // Уничтожаем монстра
            Destroy(other.gameObject);
        }
    }
}