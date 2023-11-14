using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGeneratorNew : MonoBehaviour
{
  [SerializeField] public GameObject[] buildingPrefabs;
  [SerializeField] int size;
  [SerializeField] public GameObject[,] gridAll;

  void Start()
  {
    LandskapeGrid landskapeGrid = GetComponent<LandskapeGrid>();
    gridAll = new GameObject[landskapeGrid.landSizeX, landskapeGrid.landSizeZ];
  }

  public void GenerateCitiByPoint(int centerX, int centerZ)
  {
    int startX = Mathf.Max(0, centerX - size);
    int endX = Mathf.Min(gridAll.GetLength(0), centerX + size);
    int startZ = Mathf.Max(0, centerZ - size);
    int endZ = Mathf.Min(gridAll.GetLength(1), centerZ + size);

    for (int i = startX; i < endX; i++)
    {
      for (int j = startZ; j < endZ; j++)
      {
        GameObject obj = gridAll[i, j];
        if (gridAll[i, j] == null || obj.tag == "Location")
        {
          GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];

          gridAll[i, j] = Instantiate(buildingPrefab, new Vector3(i, 0, j), Quaternion.identity) as GameObject;

        }
      }
    }
  }
  
  //public void GridFiller()
  //{
  //  currentX += districtSizeX;
  //  currentZ += districtSizeZ;
  //  DistrictFiller(0, 0);
  //  iteration++;
  //}
  //public void DistrictFiller(int i, int j)
  //{
  //  LandskapeGrid landskapeGrid = GetComponent<LandskapeGrid>();
  //  if (landskapeGrid.landskapeGrid.GetLength(0) >= currentX)
  //  {
  //    if (landskapeGrid.landskapeGrid.GetLength(1) >= currentZ)
  //    {
  //      if (iteration != 0) gridAll = GridCheck(gridAll);
  //        for (; i < currentX; i++)
  //        {
  //          for (; j < currentZ; j++)
  //          {
  //            if (gridAll[i, j] == null)
  //            {
  //              GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
  //              //gridAll[gridCount, i, j] = Instantiate(buildingPrefab, new Vector3(i + 1, 0, j + 1), Quaternion.identity) as GameObject;
                
  //              gridAll[i, j] = Instantiate(buildingPrefab, new Vector3(i, 0, j), Quaternion.identity) as GameObject;

  //            }
  //          }
          
  //      }
  //      landskapeGrid.CheckLand(gridAll);
  //    }
  //  }
  //}

  //public GameObject[,] GridCheck(GameObject[,] grid)
  //{
  //  GameObject[,] gridExample = new GameObject[currentX, currentZ];

  //  for (int i = 0; i < grid.Length / districtSizeX / iteration / 4; i++)
  //  {
  //    for (int j = 0; j < grid.Length / districtSizeZ / iteration / 4; j++)
  //    {
  //      {
  //        gridExample[i, j] = grid[i, j];
  //      }
  //    }
  //  }
  //  return gridExample;
  //}
}
