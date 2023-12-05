using TMPro;
using UnityEngine;

public class DisplayParameter : MonoBehaviour
{
  //public TextMeshProUGUI textMeshPro;
  public ResoursCounter resoursCounter;

  public void ChangeParameterSize(int value, string tipe, TextMeshProUGUI textMeshPro)
  {
    resoursCounter.AddResoursBonus(value, tipe);
    textMeshPro.text = resoursCounter.GetResours(tipe).ToString() + " (" + resoursCounter.GetResoursBonus(tipe).ToString() + ")";

  }
  public void ChangeParametr(string tipe, TextMeshProUGUI textMeshPro)
  {
    resoursCounter.AddResours(resoursCounter.GetResoursBonus(tipe), tipe);
    textMeshPro.text = resoursCounter.GetResours(tipe).ToString() +" (" + resoursCounter.GetResoursBonus(tipe).ToString() + ")";
  }
  public void DisplayParametr(string tipe, TextMeshProUGUI textMeshPro)
  {
    textMeshPro.text = resoursCounter.GetResours(tipe).ToString() + " (" + resoursCounter.GetResoursBonus(tipe).ToString() + ")";
  }
}