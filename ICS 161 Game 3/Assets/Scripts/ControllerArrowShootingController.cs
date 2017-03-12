using UnityEngine;

public class ControllerArrowShootingController : MonoBehaviour {

    public GameObject prefabArrow;
    public GameObject spawnPoint;
    public Transform camDirection;
    public float arrowForce;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("B")) 
        {
            spawnPoint = this.gameObject.transform.Find("ArrowSpawn").gameObject;
            GameObject Temp_Arrow = Instantiate(prefabArrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
            Rigidbody Temp_rb = Temp_Arrow.GetComponent<Rigidbody>();
            Temp_rb.AddForce(camDirection.transform.forward * arrowForce);
            Destroy(Temp_Arrow, 7);
        }
    }
}
