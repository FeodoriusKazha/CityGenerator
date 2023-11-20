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
    // ���������, ��� �� ������ ���� ����� ������� ����
    if (Input.GetMouseButtonDown(0))
    {
      // ������� ��� �� ������� ������ � �����������, ���� ��������� ����
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      // ���������, ���������� �� ��� � ���-������
      if (Physics.Raycast(ray, out hit))
      {
        // ���� ��, �� ��������� ��� �������
        if (hit.collider.gameObject.tag == "Location")
        {
          Debug.Log("�����");
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
