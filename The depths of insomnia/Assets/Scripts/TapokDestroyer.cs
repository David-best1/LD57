using UnityEngine;

public class TapokDestroyer : MonoBehaviour
{
    // Назначение тегов
    public string monsterTag = "Monster"; // Тег монстра

    // Ссылка на SceneTransitionManager
    public SceneTransitionManager transitionManager;

    void OnTriggerEnter(Collider other)
    {
        // Проверяем, касается ли объект с тегом "Monster"
        if (other.CompareTag(monsterTag))
        {
            Debug.Log($"Объект {other.name} столкнулся с триггером.");

            // Уничтожаем монстра
            Destroy(other.gameObject);
            Debug.Log($"Объект {other.name} уничтожен.");

            // Вызываем функцию MonsterDestroyed в SceneTransitionManager
            transitionManager.MonsterDestroyed(other.gameObject);
            Debug.Log($"Функция MonsterDestroyed вызвана для объекта {other.name}.");
        }
    }
}