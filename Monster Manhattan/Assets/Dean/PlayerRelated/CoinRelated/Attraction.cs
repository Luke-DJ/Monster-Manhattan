using UnityEngine;

public class Attraction : MonoBehaviour {
    [SerializeField] private GameObject GameManager;
    public bool moving = false;
    public GameObject player;
    public GameObject Parent;
    public bool flying;
    [SerializeField] private bool neverStop = false;
	private void Start()
	{ 
		player = GameObject.Find ("Main_Character");
		GameManager = GameObject.Find ("GameManager");
        Parent = GameObject.Find("Chad");
    }
 
	// Update is called once per frame
	void Update () {
        flying = Parent.GetComponent<Pickup>().fly;
		if(moving == true && flying == true)
        {
            neverStop = true;
        } 

        if(neverStop == true)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 10.0f * Time.deltaTime);
            transform.parent = null;
            this.gameObject.layer = 1;
            if (this.transform.position == player.transform.position)
            { 
                GameManager.GetComponent<GameTracker>().points++;
                Destroy(this.gameObject);
            }
        }
	}
}
