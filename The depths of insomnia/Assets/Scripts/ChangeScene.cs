using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Название сцены, которую хотим загрузить
    public string sceneName;

    // Метод, который будет вызван при нажатии на кнопку
    public void OnClickChangeScene()
    {
        // Загружаем указанную сцену
        SceneManager.LoadScene(sceneName);
    }
}