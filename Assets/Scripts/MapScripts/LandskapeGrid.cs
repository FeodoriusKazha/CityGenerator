using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandskapeGrid : MonoBehaviour
{
  public int[,] landskapeGrid;
  public GameObject[] landPrefabs;
  public int landSizeX, landSizeZ;

  private float _offsetX, _offsetZ;

  //void Start()
  //{
  //  CityGeneratorNew cityGeneratorNew = GetComponent<CityGeneratorNew>();
  //  landskapeGrid = new int[landSizeX, landSizeZ];
  //  _offsetX = Random.Range(0f, 100f);
  //  _offsetZ = Random.Range(0f, 100f);

  //  for (int i = 0; i < landSizeX; i++)
  //  {
  //    for (int j = 0; j < landSizeZ; j++)
  //    {
  //      float xCoord = ((float)i / landSizeX) + _offsetX;
  //      float zCoord = ((float)j / landSizeZ) + _offsetZ;
  //      float perlinValue = Mathf.PerlinNoise(xCoord, zCoord);

  //      landskapeGrid[i, j] = Mathf.RoundToInt(perlinValue * 4);
  //      if (i < cityGeneratorNew.gridAll.GetLength(0) && j < cityGeneratorNew.gridAll.GetLength(1))
  //      {
  //        switch (landskapeGrid[i, j]) // Можно ввести индексы для моря и гор, чтобы была возможность на них строить
  //        {
  //          case 0:
  //            cityGeneratorNew.gridAll[i, j] = null;
  //            Instantiate(landPrefabs[0], new Vector3(i, 0, j), Quaternion.identity);
  //            break;
  //          case 1:
  //            cityGeneratorNew.gridAll[i, j] = null;
  //            Instantiate(landPrefabs[0], new Vector3(i, 0, j), Quaternion.identity);
  //            break;
  //          case 2:
  //            cityGeneratorNew.gridAll[i, j] = Instantiate(landPrefabs[1], new Vector3(i, 0, j), Quaternion.identity) as GameObject;
  //            break;
  //          case 3:
  //            cityGeneratorNew.gridAll[i, j] = Instantiate(landPrefabs[2], new Vector3(i, 0, j), Quaternion.identity) as GameObject;

  //            break;
  //        }
  //      }
  //    }

  //  }
  //}

  //public void CheckLand(GameObject[,] cityGrid)
  //{
  //  int gridSizeX = cityGrid.GetLength(0);
  //  int gridSizeZ = cityGrid.GetLength(1);
  //  for (int i = 0; i < gridSizeX; i++)
  //  {
  //    for (int j = 0; j < gridSizeZ; j++)
  //    {
  //      switch (landskapeGrid[i, j])
  //      {
  //        case 0:

  //          break;
  //        case 1:
  //          Destroy(cityGrid[i, j]);
  //          cityGrid[i, j] = Instantiate(landPrefabs[0], new Vector3(i, 0, j), Quaternion.identity) as GameObject;
  //          break;
  //        case 2:
  //          Destroy(cityGrid[i, j]);
  //          cityGrid[i, j] = Instantiate(landPrefabs[1], new Vector3(i, 0, j), Quaternion.identity) as GameObject;
  //          break;
  //      }
  //    }
  //  }
  //}
}
