using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour { //모든 총의 기본이 되는 베이스 클래스

	[SerializeField]
	int ID; //해당 총기의 고유 id

	public float Gun_Damage; //총의 데미지
	public float GunSpeaker=3; //총의 연사력
	public int GunMinload; //총의 장전 수
	public int GunMaxload = 30; //총의 장탄 수
	public float GunReloatTime; //총의 재장전 시간

	Transform GunPos; // 총알 생성 위치
	


	public Bullet _bullet;



	// Use this for initialization
	void Start () {
		GunPos = transform.GetChild(0);
		GunMinload = GunMaxload;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)&&GunMinload>0)
		{
			//GunPos = transform.GetChild(0);
			//	Instantiate(_bullet.gameObject, GunPos.transform.position, Quaternion.identity);

			//	GunMinload--;
			StartCoroutine("Shoot", GunSpeaker);

		}

		if (Input.GetKeyDown(KeyCode.LeftControl))
			GunMinload = GunMaxload;

	}

	IEnumerator Shoot(float _gunSpeaker)
	{
		for (int i = 0; i < _gunSpeaker; i++)
		{
			Instantiate(_bullet.gameObject, GunPos.transform.position, Quaternion.identity);
			GunMinload--;
			yield return new WaitForSeconds(0.5f/ _gunSpeaker);
		}
		
	}
}
