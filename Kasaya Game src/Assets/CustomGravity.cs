using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomGravity : MonoBehaviour {
	
	private Vector3 grav = Vector3.down * 10;
	private Vector3 position1, position2, unitVector;
	public static LinkedList<CustomGravity> instances = new LinkedList<CustomGravity>();
	
	void Start(){
		instances.AddFirst(this);	
	}
	
	void Update(){
		applyGravity();
	}
	
	void OnMouseDown(){
		var arrow = transform.FindChild("Arrow");
		arrow.GetComponent<Sprite>().PlayClip("DatArrow");
		arrow.GetComponent<ArrowScript>().setMouse(); 
		position1 = Camera.main.WorldToScreenPoint(transform.position);
		position1.z = 0;
	}
	void OnMouseUp(){
		position2.x = Input.mousePosition.x;
		position2.y = Input.mousePosition.y;
		position2.z = 0;
		var arrow = transform.FindChild("Arrow");
		arrow.GetComponent<ArrowScript>().setMouse();
		arrow.GetComponent<Sprite>().PlayClip("blank");
		var player = GameObject.FindWithTag("Player");
		calculateGravity();
		player.GetComponent<Move>().Power();
	}
	
	public void applyGravity(){
		rigidbody.AddForce(grav, ForceMode.Acceleration);	
	}
	
	public void calculateGravity(){
		if(position1 != position2){
			unitVector = (position2 - position1)/Vector3.Magnitude((position2-position1));
			grav = (unitVector * Vector3.Magnitude(position2-position1)) / 15;
			if(grav.sqrMagnitude > 20*20){
				grav = unitVector *20;
			}
		}
	}
	public static void setGravityToNormal(){
		foreach(CustomGravity c in instances){
			c.grav = Vector3.down * 10;
		}
	}
}
