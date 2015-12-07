using UnityEngine;
using System.Collections;

public class TouchMove : MonoBehaviour {
	public Transform Feiji;

	//当摇杆可用时注册事件
	void OnEnable()  {  
		EasyJoystick.On_JoystickMove += OnJoystickMove;  
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;  
	}  
	/*	//当摇杆不可用时移除事件
	void OnDisable()
	{
		EasyJoystick.On_JoystickMove -= OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
	}*/
	//移动摇杆结束  
	void OnJoystickMoveEnd(MovingJoystick move)  {  
		
		//停止时，角色恢复idle  
		if (move.joystickName == "MoveJoystick")  
		{  
			//	animation.CrossFade("idle");  
		}  
	}  
	
	
	//移动摇杆中  
	
	void OnJoystickMove(MovingJoystick move){  
		//摇杆没有停止时！
		if (move.joystickName != "MoveJoystick")  
		{  
			return;  
		}  
		//获取摇杆中心偏移的坐标  
		float joyPositionX = move.joystickAxis.x;  
		float joyPositionY = move.joystickAxis.y;
		float joyRotationZ = joyPositionY * 20;
		if (joyPositionY != 0 || joyPositionX != 0){  

			Feiji.rotation = Quaternion.Euler(transform.rotation.x , transform.rotation.y, transform.rotation.z-joyRotationZ);
			transform.Translate(new Vector3( joyPositionY *0.3f, 0,-joyPositionX*0.2f));
			
		}  
	}  

}  