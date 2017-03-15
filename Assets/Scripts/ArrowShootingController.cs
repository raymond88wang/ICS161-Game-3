using UnityEngine;

public class ArrowShootingController : MonoBehaviour {
    public GameObject prefabArrow;
    public GameObject spawnPoint;
    public Transform camDirection;
    public float arrowForce = 800.0f;

    private void Awake()
    {
        enabled = false;
    }

    public void SpawnArrow()
    {
        GameObject Temp_Arrow = Instantiate(prefabArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Temp_Arrow.transform.Rotate(Vector3.up * 90);
        Rigidbody Temp_rb = Temp_Arrow.GetComponent<Rigidbody>();
        Temp_rb.AddForce(camDirection.transform.forward * arrowForce);
        GetComponent<AudioSource>().Play();
        Destroy(Temp_Arrow, 7);
    }
}
