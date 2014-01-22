using UnityEngine;
using System.Collections;

public class StageFinish : MonoBehaviour {
	
	public string levelToMoveTo = "Level2";
	public float delay = 0.5f;
	
	
	void OnCollisionEnter(Collision col){
		Invoke("change", delay);
	}
	void change(){
		var player = GameObject.FindWithTag("Player");
		var move = player.GetComponent<Move>();
		move.MakeDirection();
		Application.LoadLevel(levelToMoveTo);
	}
}
