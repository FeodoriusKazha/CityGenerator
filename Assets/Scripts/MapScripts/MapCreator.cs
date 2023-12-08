using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
  public Vector3Int GridSize = new Vector3Int(10, 10, 10);
  public MapSettings[,,] gridAll;
  public GameObject terrainPrefab;

  public int octaves = 4; // Количество октав
  public float persistence = 0.5f; // Постоянство (влияет на амплитуду)
  public float lacunarity = 2f; // Лакунарность (влияет на частоту)

  private float _cellSize = 10f;

  void Awake()
  {
    float _offsetX = Random.Range(0f, 100f);
    float _offsetZ = Random.Range(0f, 100f);
    gridAll = new MapSettings[GridSize.x, GridSize.y, GridSize.z];

    for (int i = 0; i < GridSize.x; i++)
    {
      for (int j = 0; j < GridSize.y; j++)
      {
        float amplitude = 1f;
        float frequency = 1f;
        float perlinValue = 0;

        for (int k = 0; k < octaves; k++)
        {
          float xCoord = ((float)i / GridSize.x * frequency) + _offsetX;
          float zCoord = ((float)j / GridSize.y * frequency) + _offsetZ;

          perlinValue += Mathf.PerlinNoise(xCoord, zCoord) * amplitude;

          amplitude *= persistence;
          frequency *= lacunarity;
        }

        int _offsetY = Mathf.RoundToInt(perlinValue * 6);
        if (_offsetY > GridSize.z)
        {
          _offsetY = GridSize.z;
        }

        for (int z = 0; z < _offsetY; z++)
        {
          MapSettings terrain = Instantiate(terrainPrefab, new Vector3(i, z, j), Quaternion.identity).GetComponent<MapSettings>();
          gridAll[i, j, z] = terrain;
        }
      }
    }
  }
}
