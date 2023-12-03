using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Отвечает за цвет строения во время постановки
public class BuildingSettings : MonoBehaviour
{
  public Renderer MainRenderer;
  public Vector2Int Size = Vector2Int.one;
  private int _bonus;
  public string _districtTipe;
  public GameObject[] DistrictConectionsPrefabs;

  public int CheckDistrictBonus()
  {
    return _bonus;
  }

  public string CheckDistrictTipe()
  {
    return _districtTipe;
  }

  public void ConnectionCheck(/*string tipe, int side*/)
  {
    //  if (_districtTipe == tipe)
    //  {
    _bonus++;
    //   DistrictConectionsPrefabs[side].SetActive(true);
    //  }
  }
  public void SetTransparent(bool available)
  {
    if (available) MainRenderer.material.color = Color.green;
    else MainRenderer.material.color = Color.red;
  }

  public void SetNormal()
  {
    MainRenderer.material.color = Color.white;
  }

  private void OnDrawGizmosSelected()
  {
    for(int x=0; x < Size.x; x++)
    {
      for(int y=0; y < Size.y; y++)
      {
        if ((x + y) % 2 == 0) Gizmos.color = new Color(0.8f, 0f, 1f, 0.3f);
        else Gizmos.color = new Color(1f, 0.6f, 0f, 0.3f);

        Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
      }

    }
  }
}
