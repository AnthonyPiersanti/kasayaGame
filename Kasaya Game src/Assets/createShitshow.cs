using UnityEngine;
using System.Collections;

public class createShitshow : MonoBehaviour {
	
	void OnTriggerEnter(Collider col){
		causeShitshow.shitshow();
	}
}
