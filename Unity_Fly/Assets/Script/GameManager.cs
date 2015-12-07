using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Transform Enemy01SC;  //01生成位置
	public Transform Enemy02SC;  //02生成位置
	public float m_speed = 8;    //移动速度
	public float SC01_Time = 3.0f;
	public float SC02_Time = 5.0f;
	public Transform Enemy01;  //01生成
	public Transform Enemy02;  //02生成
	public Transform bg;
	protected Transform m_trasform;
	// Use this for initialization
	void Start () {
		m_trasform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//跟随主角移动
		float movev=0; 
		float moveh=0; 
		if ( Input.GetKey( KeyCode.W ) )
		{
			moveh += m_speed * Time.deltaTime;
		}else if ( Input.GetKey( KeyCode.S ) )
		{
			moveh -= m_speed * Time.deltaTime;
		}
		
		if ( Input.GetKey( KeyCode.A ) )
		{
			movev += m_speed * Time.deltaTime;
		}else if ( Input.GetKey( KeyCode.D ) )
		{
			movev -= m_speed * Time.deltaTime;
			
		}
		this.Enemy01SC.Translate( new Vector3( moveh, 0, movev ) );
		this.Enemy02SC.Translate( new Vector3( moveh, 0, movev ) );




		//生成器
		SC01_Time -= Time.deltaTime;
		SC02_Time -= Time.deltaTime;
		if(SC01_Time <=0){
			Instantiate(Enemy01,Enemy01SC.position,transform.rotation);
			SC01_Time = 6.0f;
		}else if(SC02_Time <=0){
			Instantiate(Enemy02,Enemy02SC.position,transform.rotation);
			SC02_Time = 8.0f;
		}



	}

}
