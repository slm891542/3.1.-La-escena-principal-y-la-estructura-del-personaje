using UnityEngine;

public class BubbleGrid : MonoBehaviour
{
    public int rows = 6; // Número de filas
    public int cols = 7; // Número de columnas
    public float bubbleSize = 1.2f; // Espaciado entre burbujas
    public GameObject[] bubblePrefabs; // Prefabs de burbujas de diferentes colores

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                SpawnBubble(r, c);
            }
        }
    }

    void SpawnBubble(int r, int c)
    {
        Vector2 position = new Vector2(c * bubbleSize, r * -bubbleSize);
        GameObject bubble = Instantiate(
            bubblePrefabs[Random.Range(0, bubblePrefabs.Length)], 
            position, 
            Quaternion.identity
        );
        bubble.transform.parent = transform; // Agruparlas en el Grid
    }
}
