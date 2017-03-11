using UnityEngine;

public class ControllerArrowShootingController : MonoBehaviour {

    public GameObject prefabArrow;
    public GameObject spawnPoint;
    public Transform camDirection;
    public float arrowForce = 1000.0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey("joystick 1 button 0"))  //can add xbox control in or statement
        {
            GameObject Temp_Arrow = Instantiate(prefabArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            Rigidbody Temp_rb = Temp_Arrow.GetComponent<Rigidbody>();
            Temp_rb.AddForce(camDirection.transform.forward * arrowForce);
            Destroy(Temp_Arrow, 7);
        }
    }
}
