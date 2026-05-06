using System.Collections.Generic;
using UnityEngine;

public class GridManager : Singleton<GridManager>
{
    public float cellSize = 1f;

    Material mat;

    protected override void Awake()
    {
        base.Awake();
        mat = new Material(Shader.Find("Unlit/Color"));
    }

    //범위 조절할지랑, 언제 스냅 적용할지는 생각좀 해봐야겠네
    public Vector2Int WorldToGrid(Vector2 worldPos)
    {
        int x = Mathf.RoundToInt(worldPos.x / cellSize);
        int y = Mathf.RoundToInt(worldPos.y / cellSize);
        return new Vector2Int(x, y);
    }

    public Vector2 GridToWorld(Vector2Int gridPos)
    {
        return new Vector2(gridPos.x * cellSize, gridPos.y * cellSize);
    }

    Dictionary<Vector2Int, GameObject> occupied = new();

    public bool CanPlace(Vector2Int pos)
    {
        return !occupied.ContainsKey(pos);
    }

    public void PlaceUnit(Vector2Int pos, GameObject unit)
    {
        occupied[pos] = unit;
    }

}
