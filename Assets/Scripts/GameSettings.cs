using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Text fpsText;

    private void Start()
    {
        //Below is slightly more solid (Just being nitpicky, sorry)
        InvokeRepeating(nameof(GetFPS), 1, 1);
    }

    private void GetFPS()
    {
        float fps = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = fps.ToString() + " FPS";
    }

    public void SetQualityLevel(int level)
    {
        QualitySettings.SetQualityLevel(level, true);
        switch (level)
        {
            case 0:
                Debug.Log("Quality settings set to 'Low'");
                break;
            case 1:
                Debug.Log("Quality settings set to 'High'");
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            SetQualityLevel(0);

        if (Input.GetKeyDown(KeyCode.H))
            SetQualityLevel(1);
    }
}
