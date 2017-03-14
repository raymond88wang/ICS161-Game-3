using UnityEngine;

public class PlayerArrowShootingController : MonoBehaviour {
    public GameObject prefabArrow;
    public GameObject spawnPoint;
    public Transform camDirection;
    public float arrowForce = 750.0f;
    private float timer = 0.0f;
    private PlayerHealth player;
    private PlayerPickUpController pickUp;

    private void Awake()
    {
        player = GetComponent<PlayerHealth>();
        pickUp = GetComponent<PlayerPickUpController>();
    }

    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= player.attackCooldownTime)
        {
            GameObject Temp_Arrow = Instantiate(prefabArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            Temp_Arrow.transform.Rotate(Vector3.up * 90);
            Rigidbody Temp_rb = Temp_Arrow.GetComponent<Rigidbody>();
            Temp_rb.AddForce(camDirection.transform.forward * arrowForce);
            if(pickUp.heldItem.name.Equals("Bow"))
            {
                pickUp.heldItem.GetComponent<AudioSource>().Play();
            }
            Destroy(Temp_Arrow, 7);
            timer = 0.0f;
        }
    }
}
