using UnityEngine;

public class ShowGrid : MonoBehaviour
{
    float cellSize = 1;
    public bool isShow = true;
    public int width = 20;
    public int height = 10;

    private void Start()
    {
        //cellSize = GridManager.Instance.cellSize;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (!isShow) return;
        for (int x = -width; x < width; x++)
            for (int y = -height; y < height; y++)
            {
                Vector2 pos = new Vector2(x, y) * GridManager.Instance.cellSize;
                Gizmos.DrawWireCube(pos, Vector3.one * GridManager.Instance.cellSize);
            }
    }
}
