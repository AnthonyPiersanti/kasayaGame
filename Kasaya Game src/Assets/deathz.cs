using UnityEngine;
using System.Collections;

public class deathz : MonoBehaviour {


	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == ("spike")){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
