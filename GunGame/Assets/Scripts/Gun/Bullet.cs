using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Rigidbody rigid;
	public float speed = 1000f;
	public float power;
	public float reductiondistance;
	public int reductionrate;


	public DamageUI _damageUI;

	Vector3 initPos; //총알시작위치
	Vector3 bulletPos;//총알위치

	bool isReduction = false;//데미지 감소시작 여부

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
		initPos = transform.position;
		bulletPos= transform.position;


	}

	// Update is called once per frame
	void Update () {
		rigid.AddForce(transform.forward * speed);
		ReductionDamage();
		if (power <= 0)
			Destroy(this.gameObject);
	}
	void OnCollisionEnter(Collision col)
	{
		//if(col.gameObject.tag==("Wall"))
		//Destroy(this.gameObject);
	}

	public void DisplayDamage(GameObject obj) //데미지 표시
	{
		_damageUI.init(obj.transform.position, power);
		Instantiate(_damageUI.gameObject, _damageUI.screenPos, Quaternion.identity);
	}

	void ReductionDamage() //데미지 감소
	{
		float distance1 = Vector3.Distance(initPos, transform.position);
		if(!isReduction&&distance1>=reductiondistance)
		{
			isReduction = true;
			power -= reductionrate;
			bulletPos = transform.position;
		}
		if(isReduction)
		{
			float distance2 = Vector3.Distance(bulletPos, transform.position);
			if(distance2>=50)
			{
				power -= reductionrate;
				bulletPos = transform.position;
			}
		}
	}
}
