using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    public void DisableBtn()
    {
        btn.interactable = false;
    }
}
