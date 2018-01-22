using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour {

	public float ScoreDelay = 0.5f;

	public Vector3 targetPos; //대상 위치
	public Vector3 screenPos; //스크린 좌표
	float Damage;

	void Awake()
	{
		
	}
	// Use this for initialization
	void Start()
	{
		
		StartCoroutine("DisplayScore");
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = transform.position;
		pos.y += 0.001f;
		transform.position = pos;
	}
	IEnumerator DisplayScore()
	{
		yield return new WaitForSeconds(ScoreDelay);

		for (float a = 1; a >= 0; a -= 0.05f)
		{
			transform.GetComponent<GUIText>().material.color = new Vector4(1, 1, 1, a);
			yield return new WaitForFixedUpdate();
		}

		Destroy(gameObject);
	}

	public void init(Vector3 _targetPos, float _damage)
	{
		
		targetPos = _targetPos;
		Damage = _damage;
		screenPos = Camera.main.WorldToScreenPoint(targetPos);
		screenPos.x = screenPos.x / Screen.width;
		screenPos.y = screenPos.y / Screen.height;
		transform.GetComponent<GUIText>().text = Damage.ToString();
		transform.position = screenPos;
	}
}
