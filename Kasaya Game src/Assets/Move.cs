using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float direction = 0;
	public readonly float gravityMult = 7.5f;
	private bool isFalling = false;
	public int walkSpeed = 3;
	private Vector3 gravity;
	private int currentDir = 0; //0 s, 1 d, 2 w, 3 a
	public bool left = true, takeInput = true;
	// Update is called once per frame
	
	void OnCollisionExit(Collision col){
		isFalling = true;
		direction = 0;
	}
	
	void OnCollisionStay(Collision col){
		isFalling = false;
	}
	
	void Start(){
		 gravity = Vector3.down * gravityMult;
	}
	
	void Update () {
		applyGravity();
		if(Input.GetKey(KeyCode.P)){
			Application.LoadLevel("StartScreen");
		}
		if(takeInput){
		Sprite dude = GetComponent<Sprite>();
		//Ensure Camera does not rotate
		var cameraRotation = Camera.main.transform.rotation;
		var cameraPos = Camera.main.transform.position;
		//Which direction is gravity pointing?
		switch(currentDir){
		case 0:
			//Normal Movement
			if(Input.GetKey(KeyCode.Q)){
				direction = -1;
				dude.PlayClip("sprite_walkleft");
				left = true;
			}else if(Input.GetKey(KeyCode.E)){
				direction = 1;
				dude.PlayClip("sprite_walkright");
				left = false;
			}else if(Input.GetKeyUp(KeyCode.Q)){
				direction = 0;
				dude.PlayClip("sprite_standleft");
				left = true;
			}else if(Input.GetKeyUp (KeyCode.E)){
				direction = 0;
				dude.PlayClip("sprite_standright");
				left = false;
			}
			//Changing gravity?
			if(Input.GetKeyDown(KeyCode.W)){
				gravity = new Vector3(0,gravityMult,0);
				transform.Rotate(0,0,180);
				currentDir = 2;
				 
			}else if(Input.GetKeyDown(KeyCode.D)){
				gravity = new Vector3(gravityMult, 0, 0);
				transform.Rotate (0,0,90);
				currentDir = 1;
				 
			}else if(Input.GetKeyDown(KeyCode.A)){
				gravity = new Vector3(-gravityMult, 0, 0);
				transform.Rotate(0,0,270);
				currentDir = 3;
				 
			}			
			break;
			//Gravity to left
		case 1:
			//Normal Movement
			if(Input.GetKey(KeyCode.Q)){
				direction = -1;
				dude.PlayClip("sprite_walkleft");
				left = true;
			}else if(Input.GetKey(KeyCode.E)){
				direction = 1;
				dude.PlayClip("sprite_walkright");
				left = false;
			}else if(Input.GetKeyUp(KeyCode.Q)){
				direction = 0;
				dude.PlayClip("sprite_standleft");
				left = true;
			}else if(Input.GetKeyUp (KeyCode.E)){
				direction = 0;
				dude.PlayClip("sprite_standright");
				left = false;
			}
			//Changing Gravity?
			if(Input.GetKeyDown(KeyCode.W)){
				gravity = new Vector3(0,gravityMult,0);
				transform.Rotate (0,0,90);
				currentDir = 2;
				 
			}else if(Input.GetKeyDown(KeyCode.A)){
				gravity = new Vector3(-gravityMult, 0, 0);
				transform.Rotate (0,0,180);
				currentDir = 3;
				 
			}else if(Input.GetKeyDown(KeyCode.S)){
				gravity = new Vector3(0, -gravityMult, 0);
				transform.Rotate (0,0,270);
				currentDir = 0;	 
			}
			break;
		case 2:
			//Normal Movement
			if(Input.GetKey(KeyCode.E)){
				direction = 1;
				dude.PlayClip("sprite_walkleft");
				left = true;
			}else if(Input.GetKey(KeyCode.Q)){
				direction = -1;
				dude.PlayClip("sprite_walkright");
				left = false;
			}else if(Input.GetKeyUp(KeyCode.E)){
				direction = 0;
				dude.PlayClip("sprite_standleft");
				left = true;
			}else if(Input.GetKeyUp (KeyCode.Q)){
				direction = 0;
				dude.PlayClip("sprite_standright");
				left = false;
			}
			//Changing Gravity?
			if(Input.GetKeyDown(KeyCode.S)){
				gravity = new Vector3(0,-gravityMult,0);
				transform.Rotate (0,0,180);
				currentDir = 0;	
			}else if(Input.GetKeyDown(KeyCode.A)){
				gravity = new Vector3(-gravityMult, 0, 0);
				transform.Rotate (0,0,90);
				currentDir = 3;
			}else if(Input.GetKeyDown(KeyCode.D)){
				gravity = new Vector3(gravityMult, 0, 0);
				transform.Rotate (0,0,270);
				currentDir = 1;
				 
			}
			break;
		case 3:
			//Normal Movement
			if(Input.GetKey(KeyCode.E)){
				direction = -1;
				dude.PlayClip("sprite_walkright");
				left = false;
			}else if(Input.GetKey(KeyCode.Q)){
				direction = 1;
				dude.PlayClip("sprite_walkleft");
				left = true;
			}else if(Input.GetKeyUp(KeyCode.E)){
				direction = 0;
				dude.PlayClip("sprite_standright");
				left = false;
			}else if(Input.GetKeyUp (KeyCode.Q)){
				direction = 0;
				dude.PlayClip("sprite_standleft");
				left = true;
			}
			//Changing Gravity?
			if(Input.GetKeyDown(KeyCode.W)){
				gravity = new Vector3(0,gravityMult,0);
				transform.Rotate (0,0,270);
				currentDir = 2;
			}else if(Input.GetKeyDown(KeyCode.D)){
				gravity = new Vector3(gravityMult, 0, 0);
				transform.Rotate (0,0,180);
				currentDir = 1; 
			}else if(Input.GetKeyDown(KeyCode.S)){
				gravity = new Vector3(0, -gravityMult, 0);
				transform.Rotate (0,0,90);
				currentDir = 0;	 
			}
			break;
			}
		Camera.main.transform.rotation = cameraRotation;
		Camera.main.transform.position = cameraPos;
		if((float)rigidbody.velocity.magnitude < walkSpeed && !isFalling){
			if(currentDir == 0 || currentDir == 2){
				rigidbody.AddForce(Vector3.right * direction, ForceMode.Impulse);
			}else{
				rigidbody.AddForce(Vector3.up * direction, ForceMode.Impulse);
			}
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			CustomGravity.setGravityToNormal();	
		}
		}
	}
	public void Power(){
		Sprite dude = GetComponent<Sprite>();
		if(left){
			dude.PlayClip ("sprite_powerup_left");
		}else{
			dude.PlayClip ("sprite_powerup_right");	
		}
		Invoke("Normalize", 1.0f);
	}
	
	void Normalize(){
		Sprite dude = GetComponent<Sprite>();
		if(left){
			dude.PlayClip ("sprite_standleft");
		}else{
			dude.PlayClip ("sprite_standright");
		}
	}
	public void MakeDirection(){
		var cameraRotation = Camera.main.transform.rotation;
		var cameraPos = Camera.main.transform.position;
		left = false;
		Sprite dude = GetComponent<Sprite>();
		dude.PlayClip("sprite_standleft");
			if(currentDir == 2){
				gravity = new Vector3(0,-gravityMult,0);
				transform.Rotate(0,0,180);
				currentDir = 0;
			}else if(currentDir == 3){
				gravity = new Vector3(0, -gravityMult, 0);
				transform.Rotate (0,0,90);
				currentDir = 0;
			}else if(currentDir == 1){
				gravity = new Vector3(0, -gravityMult, 0);
				transform.Rotate(0,0,270);
				currentDir = 0;	 
			}
		Camera.main.transform.rotation = cameraRotation;
		Camera.main.transform.position = cameraPos;
		takeInput = true;
	}
	public void applyGravity(){
		rigidbody.AddForce(gravity, ForceMode.Acceleration);	
	}
}
