using UnityEngine;

// Parts of implementation inspired by: https://youtu.be/jbFYYbu5bdc
public class InputManager : MonoBehaviour
{
    private Vector2 pressPosition;
    private Vector2 currentPosition;
    private Vector2 releasePosition;

    private bool isPressed;

    [SerializeField] [Tooltip("The shortest swipe distance that constitutes as a valid swipe")] private float minimumSwipeDistance = 70.0f;
    [SerializeField] [Tooltip("The longest tap distance that constitutes as a valid tap")] private float maximumTapDistance = 50.0f;

    [SerializeField] private PlayerController playerController;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                OnPress(touch.position);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                OnMove(touch.position);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                OnRelease(touch.position);
            }
        }
    }

    private void OnPress(Vector2 pressPosition)
    {
        this.pressPosition = pressPosition;

        SetPressed(true);
    }

    private void OnMove(Vector2 currentPosition)
    {
        this.currentPosition = currentPosition;

        SwipeAction();
    }

    private void OnRelease(Vector2 releasePosition)
    {
        this.releasePosition = releasePosition;

        TapAction();
    }

    private void SetPressed(bool isPressed)
    {
        this.isPressed = isPressed;
    }

    private void TapAction()
    {
        if (isPressed && Vector2.Distance(pressPosition, releasePosition) <= maximumTapDistance)
        {
            playerController.InputManager_OnTap();
            SetPressed(false);
            ResetSwipePositions();
        }
    }

    private void SwipeAction()
    {
        /*
        If the distance between the press position and the release position
        is greater than or equal to the minimum swipe distance
        */
        if (isPressed && Vector2.Distance(pressPosition, currentPosition) >= minimumSwipeDistance)
        {
            playerController.InputManager_OnSwipe(GetSwipeDirection());
            SetPressed(false);
            ResetSwipePositions();
        }
    }

    private SwipeDirection GetSwipeDirection()
    {
        float verticalSwipeDistance = pressPosition.y - currentPosition.y;
        float horizontalSwipeDistance = pressPosition.x - currentPosition.x;

        SwipeDirection swipeDirection;

        if (Mathf.Abs(verticalSwipeDistance) > Mathf.Abs(horizontalSwipeDistance))
        {
            if (verticalSwipeDistance > 0)
            {
                swipeDirection = SwipeDirection.Down;
            }
            else
            {
                swipeDirection = SwipeDirection.Up;
            }
        }
        else
        {
            if (horizontalSwipeDistance > 0)
            {
                swipeDirection = SwipeDirection.Left;
            }
            else
            {
                swipeDirection = SwipeDirection.Right;
            }
        }

        return swipeDirection;
    }

    private void ResetSwipePositions()
    {
        pressPosition = Vector2.zero;
        currentPosition = Vector2.zero;
        releasePosition = Vector2.zero;
    }
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}