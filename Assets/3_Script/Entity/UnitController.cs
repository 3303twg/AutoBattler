using UnityEngine;
using UnityEngine.UIElements;

public class UnitController : MonoBehaviour
{
    public Transform target;
    public UnitStat unitStat;

    public float searchDistance = 3f;

    [SerializeField] private LayerMask targetLayer = 1<<8;

    Collider2D[] unitList = new Collider2D[30];

    private void Update()
    {
        TestMove();
    }
    public void GetTarget()
    {
        Transform closest = null;

        float minDist = float.MaxValue;

        //레거시라네 근데 걍 써야지
        int cnt = Physics2D.OverlapCircleNonAlloc(transform.position, searchDistance, unitList, targetLayer);

        if (cnt <= 0) return;
        for(int i = 0; i< cnt; i++)
        {
            if (unitList[i].gameObject != this.gameObject)
            {
                float dist = (unitList[i].transform.position - transform.position).sqrMagnitude;
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = unitList[i].transform;
                }
            }
        }
        target = closest;

    }

    public void TestMove()
    {
        if (target == null)
        {
            GetTarget();
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, unitStat.moveSpeed * Time.deltaTime);
    }
}
