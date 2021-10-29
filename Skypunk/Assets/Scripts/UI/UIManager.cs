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
            OpenPanel();
        } else if (Input.GetKey(KeyCode.Escape))
        {
            panelLoot.gameObject.SetActive(false);
        }
    }

    public void OpenPanel()
    {
        int j = 0;
        panelLoot.gameObject.SetActive(true);
        Transform panel = GameObject.FindGameObjectWithTag("LootList").transform;

        foreach (var i in sceneController.lootList)
        {
            if (i.Value > 0)
            {
                DataLoot dataLoot = Resources.Load<DataLoot>("ScriptableObjects/Loot/" + i.Key);
                
                panel.GetChild(j).GetChild(0).GetComponent<Text>().text = i.Key;
                panel.GetChild(j).GetChild(1).GetComponent<Text>().text = i.Value.ToString();

                Image lootImg = panel.GetChild(j).GetChild(2).GetComponent<Image>();

                lootImg.sprite = dataLoot.img;
                lootImg.color = new Color(lootImg.color.r, lootImg.color.g, lootImg.color.b, 1);
                j++;
            }
        }

        for (int i = 0; i < panel.childCount; i++)
        {
            if (i >= sceneController.lootList.Count)
            {
                panel.GetChild(i).GetChild(0).GetComponent<Text>().text = "";
                panel.GetChild(i).GetChild(1).GetComponent<Text>().text = "";
                panel.GetChild(i).GetChild(2).GetComponent<Image>().color = new Color(255, 255, 255, 0);
            }
            panel.GetChild(i).GetChild(3).gameObject.SetActive(false);
        }

        Text money = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
        money.text = sceneController.money.ToString();
    }
}

// тест 2
