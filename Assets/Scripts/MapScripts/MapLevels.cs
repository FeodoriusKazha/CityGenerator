using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevels : MonoBehaviour
{
  private int _mapLevel;


  public int GetMapLevel()
  {
    return _mapLevel;
  }

  public void ChangeLevel(int level)
  {
    _mapLevel = level;
  }
}
