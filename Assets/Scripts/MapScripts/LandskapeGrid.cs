using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandskapeGrid : MonoBehaviour
{
  public Vector3Int GridSize = new Vector3Int(10, 10, 3);
  private BuildingSettings[,,] _grid;
  //public MapSettings mapSettings;


  private float _offsetX, _offsetZ, _offsetY;

  private void Awake()
  {
    _grid = new BuildingSettings[GridSize.x, GridSize.y, GridSize.z];
  }

  void Start()
  {
    //CityGeneratorNew cityGeneratorNew = GetComponent<CityGeneratorNew>();

    _offsetX = Random.Range(0f, 100f);
    _offsetZ = Random.Range(0f, 100f);

    for (int i = 0; i < GridSize.x; i++)
    {
      for (int j = 0; j < GridSize.y; j++)
      {
        float xCoord = ((float)i / GridSize.x) + _offsetX;
        float zCoord = ((float)j / GridSize.y) + _offsetZ;
        float perlinValue = Mathf.PerlinNoise(xCoord, zCoord);

        _offsetY = Mathf.RoundToInt(perlinValue * 4);
        //if (i < cityGeneratorNew.gridAll.GetLength(0) && j < cityGeneratorNew.gridAll.GetLength(1))
        //{
        //  switch (landskapeGrid[i, j]) // Можно ввести индексы для моря и гор, чтобы была возможность на них строить
        //  {
        //    case 0:
        //      cityGeneratorNew.gridAll[i, j] = null;
        //      Instantiate(landPrefabs[0], new Vector3(i, 0, j), Quaternion.identity);
        //      break;
        //    case 1:
        //      cityGeneratorNew.gridAll[i, j] = null;
        //      Instantiate(landPrefabs[0], new Vector3(i, 0, j), Quaternion.identity);
        //      break;
        //    case 2:
        //      cityGeneratorNew.gridAll[i, j] = Instantiate(landPrefabs[1], new Vector3(i, 0, j), Quaternion.identity) as GameObject;
        //      break;
        //    case 3:
        //      cityGeneratorNew.gridAll[i, j] = Instantiate(landPrefabs[2], new Vector3(i, 0, j), Quaternion.identity) as GameObject;

        //      break;
        //  }
      }
    }
  }
}


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
  //}
