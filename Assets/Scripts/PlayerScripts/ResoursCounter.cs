using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoursCounter : MonoBehaviour
{
  private int _money;
  private int _production;
  private int _food;
  private int _people;

  public int GetResours(string tipe)
  {
    switch(tipe){
      case "Money":
      return _money;
      case "Production":
        return _production;
      case "Food":
        return _food;
      case "People":
        return _people;
      default:
        Debug.Log("Not real");
        return 0;
    }
  }

  public void AddResours(int amount, string tipe)
  {
    switch (tipe)
    {
      case "Money":
        _money += amount;
        break;
      case "Production":
        _production += amount;
        break;
      case "Food":
        _food += amount;
        break;
      case "People":
        _people += amount;
        break;
    }
  }

}
