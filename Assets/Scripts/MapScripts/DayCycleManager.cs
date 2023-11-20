using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
  [Range(0, 1)]
  [SerializeField] private float TimeOfDay;
  [SerializeField] private float DayDuration = 30f;
  [SerializeField] private Light Sun;

  public AnimationCurve SunCurse;
  private float sunIntennsity;


  void Start()
  {
    sunIntennsity = Sun.intensity;
  }

  void Update()
  {
    TimeOfDay += Time.deltaTime / DayDuration;
    if (TimeOfDay >= 1) TimeOfDay -= 1;
    Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f, 180, 0);
    Sun.intensity = sunIntennsity * SunCurse.Evaluate(TimeOfDay);
  }
}
