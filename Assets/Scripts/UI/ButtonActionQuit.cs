using UnityEngine;
using UnityEngine.UI;

public class ButtonActionQuit : MonoBehaviour
{
    void Start()
    {
        if (TryGetComponent(out Button button))
        {
            button.onClick.AddListener(Quit);
        }
    }

    private void Quit()
    {
        Application.Quit();
    }
}
