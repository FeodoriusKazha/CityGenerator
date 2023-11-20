using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGeneratorNew : MonoBehaviour
{
  public GameObject[] buildingPrefabs;
  public GameObject[,] gridAll;
  
  [SerializeField] private int size;

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
}
