using UnityEngine;

public class TargetLockController : MonoBehaviour {
    public GameObject nearestTarget = null;
    private bool spotted = false;

	public bool isTargetSpotted(GameObject target, float lookRange)
    {
        RaycastHit hit;
        Vector3 direction = target.transform.position - (transform.position + Vector3.up);

        Debug.DrawRay(transform.position, direction);

        spotted = Physics.Raycast(transform.position + Vector3.up, direction, out hit, lookRange) &&
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