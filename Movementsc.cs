using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movementsc : MonoBehaviour {
private Vector3 MovedirRight;
private Vector3 MovedirForward;
private Vector3 MovedirUp;
public float jumpforce;
public float moveSpeed;
public float gravityscale;
//private Animator anim;

public CharacterController controller;
	void Start () {
	//	anim =  GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
			
	}
	public float Currentvaluex;
	public float Currentvaluez;
	public float CurrentvalueS;
	private float movespeedanim;
	void Update () {
float Sprint = Input.GetAxisRaw("Sprint");
			float Crouch = Input.GetAxis("Crouch");
		float x = Input.GetAxisRaw("Horizontal");
			float z = Input.GetAxisRaw("Vertical");
			Currentvaluex = Mathf.Lerp(Currentvaluex,x, Time.deltaTime * 10f);
			Currentvaluez = Mathf.Lerp(Currentvaluez,z, Time.deltaTime * 8f);
			CurrentvalueS = Mathf.Lerp(CurrentvalueS,Sprint, Time.deltaTime * 10f);	

		
if (Mathf.Abs(Currentvaluex) <= 0.001f && Mathf.Abs(Currentvaluex) >= 0f)
{
	Currentvaluex = 0f;
}
if (Mathf.Abs(Currentvaluez) <= 0.001f && Mathf.Abs(Currentvaluez) >= 0f)
{
	Currentvaluez = 0f;
}
if (Mathf.Abs(CurrentvalueS) <= 0.001f && Mathf.Abs(CurrentvalueS) >= 0f)
{
	CurrentvalueS = 0f;
}



// Animation
//            anim.SetFloat("Rightleft", Currentvaluex);
		//	anim.SetFloat("Forward", Currentvaluez);
			//run
			if(moveSpeed > 2f)
			{
			movespeedanim = moveSpeed;
			movespeedanim = movespeedanim - 2f;
		//	anim.SetFloat("Dir", movespeedanim);

			}
			//



//Debug.Log(Currentvaluex);Debug.Log(Currentvaluez);Debug.Log(CurrentvalueS);
			
			if (CurrentvalueS > 0 && (Currentvaluex !=0 || Currentvaluez !=0) && Crouch != 1)
		{
			if (moveSpeed < 4f)
			{
			moveSpeed = moveSpeed + Time.deltaTime;
			}
			
		}
		else if (CurrentvalueS < 0.5) moveSpeed = 2f;

		 	if (CurrentvalueS == 0 )
			{
				if (moveSpeed > 2)
				{
				moveSpeed = moveSpeed - (3 * Time.deltaTime);
			}
			}
		//crouch
			if (controller.isGrounded == true && Crouch > 0 )
			{
			controller.height = 1f;
			}
else if (Crouch == 0 ) controller.height = 1.67f;

		if(controller.isGrounded)
		{
		MovedirRight = transform.right * Currentvaluex;
		MovedirForward = transform.forward * Currentvaluez;
		MovedirUp = transform.up;

		controller.Move(Vector3.ClampMagnitude(MovedirForward + MovedirRight, 1.0f) * moveSpeed * Time.deltaTime);
		if (Input.GetButtonDown("Jump") && CurrentvalueS != 1)
		{
			MovedirUp.y = jumpforce;
		}
 /*else if (Input.GetButtonDown("Jump") && CurrentvalueS == 1)
		{
		MovedirUp.y = jumpforce;
		//MovedirRight  = MovedirRight * 5f;
		//Movedir.z  = Movedir.z * 5f;
		}
		}
		MovedirUp.y = MovedirUp.y + (Physics.gravity.y * gravityscale * Time.deltaTime);
		controller.Move(MovedirRight * Time.deltaTime);
	*/
		}
	
}
}