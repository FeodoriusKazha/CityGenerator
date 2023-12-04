using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColoring : MonoBehaviour
{
  public void TraverseChildren(Transform parent, HashSet<Transform> visited, Material newMaterial)
  {
    foreach (Transform child in parent)
    {
      if (visited.Contains(child))
      {
        Debug.LogWarning("Cycle detected: " + child.name);
        continue;
      }

      visited.Add(child);

      if (child.name == "Light" || child.tag == "Light")
      {
        child.GetComponent<MeshRenderer>().material = newMaterial;
      }

      TraverseChildren(child, visited, newMaterial);
    }
  }
}
