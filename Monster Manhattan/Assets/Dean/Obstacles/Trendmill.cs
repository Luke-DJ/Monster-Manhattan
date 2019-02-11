using UnityEngine;

public class Trendmill : MonoBehaviour
{
    [SerializeField] private GameObject Parent;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject[] bases;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer.ToString() == "9")
        {

            Destroy(collision.gameObject);

            bases = GameObject.FindGameObjectsWithTag("Track");

            if (bases.Length < 8)
            {
                MagicEight();
            }           
        }
    }

    public void MagicEight()
    {
        while (bases.Length < 8)
        {
            Parent.GetComponent<Sequence_Maker>().NextObstacles();
            gameManager.GetComponent<GameTracker>().track += 1;
            bases = GameObject.FindGameObjectsWithTag("Track");
        }
    }
}