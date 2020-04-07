using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementcont : MonoBehaviour {
public Rigidbody Rigid_body;
//public Animator animator;
public List<Collider> Ragdollparts = new List<Collider>();
	// Use this for initialization
	private void Awake()
	{
	
	SetRagdoll();
//	TurnOffRagdoll();	 
		 
	}

	void Start () {
	}

	
	private void SetRagdoll()
	{
		Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
		foreach (Collider c in colliders)
		{

if (c.gameObject != this.gameObject)
{
c.isTrigger = true;
Ragdollparts.Add(c);
}

		}
	}
	/*
	public void TurnOnRagdoll()
{
	Debug.Log("EnabledRagdoll");
	GetComponent<Movementsc>().enabled = false;
	Rigid_body.useGravity = false;
	Rigid_body.velocity = Vector3.zero;;
	this.gameObject.GetComponent<CharacterController>().enabled = false;
	//animator.enabled = false;
	//animator.avatar = null;
	
foreach (Collider c in Ragdollparts)
{
	c.isTrigger = false;
	c.attachedRigidbody.velocity = Vector3.zero;
}
}

	public void TurnOffRagdoll()
{
	Debug.Log("DisabledRagdoll");
	Rigid_body.useGravity = true;

	this.gameObject.GetComponent<CharacterController>().enabled = true;
	
	//animator.enabled = true;
	//animator.avatar = true;
foreach (Collider c in Ragdollparts)
{
	c.isTrigger = true;
	c.attachedRigidbody.velocity = Vector3.zero;
}

}

*/


}
