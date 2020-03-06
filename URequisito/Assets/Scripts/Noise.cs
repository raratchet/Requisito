using UnityEngine;

public class Noise : MonoBehaviour
{
    int width = 256;
    int height = 256;

    public float scale = 10f;

    public float offSetX = 100f;
    public float offSetY = 100f;

    public Renderer rendera;
    void Start()
    {
        rendera = GetComponent<Renderer>();

        offSetX = Random.Range(0f, 9999f);
        offSetY = Random.Range(0f, 9999f);
    }

    void Update()
    {
        rendera.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();

        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + offSetX;
        float yCoord = (float)y / height * scale + offSetY;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }

}
