using UnityEngine;

public class Activate : MonoBehaviour {
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Main_Character"){
			other.gameObject.GetComponent<AttractCoins>().activated = true;
            GameObject.Destroy(this.gameObject);
		}
	} 
}
