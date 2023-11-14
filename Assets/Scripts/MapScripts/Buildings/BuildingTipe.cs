using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingTipe : MonoBehaviour //Класс всех зданий
{
  protected int cost;
  [SerializeField] public int sizeX;
  [SerializeField] public int sizeZ;
  protected int coordinateX;
  protected int coordinateZ;

  [SerializeField] public GameObject[] BuildingPrefabs;

  public abstract void GetInfo();
  public void Build(int centerX, int centerZ)
  {
    CityGeneratorNew cityGeneratorNew = GetComponent<CityGeneratorNew>();
    int startX = Mathf.Max(1, (int)(centerX - sizeX/2.0));
    int endX = Mathf.Min(cityGeneratorNew.gridAll.GetLength(0), (int)(centerX + sizeX /2.0));
    int startZ = Mathf.Max(1, (int)(centerZ - sizeZ/2.0));
    int endZ = Mathf.Min(cityGeneratorNew.gridAll.GetLength(1), (int)(centerZ + sizeZ/2.0));
    int index = 0;

    for (int i = startX; i < endX; i++)
    {
      for (int j = startZ; j < endZ; j++)
      {
        if (i >= 0 && i < cityGeneratorNew.gridAll.GetLength(0) && j >= 0 && j < cityGeneratorNew.gridAll.GetLength(1))
        {
          GameObject obj = cityGeneratorNew.gridAll[i, j];
          if (cityGeneratorNew.gridAll[i, j] == null || obj.tag == "Location")
          {
            if (index < BuildingPrefabs.Length)
            {
              cityGeneratorNew.gridAll[i, j] = Instantiate(BuildingPrefabs[index], new Vector3(i, 0, j), Quaternion.identity) as GameObject;
              index++;
            }
            else
            {
              index = 0;
              cityGeneratorNew.gridAll[i, j] = Instantiate(BuildingPrefabs[index], new Vector3(i, 0, j), Quaternion.identity) as GameObject;
            }
          }
          else
          {
            Destroy(centerX, centerZ);
            i = endX;
            j = endZ;
          }
        }
      }
    }
  }
  public void Destroy(int centerX, int centerZ)
  {
    CityGeneratorNew cityGeneratorNew = GetComponent<CityGeneratorNew>();
    int startX = Mathf.Max(1, (int)(centerX - sizeX / 2.0));
    int endX = Mathf.Min(cityGeneratorNew.gridAll.GetLength(0), (int)(centerX + sizeX / 2.0));
    int startZ = Mathf.Max(1, (int)(centerZ - sizeZ / 2.0));
    int endZ = Mathf.Min(cityGeneratorNew.gridAll.GetLength(1), (int)(centerZ + sizeZ / 2.0));
    
    for (int i = startX; i < endX; i++)
    {
      for (int j = startZ; j < endZ; j++)
      {
        GameObject obj = cityGeneratorNew.gridAll[i, j];
        if (cityGeneratorNew.gridAll[i, j] == null || obj.tag == "Location" || obj.tag == "Building")
        {
          Destroy(cityGeneratorNew.gridAll[i, j]);
          cityGeneratorNew.gridAll[i, j] = null;
        }
      }
    }
  }
}
