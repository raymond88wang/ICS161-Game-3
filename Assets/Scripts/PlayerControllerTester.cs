using System.Collections;
using UnityEngine;

public class PlayerControllerTester : MonoBehaviour
{
    public float walkSpeed = 3.0F;
    public float runSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float bodyRotateSpeed = 5.0F;
    public float armRotateSpeed = 50.0F;
    public float gravity = 20.0F;
    public CharacterController character;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject pointFrontLeft, pointFrontRight, armPointOfRotation, armPointToLook;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (character.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= walkSpeed;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= runSpeed;
            }
            else
            {
                moveDirection *= walkSpeed;
            }
            if (Input.GetKey(KeyCode.E))
            {
                RotateTowards(pointFrontRight);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                RotateTowards(pointFrontLeft);
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                DropItem();
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        character.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("Press Mouse2 to Pick Up!");
        }
        if (Input.GetKey(KeyCode.Mouse2))
        {
            PickUpItem(other.gameObject);
        }
    }

    private void RotateTowards(GameObject pointOfRotation)
    {
        Quaternion lookRotation = Quaternion.LookRotation(pointOfRotation.transform.position);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * bodyRotateSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Attack()
    {
        StartCoroutine(RotateArmUp(new Vector3(armPointToLook.transform.position.x * 90, 0f, 0f), 0.25f));
    }

    private void PickUpItem(GameObject item)
    {
    }

    private void DropItem()
    {
    }

    IEnumerator RotateArmDown(Vector3 byAngles, float inTime)
    {
        var fromAngle = armPointOfRotation.transform.rotation;
        var toAngle = Quaternion.Euler(armPointOfRotation.transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            armPointOfRotation.transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
            yield return null;
        }
    }

    IEnumerator RotateArmUp(Vector3 byAngles, float inTime)
    {
        yield return StartCoroutine(RotateArmDown(byAngles, inTime));
        var fromAngle = armPointOfRotation.transform.rotation;
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            armPointOfRotation.transform.rotation = Quaternion.Lerp(fromAngle, Quaternion.identity, t);
            yield return null;
        }
    }
}