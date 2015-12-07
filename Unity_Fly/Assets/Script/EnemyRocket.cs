using UnityEngine;
using System.Collections;

public class EnemyRocket : MonoBehaviour {

	public float m_speed = 10;    // 子弹飞行速度
	public float m_liveTime = 1.5f;  	// 生存时间
	public int m_power = 1;// 伤害
	protected Transform m_trasform;


	// Use this for initialization
	void Start () {
		m_trasform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//生存时间
		m_liveTime -= Time.deltaTime;
		if (m_liveTime <= 0)
			Destroy(this.gameObject);

		m_trasform.Translate( new Vector3( 0, 0, -m_speed * Time.deltaTime ) );  //移动
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag.CompareTo("Player")!=0)
			return;
		Destroy(this.gameObject);
	}
}