using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Check : MonoBehaviour {
	GameObject[] _enemy;
	public Material m_a;
	public Material m_b;

	bool isPass = false; //이 문을 클리어했는지 여부
	bool isClose = false; //이 문이 닫혔는지 여부
	int iCount; // 자식오브젝트(적) 개수


	void Start () {
		iCount = transform.childCount;
		
		for (int i = 0; i< iCount; i++) //적 비활성화(후에 적생성 이펙트 추가되면 고침)
		{
			Transform _child = transform.GetChild(i);
			_child.gameObject.SetActive(false);
		}
		SpawnEnemy();
		
		m_a = gameObject.GetComponent<MeshRenderer>().material; //임시
	}
	

	void FixedUpdate()
	{
		iCount = transform.childCount;
		if(iCount==0) //자식 오브젝트가 남았는지 확인
		{
			ChangeColor();
			isPass = true;
		}
	}

	void ChangeColor() //임시
	{
		gameObject.GetComponent<MeshRenderer>().material = m_b;
	}

	void SpawnEnemy() //적생성 (현재는 오브젝트 활성화만 되도록해둠)
	{
		for (int i = 0; i < iCount; i++) 
		{
			Transform _child = transform.GetChild(i);
			_child.gameObject.SetActive(true);
		}

	}
}

