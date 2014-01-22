using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class causeShitshow : MonoBehaviour {
	public static LinkedList<causeShitshow> instances = new LinkedList<causeShitshow>();

	void Start(){
		instances.AddFirst(this);
	}
	
	public static void shitshow(){
		foreach(causeShitshow c in instances){
			c.transform.rigidbody.useGravity = true;
			c.transform.rigidbody.constraints = RigidbodyConstraints.None;
			c.transform.rigidbody.AddExplosionForce(200,Vector3.zero,50);
		}
	}
}
