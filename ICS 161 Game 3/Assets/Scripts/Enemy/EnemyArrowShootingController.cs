using UnityEngine;

public class EnemyArrowShootingController : MonoBehaviour {
    public GameObject prefabArrow;
    public GameObject spawnPoint;
    public float arrowForce;
    public float timer = 0.0f;
    public float attackCooldownTime = 1.0f;

    void Update () {
        timer += Time.deltaTime;
        if (timer >= attackCooldownTime)
        {
            GameObject Temp_Arrow = Instantiate(prefabArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            Rigidbody Temp_rb = Temp_Arrow.GetComponent<Rigidbody>();
            Temp_rb.AddForce(transform.forward * arrowForce);
            Destroy(Temp_Arrow, 7);
            timer = 0.0f;
        }
    }
}
