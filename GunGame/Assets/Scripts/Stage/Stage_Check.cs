using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Check : MonoBehaviour {
	GameObject[] _enemy;
	public Material m_a;
	public Material m_b;
	// Use this for initialization
	void Start () {
		m_a = gameObject.GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
		_enemy = GameObject.FindGameObjectsWithTag("Enemy");
		if (_enemy.Length == 0)
		{
			ChangeColor();
		}

	}
	void FixedUpdate()
	{
		_enemy = GameObject.FindGameObjectsWithTag("Enemy");
		if(_enemy.Length==0)
		{
			ChangeColor();
		}
	}

	void ChangeColor()
	{
		gameObject.GetComponent<MeshRenderer>().material = m_b;
	}
}

