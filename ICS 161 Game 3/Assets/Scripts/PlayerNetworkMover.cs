using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkMover : Photon.MonoBehaviour {

    private Vector3 position;
    private Quaternion rotation;
    private float smoothing = 10.0f;
    public float health = 100f;

	void Start () {
        // enabled all scripts/cameras if you are the local player
		if(photonView.isMine)
        {
            GetComponent<PlayerController>().enabled = true;
            GetComponentInChildren<SimpleSmoothMouseLook>().enabled = true;
            foreach (Camera cam in GetComponentsInChildren<Camera>())
                cam.enabled = true;

            //transform.Find("Weapon Camera/Weapon").gameObject.layer = 8;
        }
        else
        {
            StartCoroutine("UpdateData");
        }
	}

    IEnumerator UpdateData()
    {
        while(true)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothing);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smoothing);
            yield return null;
        }
    }


    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(health);
        }
        else
        {
            position = (Vector3)stream.ReceiveNext();
            rotation = (Quaternion)stream.ReceiveNext();
            health = (float)stream.ReceiveNext();
        }
    }

    /*
    [RPC]
    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //restart level after 3 seconds?
            //how to restart on both?
            //might be called on all in this function anyway??
            //video 1:17-ish for details on how to apply the damage from other scripts
        }
    }
    */
	
}
