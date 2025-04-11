using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Camera mainCamera; // Добавляем ссылку на камеру

    [Header("Movement Settings")]
    [SerializeField]
    private float movementForce = 100f; // Сила, применяемая для перемещения
    [SerializeField]
    private float drag = 0.05f; // Торможение, замедляющее движение

    [Header("Rotation Settings")]
    [SerializeField]
    private float rotationSpeed = 50f; // Скорость вращения

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        // Получаем направление движения от клавиатуры
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // Преобразуем направление движения в систему координат камеры
        Vector3 moveDirection = mainCamera.transform.TransformDirection(moveInput);

        // Нормализуем и применяем силу к rigidbody
        if (moveDirection.magnitude > 0)
        {
            rb.AddForce(moveDirection.normalized * movementForce);
        }

        // Постепенно уменьшаем скорость движения (drag)
        rb.velocity *= (1f - drag);
    }

    private void Rotate()
    {
        // Получаем изменения позиции мыши
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);

        // Применяем поворот по осям
        transform.Rotate(Vector3.up, mouseMovement.x * rotationSpeed * Time.fixedDeltaTime); // Горизонтальное вращение
        transform.Rotate(Vector3.right, -mouseMovement.y * rotationSpeed * Time.fixedDeltaTime); // Вертикальное вращение

        // Возвращаем курсор в центр экрана
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}