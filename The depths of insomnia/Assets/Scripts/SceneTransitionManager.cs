using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // Тег для монстров
    public string monsterTag = "Monster";

    // Триггер для перехода на следующую сцену
    public Transform triggerPosition;

    // Игрок
    public GameObject player;

    // Список активных монстров
    private List<GameObject> monsters = new List<GameObject>();

    void Start()
    {
        // Находим всех активных монстров на старте
        foreach (var monster in GameObject.FindGameObjectsWithTag(monsterTag))
        {
            monsters.Add(monster);
            Debug.Log($"Монстр {monster.name} добавлен в список.");
        }
    }

    void Update()
    {
        if (monsters.Count <= 0 && IsPlayerNearTrigger())
        {
            Debug.Log("Все монстры уничтожены и игрок возле триггера. Загружаем новую сцену...");
            LoadNextScene();
        }
    }

    // Проверяет, находится ли игрок рядом с триггером
    bool IsPlayerNearTrigger()
    {
        var distanceToTrigger = Vector3.Distance(player.transform.position, triggerPosition.position);
        Debug.Log($"Расстояние до триггера: {distanceToTrigger}");
        return distanceToTrigger < 5f;
    }

    // Уменьшение количества оставшихся монстров при уничтожении
    public void MonsterDestroyed(GameObject monster)
    {
        if (monsters.Contains(monster))
        {
            monsters.Remove(monster);
            Debug.Log($"Монстр {monster.name} удален из списка. Осталось монстров: {monsters.Count}");
        }
    }

    // Загрузка следующей сцены
    void LoadNextScene()
    {
        Debug.Log("Загрузка следующей сцены...");
        SceneManager.LoadScene(1); // Загружаем следующую сцену
    }
}