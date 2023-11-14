using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator_River_Tipe : MonoBehaviour
{
  public GameObject[] gridPrefabs;
  public int gridSizeX, gridSizeZ;
  private int gridSizeAddX, gridSizeAddZ;

  private GameObject[,] gridArray;
  private List<Vector3> emptyCells = new List<Vector3>();
  private List<Vector3> availablePositions = new List<Vector3>();
  int randomValue;

  // Вызывается при нажатии кнопки

  void Start()
  {
    gridSizeAddX = gridSizeX;
    gridSizeAddZ = gridSizeZ;
    // Инициализируем список доступных позиций
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
        // Выбираем случайную доступную позицию
        int index = Random.Range(0, availablePositions.Count);
        Vector3 spawnPosition = availablePositions[index];
        availablePositions.RemoveAt(index);

        // Выбираем случайный префаб из массива
        GameObject gridPrefab = gridPrefabs[Random.Range(0, gridPrefabs.Length)];

        // Создаем новый объект в выбранной позиции
        Instantiate(gridPrefab, spawnPosition, Quaternion.identity);
      }
    }

    switch (randomValue){
      case 0:
        for (int x = gridSizeAddX; x <= (gridSizeX + gridSizeAddX); x++)
        {
          for (int z = gridSizeAddZ; z <= (gridSizeZ + gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        gridSizeAddX += gridSizeX;
        gridSizeAddZ += gridSizeZ;
        randomValue= Random.Range(0, 7);
        break;
      case 1:
        for (int x = gridSizeAddX; x <= (gridSizeX + gridSizeAddX); x++)
        {
          for (int z = gridSizeAddZ; z <= (gridSizeZ + gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        gridSizeAddX += gridSizeX;
        randomValue = Random.Range(0, 7);
        break;
      case 2:
        for (int x = gridSizeAddX; x <= (gridSizeX + gridSizeAddX); x++)
        {
          for (int z = gridSizeAddZ; z <= (gridSizeZ + gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        gridSizeAddZ += gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
      case 3:
        for (int x = gridSizeAddX; x <= (gridSizeX + gridSizeAddX); x++)
        {
          for (int z = gridSizeAddZ; z <= (gridSizeZ + gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        gridSizeAddX -= gridSizeX;
        gridSizeAddZ -= gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
      case 4:
        for (int x = gridSizeAddX; x <= (gridSizeX + gridSizeAddX); x++)
        {
          for (int z = gridSizeAddZ; z <= (gridSizeZ + gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        gridSizeAddX -= gridSizeX;
        randomValue = Random.Range(0, 7);
        break;
      case 5:
        for (int x = gridSizeAddX; x <= (gridSizeX + gridSizeAddX); x++)
        {
          for (int z = gridSizeAddZ; z <= (gridSizeZ + gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        gridSizeAddZ -= gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
      case 6:
        for (int x = gridSizeAddX; x <= (gridSizeX + gridSizeAddX); x++)
        {
          for (int z = gridSizeAddZ; z <= (gridSizeZ + gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        gridSizeAddX -= gridSizeX;
        gridSizeAddZ += gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
      case 7:
        for (int x = gridSizeAddX; x <= (gridSizeX + gridSizeAddX); x++)
        {
          for (int z = gridSizeAddZ; z <= (gridSizeZ + gridSizeAddZ); z++)
          {
            availablePositions.Add(new Vector3(x, 0, z));
          }
        }
        gridSizeAddX += gridSizeX;
        gridSizeAddZ -= gridSizeZ;
        randomValue = Random.Range(0, 7);
        break;
    }
  }

}
