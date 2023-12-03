using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
  // Материал объекта
  public Material objectMaterial;

  // Интервал времени между изменениями цвета
  public float changeInterval = 1.0f;

  void Awake()
  {
    // Получить материал объекта
    //objectMaterial = GetComponent<Renderer>().material;

    // Начать корутину для изменения цвета
    StartCoroutine(ChangeColor());
  }

  IEnumerator ChangeColor()
  {
    while (true)
    {
      // Создать случайный цвет
      Color randomColor = new Color(Random.value, Random.value, Random.value);

      // Применить цвет к материалу объекта
      objectMaterial.color = randomColor;

      // Подождать заданный интервал времени перед следующим изменением цвета
      yield return new WaitForSeconds(changeInterval);
    }
  }
}
