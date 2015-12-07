using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
	public Text FenText;
	public Slider hpSlider;
	public Image Death;
	public Image ZanT;
	public Text DuiH;
	public static string DuiHa = " ";
	//public Slider YinL;
	int YinL = 1;
	public static int Shuliang = 0;
	public Transform YaoG;
	public Transform AttackB;
	public static int hp = 10;    //血量
	public static bool sw = false;        //死亡判定
	public static bool zt = false;        //暂停判定
	public BoxCollider FeijiBox;
	bool WuDi =false;
	float WuDiTime = 1.5f;

	// Use this for initialization
	void Start () {
		PlayerUI.DuiHa = "哥们，祝你顺利！";
	}
	
	// Update is called once per frame
	void Update () {
		hpSlider.value =hp*0.1f;
		FenText.text = "击毁数量： "+ Shuliang.ToString ();
		GameObject.Find ("Main Camera").GetComponent<AudioSource> ().volume = YinL;
		DuiH.text = DuiHa.ToString ();

		if(WuDi == true){
			WuDiTime -= Time.deltaTime;
			if(WuDiTime <=0){
				FeijiBox.enabled = true;
				WuDiTime = 1.05f;
			}
		}


		if(sw == true){
			FeijiBox.enabled = false;
			Time.timeScale = 0;
			Death.gameObject.SetActive(true);
			YaoG.gameObject.SetActive(false);
			AttackB.gameObject.SetActive(false);
		}
	}
	

	//退出
	public void TCButtonOP(){
		Application.Quit ();
	}

	//暂停
	public void ZTButtonOP(){
		ZanT.gameObject.SetActive(true);
		YinL = 0;
		Time.timeScale = 0;
	}

	//返回游戏
	public void FYXButton(){
		YinL = 1;
		ZanT.gameObject.SetActive(false);
		Death.gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	//重新游戏
	public void CXButton(){
		Death.gameObject.SetActive(false);
		sw = false;
		WuDi = true;
		YaoG.gameObject.SetActive(true);
		AttackB.gameObject.SetActive(true);
		DuiHa = "哥们，祝你顺利！";
		Time.timeScale = 1;
		PlayerUI.Shuliang = 0;
		PlayerUI.hp = 10;

	}

	public void FCDButton(){
		Application.LoadLevel ("00");
	}
}
