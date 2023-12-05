using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoursCounter : MonoBehaviour
{
  private int _money = 10;
  private int _production;
  private int _food;
  private int _people;

  private int _moneyBonus;
  private int _productionBonus;
  private int _foodBonus;
  private int _peopleBonus;

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

  public int GetResoursBonus(string tipe)
  {
    switch (tipe)
    {
      case "Money":
        return _moneyBonus;
      case "Production":
        return _productionBonus;
      case "Food":
        return _foodBonus;
      case "People":
        return _peopleBonus;
      default:
        Debug.Log("Not real");
        return 0;
    }
  }

  public void AddResoursBonus(int amount, string tipe)
  {
    switch (tipe)
    {
      case "Money":
        _moneyBonus += amount;
        break;
      case "Production":
        _productionBonus += amount;
        break;
      case "Food":
        _foodBonus += amount;
        break;
      case "People":
        _peopleBonus += amount;
        break;
    }
  }

}
