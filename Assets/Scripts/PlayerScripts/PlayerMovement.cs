using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 10.0f; // �������� �����������
  public float rotationSpeed = 1000.0f; // �������� ��������

  void Update()
  {
    float moveHorizontal = Input.GetAxis("Horizontal"); // �������� ���� � �������������� ������ (A � D)
    float moveVertical = Input.GetAxis("Vertical"); // �������� ���� � ������������ ������ (W � S)

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // ������� ������ ��������

    // ���������� ������ ������������ ������
    transform.position += Camera.main.transform.TransformDirection(movement) * speed * Time.deltaTime;

    // ������� ������ ��� �������� ����
    if (Input.GetMouseButton(1)) // ������ ������ ����
    {
      transform.rotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0);
    }
  }
}
