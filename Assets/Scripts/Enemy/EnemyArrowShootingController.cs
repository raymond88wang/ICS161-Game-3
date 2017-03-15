using UnityEngine;

public class EnemyArrowShootingController : MonoBehaviour {
    public GameObject prefabArrow;
    public GameObject spawnPoint;
    public float arrowForce = 2050.0f;
    private TargetLockController targetLock;

    private void Awake()
    {
        targetLock = GetComponentInParent<TargetLockController>();
    }

    public void SpawnArrow() {
        Vector3 relativePosition = targetLock.nearestTarget.transform.position - spawnPoint.transform.position;
        spawnPoint.transform.rotation = Quaternion.LookRotation(relativePosition + Vector3.up);
        GameObject Temp_Arrow = Instantiate(prefabArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Temp_Arrow.transform.Rotate(Vector3.up * 90);
        Rigidbody Temp_rb = Temp_Arrow.GetComponent<Rigidbody>();
        Temp_rb.AddForce(spawnPoint.transform.forward * arrowForce);
        Destroy(Temp_Arrow, 7);
    }
}