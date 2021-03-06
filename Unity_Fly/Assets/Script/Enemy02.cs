﻿using UnityEngine;
using System.Collections;

public class Enemy02 : MonoBehaviour {
	public float m_speed = 1.0f;    // 速度
	public float m_life = 5.0f;    // 生命
	public float m_Xspeed = 2.0f;  //平移速度
	protected float m_Btimer = 1.5f;	// 变向间隔时间
	protected Transform m_transform;
	float m_rocketRate = 0.2f;   //子弹频率
	public Transform m_Enemyrocket;  // 子弹
	public Transform Rockerfs;
    public Transform Liz;


	// Use this for initialization
	void Start () {
		m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {

		m_transform.Translate(new Vector3(m_Xspeed* Time.deltaTime, 0, -m_speed * Time.deltaTime));

		//子弹发射与间隔
		m_rocketRate -= Time.deltaTime;
		if ( m_rocketRate <= 0 ){
			Instantiate(m_Enemyrocket,Rockerfs.position,m_transform.rotation);
			m_rocketRate = 0.2f;
		}
		
		m_Btimer -= Time.deltaTime;
		if (m_Btimer <= 0)
		{
			m_Btimer = 3;
			
			//变向
			m_Xspeed = -m_Xspeed;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.CompareTo ("Rocket") == 0) {
			Rocket rocket = other.GetComponent<Rocket>();
			if (rocket != null){
				m_life -= rocket.m_power;
				if (m_life <= 0)
				{
					PlayerUI.Shuliang +=1;
                    Instantiate(Liz, m_transform.position, m_transform.rotation);
					Destroy(this.gameObject);
				}
			}
		}else if (other.tag.CompareTo("Player") == 0)
		{
			m_life = 0;
			PlayerUI.Shuliang +=1;
			PlayerUI.hp -=2;
			Destroy(this.gameObject);
			PlayerUI.DuiHa = "你不要命了！";
			print("直接撞毁了一架小型TX-86战斗机！");
		}
		
	}
}