using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextAnchor textAnchor;
    [SerializeField] private int textSizeModifier;
    [SerializeField] [Tooltip("The colour of the FPS text")] private Color textColour;
    private float deltaTime;
    private GUIStyle style;
    private int textSizeModifierLimit = 100;

    public static FPSCounter instance;

    private void OnValidate()
    {
        if (textSizeModifier < 1)
        {
            textSizeModifier = 1;
        }
        else if (textSizeModifier > textSizeModifierLimit)
        {
            textSizeModifier = textSizeModifierLimit;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        deltaTime = 0.0f;
        style = new GUIStyle();
    }

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    // For the FPS counter
    private void OnGUI()
    {
        int width = Screen.width;
        int height = Screen.height;

        Rect rect = new Rect(0, 0, width, height * 2 / 100);

        style.alignment = textAnchor;
        style.fontSize = (height * 2) / Mathf.Max((textSizeModifierLimit - textSizeModifier), 1);
        style.normal.textColor = textColour;

        float fps = 1.0f / deltaTime;
        string text = (int)fps + " fps";

        GUI.Label(rect, text, style);
    }
}