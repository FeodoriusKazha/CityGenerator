using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Отвечает за цвет строения во время постановки
public class BuildingSettings : MapSettings
{
  //public Renderer MainRenderer;
  public UnicDistrictSpawner unicDistrictSpawner;
  
  private int _bonus;
  public string _districtTipe;
  
  private int _cost = 10;
  private int _upkeep = 1;
  

  public int CheckDistrictBonus()
  {
    return _bonus;
  }

  public string CheckDistrictTipe()
  {
    return _districtTipe;
  }

  public int CheckDistrictUpkeep()
  {
    return _upkeep;
  }

  public int CheckDistrictCost()
  {
    return _cost;
  }

  public void ConnectionCheck(int x, int y)
  {
    int side = 0;
    _bonus++;
    switch (x)
    {
      case -1:
        switch (y)
        {
          case -1:
            side = 0;
            break;
          case 0:
            side = 1;
            break;
          case 1:
            side = 2;
            break;
        }
        break;
      case 0:
        switch (y)
        {
          case -1:
            side = 3;
            break;
          case 1:
            side = 4;
            break;
        }
        break;
      case 1:
        switch (y)
        {
          case -1:
            side = 5;
            break;
          case 0:
            side = 6;
            break;
          case 1:
            side = 7;
            break;
        }
        break;
    }
    unicDistrictSpawner.ActiveSide(side);
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

        Gizmos.DrawCube(transform.position + new Vector3(x * _cellSize, 0, y * _cellSize), new Vector3(1 * _cellSize, 0.1f, 1 * _cellSize));
      }

    }
  }
}
