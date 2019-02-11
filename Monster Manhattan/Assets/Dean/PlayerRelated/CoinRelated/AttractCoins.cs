using UnityEngine;

public class AttractCoins : MonoBehaviour {
    public bool activated = false;
    [SerializeField] private float time = 5f;
    [SerializeField] private float temp;
	public SphereCollider LargeCollection; 
	public GameObject player;
    public GameObject Parent;
    private void Start()
    { 
		temp = time;

		player = GameObject.Find ("Main_Character");
        Parent = GameObject.Find("Chad");
        LargeCollection = player.GetComponent<SphereCollider> (); 

		LargeCollection.enabled = false; 
	}
    

	// Update is called once per frame
	void Update () {
        if (activated == true)
        { 
            if (time > 0)
            {
				LargeCollection.enabled = true;
                Parent.gameObject.GetComponent<Pickup>().fly = true;
                time -= Time.deltaTime;
            }
            else
            {                
				LargeCollection.enabled = false;
                Parent.gameObject.GetComponent<Pickup>().fly = false;
                activated = false;
				time = temp;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "coin"){
            other.gameObject.GetComponent<Attraction>().moving = true;
        }
    } 
}
