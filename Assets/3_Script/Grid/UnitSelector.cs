using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    GameObject selectedObject;
    void Update()
    {
        //마우스 다운
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                selectedObject = hit.collider.gameObject;
                Logger.Log("선택됨: " + selectedObject.name);
            }
        }

        //흠
        //마우스 다운
        if (selectedObject != null && Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int gridPos = GridManager.Instance.WorldToGrid(mousePos);

            Vector2 snapPos = GridManager.Instance.GridToWorld(gridPos);
            selectedObject.transform.position = snapPos;

        }

        //마우스 업
        if (Input.GetMouseButtonUp(0))
        {
            put();
            selectedObject = null; // 선택 해제
        }
    }

    public void put()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int gridPos = GridManager.Instance.WorldToGrid(mousePos);

        if (GridManager.Instance.CanPlace(gridPos))
        {
            Vector2 worldPos = GridManager.Instance.GridToWorld(gridPos);
            //Instantiate(unitPrefab, worldPos, Quaternion.identity);
            GridManager.Instance.PlaceUnit(gridPos, selectedObject);
        }
    }
}
