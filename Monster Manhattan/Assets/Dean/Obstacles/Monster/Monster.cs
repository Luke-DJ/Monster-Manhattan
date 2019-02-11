using UnityEngine;

// Should of been monsterspawner
public class Monster : MonoBehaviour
{
    public bool PLAYTESTINGGORILLA;
    public bool PLAYTESTINGOCTO;

    public GameObject GorillaHand;
    public GameObject OctHand;
    public float intervalBetweenAttacks;
    float temp;

    private void Start()
    {
        temp = intervalBetweenAttacks;
    }
    void Update () {
        if(PLAYTESTINGGORILLA == true)
        {
            Instantiate(GorillaHand, new Vector3(-0.6f, 0.2f, -6f), Quaternion.identity);
            intervalBetweenAttacks = temp * 2;
            PLAYTESTINGGORILLA = false;
        }

        if (PLAYTESTINGOCTO == true)
        {
            Instantiate(OctHand, new Vector3(-0.6f, -0.1f, -6f), Quaternion.Euler(0, 270, 90));
            intervalBetweenAttacks = temp * 2;
            PLAYTESTINGOCTO = false;
        }


        if(intervalBetweenAttacks >= 0)
        {
            intervalBetweenAttacks -= Time.deltaTime;
        }
        else if (intervalBetweenAttacks < 0)
        {
            int random = Random.Range(0, 4);
            if (random == 0)
            { 
                Instantiate(GorillaHand, new Vector3(-0.6f, 0.2f, -6f), Quaternion.identity);
                intervalBetweenAttacks = temp * 2;
            }
            else if (random == 1)
			{  
                Instantiate(OctHand, new Vector3(-0.6f, -0.1f, -6f), Quaternion.Euler(0, 270, 90));
                intervalBetweenAttacks = temp * 2;
            }
            else
            {
                intervalBetweenAttacks = temp;
            }
        } 
	}
}
