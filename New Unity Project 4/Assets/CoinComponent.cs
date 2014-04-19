using UnityEngine;
using System.Collections;

public class CoinComponent : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		CoinCounter.getInstance().add();
		Object.Destroy(this.gameObject);
	}
}
