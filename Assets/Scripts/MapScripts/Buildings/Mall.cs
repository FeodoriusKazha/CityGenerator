using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mall : BuildingTipe
{
  //[SerializeField] public GameObject[] BuildingPrefabs;

  public override void GetInfo()
  {
    Debug.Log("Это Молл");
  }
}
