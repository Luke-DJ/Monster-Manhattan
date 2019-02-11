using UnityEngine;
using UnityEngine.UI;

public class TrackCoins : MonoBehaviour
{
	public Text coinValue;
	public GameObject gameManager;

	private void Update()
    {
		coinValue.text = gameManager.GetComponent<GameTracker>().points.ToString().PadLeft(5, '0');
    }
}