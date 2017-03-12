using UnityEngine;

public class EnemyArrowShootingController : MonoBehaviour {
    public GameObject prefabArrow;
    public GameObject spawnPoint;
    public float arrowForce = 2050.0f;
    private float timer = 0.0f;
    private EnemyHealth enemy;
    private TargetLockController targetLock;

    private void Awake()
    {
        enemy = GetComponent<EnemyHealth>();
        targetLock = GetComponent<TargetLockController>();
    }

    void Update () {
        timer += Time.deltaTime;
        if (timer >= enemy.attackCooldownTime)
        {
            if (targetLock.nearestTarget != null)
            {
                Vector3 relativePosition = targetLock.nearestTarget.transform.position - spawnPoint.transform.position;
                spawnPoint.transform.rotation = Quaternion.LookRotation(relativePosition + Vector3.up);
                GameObject Temp_Arrow = Instantiate(prefabArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
                Rigidbody Temp_rb = Temp_Arrow.GetComponent<Rigidbody>();
                Temp_rb.AddForce(spawnPoint.transform.forward * arrowForce);
                Destroy(Temp_Arrow, 7);
                timer = 0.0f;
            }
        }
    }
}