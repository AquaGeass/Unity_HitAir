using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Transform LuoX;
	public float m_rotSpeed = 30;
	public Transform Bullet_L;
	public Transform Bullet_R;
	public float m_speed = 1;	// 飞机速度
	public int m_life = 10;    // 飞机生命
	public Transform m_rocket01;  // 子弹
	protected Transform m_transform;
	public Transform m_jiS;
	public static float m_rocketRate = 0;// 发射子弹频率
	public float m_PanSpeed = 30;   //偏移角度
	public float m_PanTime = 2.0f;


	// Use this for initialization
	void Start () {
		m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//螺旋桨的旋转
		LuoX.Rotate(Vector3.forward, m_rotSpeed * Time.deltaTime, Space.World);

		float movev=0;   // 纵向移动距离
		float moveh=0; 	// 水平移动距离
		float Rotate = 30;
		if ( Input.GetKey( KeyCode.W ))
		{
			m_jiS.rotation = Quaternion.Euler(transform.rotation.x , transform.rotation.y, transform.rotation.z - Rotate);
			moveh += m_speed * Time.deltaTime;
		}else if(Input.GetKeyUp( KeyCode.W )){
			m_jiS.rotation = Quaternion.Euler(transform.rotation.x , transform.rotation.y, transform.rotation.z *0);
		}
		if ( Input.GetKey( KeyCode.S ))
		{
			moveh -= m_speed * Time.deltaTime;
			m_jiS.rotation = Quaternion.Euler(transform.rotation.x , transform.rotation.y, transform.rotation.z + Rotate);
		}else if(Input.GetKeyUp( KeyCode.S )){
			m_jiS.rotation = Quaternion.Euler(transform.rotation.x , transform.rotation.y, transform.rotation.z *0);
		}

		if ( Input.GetKey( KeyCode.A ))
		{
			movev += m_speed * Time.deltaTime;
		}
		if ( Input.GetKey( KeyCode.D ))
		{
			movev -= m_speed * Time.deltaTime;
		}
		this.m_transform.Translate( new Vector3( moveh, 0, movev ) );

		m_rocketRate -= Time.deltaTime;
		if ( m_rocketRate <= 0 ){
			m_rocketRate = 0.2f;
			if ( Input.GetKey( KeyCode.Space ))
			{
			    Instantiate(m_rocket01,Bullet_L.position,transform.rotation);
				Instantiate(m_rocket01,Bullet_R.position,transform.rotation);
			}

	}

}
	void Attack(){
		Instantiate(m_rocket01,Bullet_L.position,transform.rotation);
		Instantiate(m_rocket01,Bullet_R.position,transform.rotation);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.CompareTo ("EnemyRocket") == 0) {
			EnemyRocket enemyrocket = other.GetComponent<EnemyRocket> ();
			if (enemyrocket != null) {
				m_life -= enemyrocket.m_power;

				PlayerUI.hp = m_life;
				PlayerUI.DuiHa = "你的侧翼被干了！";

				if (m_life <= 0) {
					PlayerUI.sw = true;
					PlayerUI.DuiHa = "好人死的早啊！";

				}
			}
		}
	}



}
