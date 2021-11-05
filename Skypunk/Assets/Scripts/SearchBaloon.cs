using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBaloon : MonoBehaviour
{
    [SerializeField] private Transform panelLoot;
    [SerializeField] private SceneController controller;

    private List<Item> listItem = new List<Item>();
    private DataLoot dataLoot;

    private void Restart()
    {
        for (int i = 0; i < panelLoot.childCount; i++)
        {
            Transform child = panelLoot.GetChild(i);

            child.GetChild(0).gameObject.SetActive(false);
            child.GetChild(1).gameObject.SetActive(false);
            child.GetChild(2).gameObject.SetActive(false);
            child.GetChild(3).gameObject.SetActive(false);
        }
    }

    public void Looting()
    {
        Restart();
        int countLoot = Random.Range(0, 7);
        Debug.Log(countLoot);

        for (int i = 0; i < countLoot; i++)
        {
            DataLoot[] listLoot = Resources.LoadAll<DataLoot>("ScriptableObjects/Loot");
            dataLoot = listLoot[Random.Range(0, listLoot.Length)];

            panelLoot.GetChild(i).GetChild(0).gameObject.SetActive(true);
            panelLoot.GetChild(i).GetChild(1).gameObject.SetActive(true);
            panelLoot.GetChild(i).GetChild(2).gameObject.SetActive(true);

            panelLoot.GetChild(i).GetChild(0).GetComponent<Image>().sprite = dataLoot.img; // Изображение лута
            panelLoot.GetChild(i).GetChild(1).GetComponent<Text>().text = dataLoot.Name; // Название лута
            panelLoot.GetChild(i).GetChild(2).GetComponent<Text>().text = Random.Range(1, 5).ToString(); // Количество лута
        }
    }

    public void SelectLoot(Transform btn)
    {
        if (!btn.GetChild(3).gameObject.activeSelf)
        {
            listItem.Add(new Item
            {
                index = btn.GetSiblingIndex(),
                nameItem = btn.GetChild(1).GetComponent<Text>().text,
                countItem = System.Convert.ToInt32(btn.GetChild(2).GetComponent<Text>().text)
            });

            btn.GetChild(3).gameObject.SetActive(true);
        }
    }

    public void ConfirmLoot()
    {
        if (listItem.Count > 0)
        {
            foreach (var i in listItem)
            {
                if (!controller.lootList.ContainsKey(i.nameItem))
                {
                    controller.lootList[i.nameItem] = i.countItem;
                }
                else
                {
                    controller.lootList[i.nameItem] += i.countItem;
                }
            }
        }
        transform.gameObject.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}
