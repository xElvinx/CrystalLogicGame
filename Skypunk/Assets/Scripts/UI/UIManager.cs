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


        if (Input.GetKey(KeyCode.Tab))
        {
            int j = 0;
            panelLoot.gameObject.SetActive(true);

            foreach (var i in sceneController.lootList)
            {
                if (i.Value > 0)
                {
                    DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);

                    //panelLoot.GetChild(j).gameObject.SetActive(true);
                    panelLoot.GetChild(j).GetComponent<Image>().sprite = dataLoot.img;
                    panelLoot.GetChild(j).GetChild(0).GetComponent<Text>().text = i.Key;
                    panelLoot.GetChild(j).GetChild(1).GetComponent<Text>().text = i.Value.ToString();
                    j++;
                }
            }

            Text money = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
            money.text = sceneController.money.ToString();
        } else if (Input.GetKey(KeyCode.Escape))
        {
            panelLoot.gameObject.SetActive(false);
        }

    }
}

// тест 2
