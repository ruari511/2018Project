using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour { //모든 총의 기본이 되는 베이스 클래스

	[SerializeField]
	int ID; //해당 총기의 고유 id
	string GunNamekr; //총기 외부 이름

	int GunReductionrate=10; // 플레이어와 멀어질수록 감소되는 데미지값
	float GunReductiondistance=15; //데미지가 감소되기 시작하는 최소거리
	//감소가 되지 않을때에는 -1을 넣는다

	public float Gun_Damage = 70;//총의 데미지
	public float GunSpeaker=3; //총의 연사력
	public float GunBulletspeed = 1000;//탄환 한 개의 속도
	public int GunHit=0; // 조준점을 기준으로 총알이 벗어나는 정도
	public int GunMinload; //총의 장전 수
	public int GunMaxload = 30; //총의 장탄 수
	public float GunReloatTime; //총의 재장전 시간



	Transform GunPos; // 총알 생성 위치
	


	public Bullet _bullet; //총알



	// Use this for initialization
	void Awake () {
		GunPos = transform.GetChild(0); //총알생성위치를 불러옴 근데 더좋은방법이 있지않을까..
		GunMinload = GunMaxload; //장전

		_bullet.power = Gun_Damage; //데미지설정
		_bullet.speed = GunBulletspeed; //속도설정
		_bullet.reductiondistance = GunReductiondistance;
		_bullet.reductionrate = GunReductionrate;
	}
	
	// Update is called once per frame
	void Update () { //키 고쳐야됨
		if (Input.GetKeyDown(KeyCode.Space)&&GunMinload>0)
		{
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
