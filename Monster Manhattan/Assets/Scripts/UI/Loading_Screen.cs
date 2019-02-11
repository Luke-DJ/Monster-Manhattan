using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_Screen : MonoBehaviour
{
    [SerializeField] private string gameSceneName;

    private void Start()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}