using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
  //[SerializeField] int[,] roadGrid;
  [SerializeField] GameObject roadPrefabs;
  [SerializeField] GameObject copy;

  [SerializeField] int A,B;

  public void BuildRoad()
  {
    //roadGrid = new int[copy.GetComponent<CityGeneratorNew>().currentX, B];

    //for (int i = 0; i < copy.GetComponent<CityGeneratorNew>().currentX; i++)
    //{
    //  for (int j = 0; j < copy.GetComponent<CityGeneratorNew>().currentZ; j++)
    //  {
    //    if (j != B && i != A || i>A || j>B)
    //    {
    //      //Debug.Log("null");
    //    }
    //    else
    //    {
    //      Destroy(copy.GetComponent<CityGeneratorNew>().gridAll[i, j]);
    //      copy.GetComponent<CityGeneratorNew>().gridAll[i, j] = Instantiate(roadPrefabs, new Vector3(i + 0.5f, 0, j + 0.5f), Quaternion.identity);

    //    }

    //  }
    //}


  }
}
