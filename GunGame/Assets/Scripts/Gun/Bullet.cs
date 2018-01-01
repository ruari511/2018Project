using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Rigidbody rigid;
	public float speed = 1000f;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rigid.AddForce(transform.forward * speed);
	}
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag==("Wall"))
		Destroy(this.gameObject);
	}
}
