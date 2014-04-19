using UnityEngine;
using System.Collections;

public class ScoreDisplayer : MonoBehaviour {
	void OnGUI () {
		GUI.Box(new Rect(Screen.width - 110, 10,100,90), "Coin Counts");
		
		GUI.Label(new Rect(Screen.width - 100, 30, 100, 90), 
		          CoinCounter.getInstance().Count.ToString()); 
	}
}
