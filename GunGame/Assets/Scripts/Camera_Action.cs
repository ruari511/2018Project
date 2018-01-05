using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Action : MonoBehaviour {

    public GameObject Player = null;

    public float offsetX = 0f;
    public float offsetY = 25f;
    public float offsetZ = -35f;

    public float followSpeed;

    Vector3 cameraPos;

	void Start ()
    {
      
    }
	
	void Update ()
    {
   
    }

    void LateUpdate()
    {
        cameraPos.x = Player.transform.position.x + offsetX;
        cameraPos.y = Player.transform.position.y + offsetY;
        cameraPos.z = Player.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPos, followSpeed * Time.deltaTime);
    }
}
