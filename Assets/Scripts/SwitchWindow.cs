using UnityEngine;
using UnityEngine.Serialization;

public class SwitchWindow : MonoBehaviour
{
    [SerializeField] private GameObject switchToTheWindow;
    [SerializeField] private GameObject switchedWindow;

    public void OnClickSwitchWindow()
    {
        switchedWindow.SetActive(false);
        switchToTheWindow.SetActive(true);
    }
}