using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hit : MonoBehaviour {

	public float hp = 1000;
	float bulletPower;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Bullet")
		{
			bulletPower = col.gameObject.GetComponent<Bullet>().power;
			col.gameObject.GetComponent<Bullet>().DisplayDamage(this.gameObject);
			Destroy(col.gameObject);
			hp -= bulletPower;

			if (hp <= 0)
				Destroy(gameObject);
		}
	}

}
