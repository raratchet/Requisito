using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public int width = 256;
    public int heigth = 256;

    public float offSetX = 100;
    public float offSetY = 100;
    
    public int depth = 20;

    public float scale = 20f;

    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        offSetX = Random.Range(0f,9999f);
        offSetY = Random.Range(0f, 9999f);
        depth = Random.Range(20, 50);
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

    }

    void Update()
    {
        
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width,depth,heigth);
        terrainData.SetHeights(0,0,GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heigths = new float[width, heigth];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < heigth; y++)
            {
                heigths[x, y] = CalculateHeigth(x, y);
            }
        }

        return heigths;
    }

    float CalculateHeigth(int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / heigth * scale;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
