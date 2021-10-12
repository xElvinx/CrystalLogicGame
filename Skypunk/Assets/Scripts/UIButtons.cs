using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(Transform child)
    {
        child.parent.gameObject.SetActive(false);
    }

}
