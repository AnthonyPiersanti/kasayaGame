using UnityEngine;
using System.Collections;

public class DeathTeleport : MonoBehaviour {

	public string tagOfNextPosition = "Spawn";
	public Vector3 amountToDisplace = new Vector3(-2,3,0);

	
	void OnCollisionEnter(Collision col){
		var player = GameObject.FindWithTag("Player");
		var name = gameObject.name;
		if(col.gameObject.name == ("spike") || col.gameObject.name == ("Enemy") && name != ("spike") && name != ("Enemy"))  {
			player.GetComponent<Move>().takeInput = false;
			if(player.GetComponent<Move>().left){
				player.GetComponent<Sprite>().PlayClip("sprite_death_left");
				Invoke("Die",1.14f);
			}else{
				player.GetComponent<Sprite>().PlayClip("sprite_death_right");
				Invoke("Die",1.14f);
			}
		}
	}
	
	void Die(){
		Application.LoadLevel(Application.loadedLevel);
	}
}

