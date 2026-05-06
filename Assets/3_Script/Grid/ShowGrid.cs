using UnityEngine;

public class ShowGrid : MonoBehaviour
{
    public float cellSize = 1;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int x = -10; x < 10; x++)
            for (int y = -10; y < 10; y++)
            {
                Vector2 pos = new Vector2(x, y) * cellSize;
                Gizmos.DrawWireCube(pos, Vector3.one * cellSize);
            }
    }
}
