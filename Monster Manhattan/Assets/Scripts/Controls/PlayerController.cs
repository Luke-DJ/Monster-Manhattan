using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject[] forwards;
    [SerializeField] private GameObject[] backwards;
    [SerializeField] private int currentLane = 0;
    [SerializeField] private int currentpos = 1;

    [SerializeField] private float duration = 0.25f;

    private Vector3 startPosition;
    private Vector3 targetPosition;

    private float t = 0;

    [HideInInspector] public Animator animator;
    [SerializeField] [Tooltip("How many seconds before the player starts running")] private float initialDelay;

    private void Start()
    {
        gameObject.transform.position = forwards[currentpos].transform.position;
        targetPosition = transform.position;

        animator = gameObject.GetComponent<Animator>();

        if (initialDelay > 0)
        {
            StartCoroutine(Delay());
        }
        else
        {
            animator.SetTrigger("Run");
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(initialDelay);
        animator.SetTrigger("Run");
    }

    public void InputManager_OnSwipe(SwipeDirection swipeDirection)
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Idle" && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Taunt01")
        {
            if (swipeDirection == SwipeDirection.Up)
            {
                animator.SetTrigger("Jump");
            }
            else if (swipeDirection == SwipeDirection.Down)
            {
                animator.SetTrigger("Slide");
            }
            else if (swipeDirection == SwipeDirection.Left)
            {
                currentpos--;
                if (currentpos < 0)
                {
                    currentpos = 0;
                }

                if (currentLane == 0)
                {
                    targetPosition = forwards[currentpos].transform.position;
                }
                else
                {
                    targetPosition = backwards[currentpos].transform.position;
                }

                t = 0;
            }
            else if (swipeDirection == SwipeDirection.Right)
            {
                currentpos++;
                if (currentpos > 2)
                {
                    currentpos = 2;
                }

                if (currentLane == 0)
                {
                    targetPosition = forwards[currentpos].transform.position;
                }
                else
                {
                    targetPosition = backwards[currentpos].transform.position;
                }

                t = 0;
            }
        }
    }

    public void InputManager_OnTap()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Idle" && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Taunt01")
        {
            if (currentLane == 0)
            {
                currentLane = 1;
                targetPosition = backwards[currentpos].transform.position;
            }
            else
            {
                currentLane = 0;
                targetPosition = forwards[currentpos].transform.position;
            }

            t = 0;
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, t);

        if (t < 1)
        {
            t += Time.deltaTime / duration;
        }
    }
}