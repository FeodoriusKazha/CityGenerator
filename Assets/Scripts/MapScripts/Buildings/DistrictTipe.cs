using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictTipe : MonoBehaviour
{
  public GameObject[] buildingPrefab;
  public BuildingByDrag buildingByDrag;
  public void ChoseDistrict(int index)
  {
    buildingByDrag.StartPlaysingBuilding(buildingPrefab[index]);
  }
}
