using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] [Tooltip("The tag used by jumpable obstacles")] private string jumpableObstacleTag;
    [SerializeField] [Tooltip("The tag used by slidable obstacles")] private string slidableObstacleTag;
    [SerializeField] [Tooltip("The tag used by impassable obstacles")] private string impassableObstacleTag;
    [SerializeField] [Tooltip("The tag used by the gorilla attacks")] private string gorillaAttackTag;
    private List<string> tags;
    [SerializeField] private GameTracker gameTracker;
    [SerializeField] private Animator animator;

    private void Start()
    {
        tags = new List<string>(new string[]{jumpableObstacleTag, slidableObstacleTag, impassableObstacleTag, gorillaAttackTag});
	}

    private void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.gameObject.tag))
        {
            if ((other.gameObject.tag == jumpableObstacleTag && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Jump") || (other.gameObject.tag == slidableObstacleTag && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Slide"))
            {
            }
            else
            {
                gameTracker.GameOver();
            }
        }
    }
}