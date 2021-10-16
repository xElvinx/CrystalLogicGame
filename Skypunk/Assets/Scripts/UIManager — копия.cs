using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private Transform panelFuel;
    [SerializeField] private Transform panelLoot;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sceneController.maxFuel; i++)
        {
            if (i < sceneController.fuel)
                panelFuel.GetChild(i).gameObject.SetActive(true);
            else
                panelFuel.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < sceneController.lootList.Count; i++)
        {
            panelLoot.GetChild(i).GetChild(1).GetComponent<Text>().text = Convert.ToString(sceneController.lootList[i]);
        }
    }
}

// тест 2
