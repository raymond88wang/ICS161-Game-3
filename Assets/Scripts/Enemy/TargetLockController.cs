using UnityEngine;

public class TargetLockController : MonoBehaviour {
    public GameObject nearestTarget = null;
    private bool spotted = false;

	public bool isTargetSpotted(GameObject target, float lookRange)
    {
        RaycastHit hit;
        Vector3 direction = target.transform.position - transform.position;

        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), direction);

        spotted = Physics.Raycast(transform.position + new Vector3(0,0.5f,0), direction, out hit, lookRange) &&
            (hit.collider.gameObject.CompareTag("Player1") || hit.collider.gameObject.CompareTag("Player2"));

        if(spotted)
        {
            if (nearestTarget == null)
            {
                nearestTarget = target;
            }
            else
            {
                if (Vector3.Distance(transform.position, target.transform.position) < Vector3.Distance(transform.position, nearestTarget.transform.position))
                {
                    nearestTarget = target;
                }
            }
        }
        else
        {
            nearestTarget = null;
        }
        return spotted;
    }

    public bool isNearestTargetInRange(float range)
    {
        if (nearestTarget == null)
        {
            return false;
        }
        else
        {
            return Vector3.Distance(transform.position, nearestTarget.transform.position) <= range;
        }
    }
}