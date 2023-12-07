using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingByDrag : MonoBehaviour
{
  public Vector3Int GridSize = new Vector3Int(10, 10, 3);
  private BuildingSettings[,,] grid;
  private BuildingSettings flyingBuilding;
  public DisplayParameter displayParameter;
  public ResursManager resursManager;
  public ResoursCounter resoursCounter;
  public UnicDistrictSpawner unicDistrictSpawner;
  private Camera mainCamera;
  private float _cellSize = 10f;

  private void Awake()
  {
    grid = new BuildingSettings[GridSize.x, GridSize.y, GridSize.z];
    mainCamera = Camera.main;
  }

  public void StartPlaysingBuilding(GameObject Prefab)
  {
    BuildingSettings buildingPrefab = Prefab.GetComponent<BuildingSettings>();
    Debug.Log(resoursCounter.GetResours("Money"));
    Debug.Log(buildingPrefab.CheckDistrictCost());
    if (resoursCounter.GetResours("Money") >= buildingPrefab.CheckDistrictCost())
    {
      if (flyingBuilding != null) Destroy(flyingBuilding.gameObject);

      flyingBuilding = Instantiate(buildingPrefab);
      resoursCounter.AddResours(-flyingBuilding.CheckDistrictCost(), "Money");
      resursManager.UpdateResursBars();
    }
  }

  private void Update()
  {
    if(flyingBuilding != null)
    {
      var groundPlane = new Plane(Vector3.up, Vector3.zero);
      Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

      if(groundPlane.Raycast(ray, out float position))
      {
        Vector3 worldPosition = ray.GetPoint(position);

        int x = Mathf.RoundToInt(worldPosition.x / _cellSize);
        int y = Mathf.RoundToInt(worldPosition.z / _cellSize);

        bool available = true;

        if (x < 0 || x > GridSize.x - flyingBuilding.Size.x) available = false;
        if (y < 0 || y > GridSize.y - flyingBuilding.Size.y) available = false;

        if (available && IsPlaceTaken(x, y)) available = false;

        flyingBuilding.transform.position = new Vector3(x * _cellSize, 0, y * _cellSize);
        flyingBuilding.SetTransparent(available);

        if (available && Input.GetMouseButtonDown(0))
        {
          CheckNeighbors(x, y, flyingBuilding);
          if(flyingBuilding.CheckDistrictTipe() != "Food") resoursCounter.AddResoursBonus(-flyingBuilding.CheckDistrictUpkeep(), "Food");
          PlaceFlyingBuilding(x,y);  
        }
      }
    }
  }

  private bool IsPlaceTaken(int placeX, int placeY)
  {
    for (int x = 0; x < flyingBuilding.Size.x; x++)
    {
      for (int y = 0; y < flyingBuilding.Size.y; y++)
      {
        if(grid[placeX + x, placeY + y, 0] != null) return true;
      }
    }

    return false;
  }

  private void PlaceFlyingBuilding(int placeX, int placeY)
  {
    for (int x = 0; x < flyingBuilding.Size.x; x++)
    {
      for (int y = 0; y < flyingBuilding.Size.y; y++)
      {
        grid[placeX + x, placeY + y, 0] = flyingBuilding;
      }
    }

    flyingBuilding.SetNormal();
    flyingBuilding = null;
  }
  private void CheckNeighbors(int placeX, int placeY, BuildingSettings building)
  {
    for (int x = -1; x <= building.Size.x; x++)
    {
      for (int y = -1; y <= building.Size.y; y++)
      {
        for (int z = -1; z <= building.Size.z; z++)
        {
          if (placeX + x >= 0 && placeX + x < GridSize.x && placeY + y >= 0 && placeY + y < GridSize.y)
          {
            BuildingSettings neighbor = grid[placeX + x, placeY + y, 0];
            if (neighbor != null && neighbor.CheckDistrictTipe() == building.CheckDistrictTipe())
            {
              neighbor.ConnectionCheck(-x, -y);
              building.ConnectionCheck(x, y);
              resursManager.ChangeSize(neighbor.CheckDistrictTipe()); // Ќужно проверить правильность работы
            }
          }
        }
      }
    }
  }
  void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.white;

    for (int x = 0; x <= GridSize.x; x++)
    {
      Gizmos.DrawLine(new Vector3(x * _cellSize, 0, 0), new Vector3(x * _cellSize, 0, GridSize.y * _cellSize));
    }

    for (int y = 0; y <= GridSize.y; y++)
    {
      Gizmos.DrawLine(new Vector3(0, 0, y * _cellSize), new Vector3(GridSize.x * _cellSize, 0, y * _cellSize));
    }
  }
}

