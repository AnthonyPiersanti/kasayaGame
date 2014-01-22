using UnityEngine;
using System.Collections;

public class displayText : MonoBehaviour {
	
	bool showGUI = false;
	int index = 0;
    string [] thisisText = new string [] { "I am text", "text am I" };
	string [] thisisText2 = new string [] { "The text continues", "the void grows" };

	public string state = "part1";
	
	void OnCollisionEnter(Collision col){
    
	   showGUI = true;
    }

	
	void OnGUI ()
    {
		if ((showGUI==true) && (state == "part1"))
		{
        	if (GUI.Button (new Rect (0, Screen.height-200, Screen.width, 200), thisisText [index])) 
			{
               index++;
    		}
		
        //GUI.DrawTexture();
		}
		
		if ((showGUI == true) && (state == "part2"))
		{	
			if (GUI.Button (new Rect (0, Screen.height-200, Screen.width, 200), thisisText2 [index])) 
			{
               index++;
    		}
		}
		if (index < 2)
		{
			showGUI = false;
			index = 0;
		}
	}
}
