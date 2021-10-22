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

        int j = 0;

        foreach (var i in sceneController.lootList)
        {
            panelLoot.GetChild(j).GetChild(1).GetComponent<Text>().text = Convert.ToString(sceneController.lootList[i.Key]);
            j++;
        }
    }
}

// тест 2
