using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 10.0f; // скорость перемещения
  public float rotationSpeed = 1000.0f; // скорость вращения

  void Update()
  {
    float moveHorizontal = Input.GetAxis("Horizontal"); // получаем ввод с горизонтальных клавиш (A и D)
    float moveVertical = Input.GetAxis("Vertical"); // получаем ввод с вертикальных клавиш (W и S)

    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // создаем вектор движения

    // Перемещаем игрока относительно камеры
    transform.position += Camera.main.transform.TransformDirection(movement) * speed * Time.deltaTime;

    // Убираем вертикальное движение, чтобы игрок не начал летать или падать
    //transform.position = new Vector3(transform.position.x, 0, transform.position.z);

    // Вращаем камеру при движении мыши
    if (Input.GetMouseButton(1)) // правая кнопка мыши
    {
      transform.rotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0);
    }
  }
}
