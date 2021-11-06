using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PlayerStatic;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private Transform panelMap;
    [SerializeField] private Transform panelOption;
    [SerializeField] private Animator animator;
    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("1");
    }

    public void OpenMap()
    {
        panelMap.parent.gameObject.SetActive(true);
        panelOption.gameObject.SetActive(false);
        panelMap.gameObject.SetActive(true);
    }

    public void OpenOption()
    {
        panelOption.parent.gameObject.SetActive(true);
        panelOption.gameObject.SetActive(true);
        panelMap.gameObject.SetActive(false);
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
