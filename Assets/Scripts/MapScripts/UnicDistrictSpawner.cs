using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicDistrictSpawner : MonoBehaviour
{
  public GameObject[] buildingPrefabs;
  public GameObject[,] gridAll;
  public RandomColoring randomColorScript;

  private int _landSizeX = 10;
  private int _landSizeZ = 10;
  private float _cellSize = 10f;

  void Awake()
  {
    Material newMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    Color randomColor = new Color(Random.value, Random.value, Random.value);
    newMaterial.color = randomColor;

    gridAll = new GameObject[_landSizeX, _landSizeZ];

    for (int i = 0; i < _landSizeX; i += 2)
    {
      for (int j = 0; j < _landSizeZ; j += 2)
      {
        GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];

        gridAll[i, j] = Instantiate(buildingPrefab, new Vector3(i, 0, j), Quaternion.identity) as GameObject;
        gridAll[i, j].transform.SetParent(transform);
        if (i == 0 || j == 0 || i >= _landSizeX - 2 || j >= _landSizeZ - 2) gridAll[i, j].SetActive(false);
        
        if (randomColorScript != null)
        {
          randomColorScript.TraverseChildren(gridAll[i, j].transform, new HashSet<Transform>(), newMaterial);
        }
      }
    }
  }

  public void ActiveSide(int side)
  {
    switch (side)
    {
      case 0:
        if (gridAll[0, 0] != null) gridAll[0, 0].SetActive(true);
        break;
      case 1:
        for (int i = 1; i < _landSizeX-2; i++)
        {
          if (gridAll[0, i] != null) gridAll[0, i].SetActive(true);
        }
        break;
      case 5:
        gridAll[8, 0].SetActive(true);
        break;
      case 3:
        for (int i = 1; i < _landSizeX - 2; i++)
        {
          if (gridAll[0, i] != null) gridAll[i, 0].SetActive(true);
        }
        break;
      case 6:
        for (int i = 1; i < _landSizeX-2; i++)
        {
          if (gridAll[8, i] != null) gridAll[8, i].SetActive(true);
        }
        break;
      case 2:
        if (gridAll[0, 8] != null) gridAll[0, 8].SetActive(true);
        break;
      case 4:
        for (int i = 1; i < _landSizeX-2; i++)
        {
          if (gridAll[i, 8] != null) gridAll[i, 8].SetActive(true);
        }
        break;
      case 7:
        if (gridAll[8, 8] != null) gridAll[8, 8].SetActive(true);
        break;
    }
  }
}
