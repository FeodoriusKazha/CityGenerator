using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictBonus : MonoBehaviour
{
  public int _bonus;
  private string _districtTipe;
  public GameObject[] DistrictConectionsPrefabs; 

  public int CheckDistrictBonus()
  {
    return _bonus;
  }

  public void ConnectionCheck(string tipe, int side)
  {
    if(_districtTipe == tipe)
    {
      _bonus++;
      DistrictConectionsPrefabs[side].SetActive(true);
    }
  }

}
