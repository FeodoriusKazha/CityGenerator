using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
  public GameObject[] buildingPrefabs;
  public int districtSizeX, districtSizeZ, districtCount;
  private List<List<bool>> grid;
  private int currentX = 0; // ������� ������� �� X
  private int currentZ = 0; // ������� ������� �� Z
  private List<Vector3> availablePositions = new List<Vector3>();

  void Start()
  {
    grid = new List<List<bool>>();
    for (int i = 0; i < districtSizeX; i++)
    {
      grid.Add(new List<bool>());
      for (int j = 0; j < districtSizeZ; j++)
      {
        grid[i].Add(false);
      }
    }
  }

  public void GridFillerEasy()
  {
    for (int i = 0; i < districtSizeX; i++)
    {
      for (int j = 0; j < districtSizeZ; j++)
      {
        //if (!grid[i, j]) // ���� ������ �� ���������
        //{
          GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
          Instantiate(buildingPrefab, new Vector3(currentX + i, 0, j), Quaternion.identity);
          //grid[i, j] = true; // �������� ������ ��� �����������
        //}
      }
    }
    currentX += districtSizeX;
  }

  public void GridFiller()
  {
    for (int i = -currentX; i <= currentX + districtSizeX; i++)
    {
      for (int j = -currentZ; j <= currentZ + districtSizeZ; j++)
      {
        if (i < districtSizeX && j < districtSizeZ && !grid[i][j]) // ���� ������ �� ���������
        {
          GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
          Instantiate(buildingPrefab, new Vector3(currentX + i, 0, j), Quaternion.identity);
          grid[i][j] = true; // �������� ������ ��� �����������
        }
      }
    }

    currentX += districtSizeX; // ����������� ������ ����� �� X
    currentZ += districtSizeZ; // ����������� ������ ����� �� Z

    // ��������� ����� ������ � ������� � �����
    for (int i = 0; i < grid.Count; i++)
    {
      for (int j = grid[i].Count; j <= currentZ + districtSizeZ; j++)
      {
        grid[i].Add(false);
      }
    }
    for (int i = grid.Count; i <= currentX + districtSizeX; i++)
    {
      List<bool> newRow = new List<bool>();
      for (int j = 0; j <= currentZ + districtSizeZ; j++)
      {
        newRow.Add(false);
      }
      grid.Add(newRow);
    }
}

  public void SpawnDistrict()
  {
    for (int x = 0; x < districtSizeX; x++)
    {
      for (int z = 0; z < districtSizeZ; z++)
      {
        // �������� ��������� ��������� �������
        int index = Random.Range(0, availablePositions.Count);
        Vector3 spawnPosition = availablePositions[index];
        availablePositions.RemoveAt(index);

        // �������� ��������� ������ �� �������
        GameObject buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];

        // ������� ����� ������ � ��������� �������
        Instantiate(buildingPrefab, spawnPosition, Quaternion.identity);
      }
    }

    // ��������� ����� ��������� ������� ��� ���������� ������
    int startX = Random.Range(-districtCount, districtCount) * districtSizeX;
    int startZ = Random.Range(-districtCount, districtCount) * districtSizeZ;

    for (int x = startX; x < startX + districtSizeX; x++)
    {
      for (int z = startZ; z < startZ + districtSizeZ; z++)
      {
        Vector3 newPosition = new Vector3(x, 0, z);
        if (!availablePositions.Contains(newPosition))
        {
          availablePositions.Add(newPosition);
        }
      }
    }
  }
}
