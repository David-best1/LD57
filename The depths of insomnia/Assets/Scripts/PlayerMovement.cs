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
        // Повороты по горизонтали и вертикали
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        // Вращение по горизонтали
        transform.Rotate(Vector3.up, horizontalRotation * rotationSpeed * Time.fixedDeltaTime);

        // Вращение по вертикали без ограничений
        transform.Rotate(Vector3.right, -verticalRotation * rotationSpeed * Time.fixedDeltaTime);
    }
}