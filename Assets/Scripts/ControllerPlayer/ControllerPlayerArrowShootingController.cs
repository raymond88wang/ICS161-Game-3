using UnityEngine;

public class ControllerPlayerArrowShootingController : MonoBehaviour {
    public GameObject prefabArrow;
    public GameObject spawnPoint;
    public Transform camDirection;
    public float arrowForce = 750.0f;
    private float timer = 0.0f;
    private PlayerHealth player;

    private void Awake()
    {
        player = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("B") && timer >= player.attackCooldownTime)  //can add xbox control in or statement
        {
            GameObject Temp_Arrow = Instantiate(prefabArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            Temp_Arrow.transform.Rotate(Vector3.up * 90);
            Rigidbody Temp_rb = Temp_Arrow.GetComponent<Rigidbody>();
            Temp_rb.AddForce(camDirection.transform.forward * arrowForce);

            Destroy(Temp_Arrow, 7);
            timer = 0.0f;
        }
    }
}
