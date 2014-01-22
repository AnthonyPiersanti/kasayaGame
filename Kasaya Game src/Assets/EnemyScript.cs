using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	public int speed = 3;
	public bool facingLeft = true;
	private Sprite enemy;
	public bool willChangeDirectionOnChangingObject = false;
	
	void OnCollisionEnter(Collision col){
		if(willChangeDirectionOnChangingObject){
			facingLeft = !facingLeft;
			if(facingLeft){
				enemy.PlayClip("enemy_walk_left");
			}else{
				enemy.PlayClip("enemy_walk_right");
			}
		}
	}
	void Start(){
		enemy = GetComponent<Sprite>();
		if(facingLeft){
			enemy.PlayClip("enemy_walk_left");
		}else{
			enemy.PlayClip("enemy_walk_right");
		}
	}

	void Update () {
		if(facingLeft){
			transform.Translate(Vector3.left * Time.deltaTime * 3);
		}else if(!facingLeft){
			transform.Translate(Vector3.right * Time.deltaTime * 3);
		}

	}
}
