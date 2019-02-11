using UnityEngine;

public class ObstacleChance : MonoBehaviour
{
    [SerializeField] [Tooltip("Only for graphically use!")] private GameObject[] objects; 
	private void Start()
    {
        //0.92
        if (objects != null)
        { 
            int random = Random.Range(0, objects.Length);
            GameObject child = Instantiate(objects[random], this.transform.position, Quaternion.identity);
            child.transform.parent = this.transform; 
        }
	}
}