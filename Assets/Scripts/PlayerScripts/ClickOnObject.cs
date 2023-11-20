using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnObject : MonoBehaviour
{
    void Update()
    {
    CityGeneratorNew cityGeneratorNew = GetComponent<CityGeneratorNew>();
    Mall mall = GetComponent<Mall>();
    TakeBuildTipe takeBuildTipe = GetComponent<TakeBuildTipe>();
    // Проверяем, был ли сделан клик левой кнопкой мыши
    if (Input.GetMouseButtonDown(0))
    {
      // Создаем луч из позиции камеры в направлении, куда указывает мышь
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      // Проверяем, столкнулся ли луч с чем-нибудь
      if (Physics.Raycast(ray, out hit))
      {
        // Если да, то проверяем тег объекта
        if (hit.collider.gameObject.tag == "Location")
        {
          Debug.Log("попал");
          Vector3 hitPoint = hit.point;
          int i = Mathf.RoundToInt(hitPoint.x);
          int j = Mathf.RoundToInt(hitPoint.z);
          switch (takeBuildTipe.building)
          {
            case 0:

              break;
            case 1:
              cityGeneratorNew.GenerateCitiByPoint(i, j);
              break;
            case 2:
              mall.Build(i, j);
              break;
          }
        }
      }
    }
  }
}
