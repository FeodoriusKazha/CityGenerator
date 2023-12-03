using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
  // �������� �������
  public Material objectMaterial;

  // �������� ������� ����� ����������� �����
  public float changeInterval = 1.0f;

  void Awake()
  {
    // �������� �������� �������
    //objectMaterial = GetComponent<Renderer>().material;

    // ������ �������� ��� ��������� �����
    StartCoroutine(ChangeColor());
  }

  IEnumerator ChangeColor()
  {
    while (true)
    {
      // ������� ��������� ����
      Color randomColor = new Color(Random.value, Random.value, Random.value);

      // ��������� ���� � ��������� �������
      objectMaterial.color = randomColor;

      // ��������� �������� �������� ������� ����� ��������� ���������� �����
      yield return new WaitForSeconds(changeInterval);
    }
  }
}
