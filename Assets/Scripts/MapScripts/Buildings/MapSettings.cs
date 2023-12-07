using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSettings : MonoBehaviour
{
  private int _mapLevel;
  public Renderer MainRenderer;
  public Vector3Int Size = Vector3Int.one;
  protected float _cellSize = 10f;

  public int GetMapLevel()
  {
    return _mapLevel;
  }

  public void ChangeLevel(int level)
  {
    _mapLevel = level;
  }
}
