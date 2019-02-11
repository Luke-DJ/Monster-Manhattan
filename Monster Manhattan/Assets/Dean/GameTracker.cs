using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameTracker : MonoBehaviour
{
	public int points;
	public int track;
	public float gap;
	public float minGap;
	public int difficulty; 
	public float jetpack = 0f;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text scoreText;
    [SerializeField] private TreadmillMover treadmillMover;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float gameOverDelay;

    private void Update()
    {
		if (track < 3)
        {
			difficulty = 1;
		}
		else if (track > 3 && track < 8) 
		{
			difficulty = 2;
		}
		else if (track > 8) 
		{
			difficulty = 3;
		} 

		if (minGap < gap)
        {
			gap -= 0.0001f;
		}
	}

    public void GameOver()
    {
        scoreText.text = points.ToString().PadLeft(5, '0');
        treadmillMover.delayActive = true;
        playerController.animator.SetTrigger("GameOver");
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(gameOverDelay);
        gameOverPanel.SetActive(true);
    }
} 