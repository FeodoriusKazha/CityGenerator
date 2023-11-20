using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator_River_Tipe : MonoBehaviour
{
  public GameObject[] gridPrefabs;
  public int gridSizeX, gridSizeZ;

  private int _gridSizeAddX, _gridSizeAddZ;
  private int randomValue;
  private GameObject[,] gridArray;
  private List<Vector3> emptyCells = new List<Vector3>();
  private List<Vector3> availablePositions = new List<Vector3>();

  void Start()
  {
    _gridSizeAddX = gridSizeX;
    _gridSizeAddZ = gridSizeZ;
    
    for (int x = -gridSizeX; x <= gridSizeX; x++)
    {
      for (int z = -gridSizeZ; z <= gridSizeZ; z++)
      {
        availablePositions.Add(new Vector3(x, 0, z));
      }
    }
  }

  public void AltSpawnGrid()
  {
    for (int x = 0; x < 100; x++)
    {
      SpawnGrid();
    }
  }
  public void SpawnGrid()
  {
    for (int x = 0; x < gridSizeX; x++)
    {
      for (int z = 0; z < gridSizeZ; z++)
      {
        int index = Random.Range(0, availablePositions.Count);
        Vector3 spawnPosition = availablePositions[index];
        availablePositions.RemoveAt(index);

        GameObject gridPrefab = gridPrefabs[Random.Range(0, gridPrefabs.Length)];

        Instantiate(gridPrefab, spawnPosition, Quaternion.identity);
      }
    }

    switch (randomValue){
      case 0:
        for (int x = _gridSizeAddX; x <= (gridSizeX + _gridSizeAddX); x++)
        {
          for (int z = _gridSizeAddZ; z <= (gridSizeZ + _gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        _gridSizeAddX += gridSizeX;
        _gridSizeAddZ += gridSizeZ;
        randomValue= Random.Range(0, 7);
        break;
      case 1:
        for (int x = _gridSizeAddX; x <= (gridSizeX + _gridSizeAddX); x++)
        {
          for (int z = _gridSizeAddZ; z <= (gridSizeZ + _gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        _gridSizeAddX += gridSizeX;
        randomValue = Random.Range(0, 7);
        break;
      case 2:
        for (int x = _gridSizeAddX; x <= (gridSizeX + _gridSizeAddX); x++)
        {
          for (int z = _gridSizeAddZ; z <= (gridSizeZ + _gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        _gridSizeAddZ += gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
      case 3:
        for (int x = _gridSizeAddX; x <= (gridSizeX + _gridSizeAddX); x++)
        {
          for (int z = _gridSizeAddZ; z <= (gridSizeZ + _gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        _gridSizeAddX -= gridSizeX;
        _gridSizeAddZ -= gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
      case 4:
        for (int x = _gridSizeAddX; x <= (gridSizeX + _gridSizeAddX); x++)
        {
          for (int z = _gridSizeAddZ; z <= (gridSizeZ + _gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        _gridSizeAddX -= gridSizeX;
        randomValue = Random.Range(0, 7);
        break;
      case 5:
        for (int x = _gridSizeAddX; x <= (gridSizeX + _gridSizeAddX); x++)
        {
          for (int z = _gridSizeAddZ; z <= (gridSizeZ + _gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        _gridSizeAddZ -= gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
      case 6:
        for (int x = _gridSizeAddX; x <= (gridSizeX + _gridSizeAddX); x++)
        {
          for (int z = _gridSizeAddZ; z <= (gridSizeZ + _gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        _gridSizeAddX -= gridSizeX;
        _gridSizeAddZ += gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
      case 7:
        for (int x = _gridSizeAddX; x <= (gridSizeX + _gridSizeAddX); x++)
        {
          for (int z = _gridSizeAddZ; z <= (gridSizeZ + _gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        _gridSizeAddX += gridSizeX;
        _gridSizeAddZ -= gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
    }
  }

}
