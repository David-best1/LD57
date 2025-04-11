using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Camera mainCamera; // ��������� ������ �� ������

    [Header("Movement Settings")]
    [SerializeField]
    private float movementForce = 100f; // ����, ����������� ��� �����������
    [SerializeField]
    private float drag = 0.05f; // ����������, ����������� ��������

    [Header("Rotation Settings")]
    [SerializeField]
    private float rotationSpeed = 50f; // �������� ��������

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        // �������� ����������� �������� �� ����������
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // ����������� ����������� �������� � ������� ��������� ������
        Vector3 moveDirection = mainCamera.transform.TransformDirection(moveInput);

        // ����������� � ��������� ���� � rigidbody
        if (moveDirection.magnitude > 0)
        {
            rb.AddForce(moveDirection.normalized * movementForce);
        }

        // ���������� ��������� �������� �������� (drag)
        rb.velocity *= (1f - drag);
    }

    private void Rotate()
    {
        // �������� ��������� ������� ����
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);

        // ��������� ������� �� ����
        transform.Rotate(Vector3.up, mouseMovement.x * rotationSpeed * Time.fixedDeltaTime); // �������������� ��������
        transform.Rotate(Vector3.right, -mouseMovement.y * rotationSpeed * Time.fixedDeltaTime); // ������������ ��������

        // ���������� ������ � ����� ������
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}