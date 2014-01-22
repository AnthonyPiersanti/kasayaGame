using UnityEngine;
using System.Collections;

public class ArrowScript : MonoBehaviour {
	private bool mouseDown = false;
	Sprite arrow;
	private float arrowScale = 2;
	
	void Start(){
		arrow = GetComponent<Sprite>();
		transform.position = transform.parent.position;
		transform.Translate(0,0,-1);
		var scale = transform.parent.localScale;
		arrowScale = arrowScale/scale.x;
		scale.y = arrowScale;
		scale.x = arrowScale;
		transform.localScale = scale;
	}
	
	void Update () {
	  if(mouseDown){
			transform.position = transform.parent.position;
			transform.Translate(0,0,-1);
			Vector3 mousePos = Input.mousePosition;
	        mousePos.z = -1f;
	        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
	        lookPos = lookPos - transform.position;
	        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
	        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			var scale = transform.localScale;
			var xScale = scale.x;
			xScale = lookPos.magnitude;
			if(xScale > 20){
				xScale = 20;
			}
			scale.x = xScale*arrowScale;
			transform.localScale = scale;
			
		}
	}
	
	public void setMouse(){
		mouseDown = !mouseDown;	
	}
}
