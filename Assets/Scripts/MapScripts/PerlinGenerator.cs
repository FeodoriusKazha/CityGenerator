using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinGenerator : MonoBehaviour
{
  private Texture2D _texture;
  void Start()
  {
    _texture = new Texture2D(512, 512);
    GenerateTexture();
  }

  private void Update()
  {
    
  }
  public void GenerateTexture()
  {
    float[,] heights = new float[_texture.width, _texture.height];
    int iterations = 8;
    for (int k = 0; k < iterations; k++)
    {

      int skale = 1 << k;
      float[,] heightsT = new float[_texture.width / skale, _texture.height / skale];

      for (int y = 0; y < _texture.height / skale; y++)
      {
        for (int x = 0; x < _texture.width / skale; x++)
        {
          heightsT[x, y] = Random.Range(0f, 1f);
        }
      }

      for (int y = 0; y < _texture.height; y++)
      {
        for (int x = 0; x < _texture.width; x++)
        {
          float z0 = heightsT[x / skale, y / skale];
          float z1 = heightsT[(x / skale + 1) % (_texture.width / skale), y / skale];
          float z2 = heightsT[x / skale, (y / skale + 1) % (_texture.width / skale)];
          float z3 = heightsT[(x / skale + 1) % (_texture.width / skale), (y / skale + 1) % (_texture.width / skale)];
          float x0 = (x / skale * skale);
          float x1 = (x / skale * skale + skale);
          float y0 = (y / skale * skale);
          float y1 = (y / skale * skale + skale);
          float zx0 = z0 + (z1 - z0) * ((x - x0) / (x1 - x0));
          float zx1 = z2 + (z3 - z2) * ((x - x0) / (x1 - x0));
          float z = zx0 + (zx1 - zx0) * ((y - y0) / (y1 - y0));
          heights[x, y] += z / iterations;
        }
      }
    }
    for (int y = 0; y < _texture.height; y++)
    {
      for (int x = 0; x < _texture.width; x++)
      {
        float c = heights[x, y];
        Color color = new Color(c, c, c);
        _texture.SetPixel(x, y, color);
      }
    }
    _texture.Apply();
  }
}
