using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBuildTipe : MonoBehaviour
{
  [SerializeField] public int building = 1;


  public void TakingBuildTipe(int index)
  {
    building = index;
  }
}
