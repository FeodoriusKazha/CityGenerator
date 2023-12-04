using UnityEngine;
using System.Collections.Generic;

public class RandomPrefabSpawner : MonoBehaviour
{
  // Список префабов для случайного выбора
  public List<GameObject> prefabs;

  // Размеры района для заполнения
  public Vector3 areaSize;

  // Количество префабов для создания
  public int prefabCount;

  void Start()
  {
    if (prefabs.Count > 0)
    {
      for (int i = 0; i < prefabCount; i++)
      {
        // Выбрать случайный префаб
        GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];

        // Выбрать случайное положение внутри района
        Vector3 position = transform.position + new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            Random.Range(-areaSize.y / 2, areaSize.y / 2),
            Random.Range(-areaSize.z / 2, areaSize.z / 2));

        // Создать экземпляр префаба
        Instantiate(prefab, position, Quaternion.identity);
      }
    }
  }

  // Отображение района в редакторе
  void OnDrawGizmos()
  {
    Gizmos.DrawWireCube(transform.position, areaSize);
  }
}