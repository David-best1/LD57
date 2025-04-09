using System.Linq;
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

    // Количество оставшихся монстров
    private int remainingMonsters;

    void Start()
    {
        // Считаем количество всех активных монстров на старте
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

    // Загрузка следующей сцены
    void LoadNextScene()
    {
        SceneManager.LoadScene(1); // Загружаем следующую сцену
    }
}