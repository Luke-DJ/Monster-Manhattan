using UnityEngine;

public class Pickup : MonoBehaviour {
	public GameObject GameManager;
    public bool fly;

	private void Start()
	{ 
		GameManager = GameObject.Find ("GameManager");
        GameObject player = GameObject.Find("Main_Character");       
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "coin" && fly == false) { 
			GameManager.GetComponent<GameTracker> ().points++;
			Destroy(other.gameObject);
		}		
	}
}
 