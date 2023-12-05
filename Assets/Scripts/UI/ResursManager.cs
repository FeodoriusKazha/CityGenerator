using TMPro;
using UnityEngine;

public class ResursManager : MonoBehaviour
{
  public TextMeshProUGUI[] textMeshPro;
  public DisplayParameter displayParameter;

  void Awake()
  {
    StartNextTurn();
  }
  public void ChangeSize(string tipe)
  {
    switch (tipe)
    {
      case "Money":
        displayParameter.ChangeParameterSize(2, tipe, textMeshPro[0]);
        break;
      case "Production":
        displayParameter.ChangeParameterSize(2, tipe, textMeshPro[1]);
        break;
      case "Food":
        displayParameter.ChangeParameterSize(2, tipe, textMeshPro[2]);
        break;
      case "People":
        displayParameter.ChangeParameterSize(2, tipe, textMeshPro[3]);
        break;
    }
  }
  public void StartNextTurn()
  {
    displayParameter.ChangeParametr("Money", textMeshPro[0]);
    displayParameter.ChangeParametr("Production", textMeshPro[1]);
    displayParameter.ChangeParametr("Food", textMeshPro[2]);
    displayParameter.ChangeParametr("People", textMeshPro[3]);
  }
}