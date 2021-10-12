using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public List<int> lootList = new List<int>() { 0, 0, 0, 0, 0, 0 };
    public List<int> rareItemsList = new List<int>() { 0, 0, 0 };
    public List<int> legendaryItemsList = new List<int>() { 0, 0, 0 };

    public List<int> weaponList = new List<int>();
    public int fuel = 15;
    public int maxFuel = 20;

    public float health = 15f;
    [SerializeField] private Text healthText;

    public float iron = 5f;
    [SerializeField] private Text ironText;

    void Update()
    {
        healthText.text = Convert.ToString(health);
        ironText.text = Convert.ToString(iron);
    }

    public void UseCard(GameObject card)
    {
        DataCard dataCard = card.GetComponent<Card>().dataCard;
        fuel -= 2;
        switch (dataCard.card)
        {
            case DataCard.classCard.Enemy:
                for (int i = 0; i < card.GetComponent<Card>().Damage; i++)
                {
                    if (iron > 0)
                        iron -= 1;
                    else
                        health -= 1;
                }

                healthText.text = Convert.ToString(health);
                ironText.text = Convert.ToString(iron);
                break;

            case DataCard.classCard.Search:
                lootList = card.GetComponent<Card>().GetLoot(lootList);
                break;

            case DataCard.classCard.Fuel:
                if (fuel < maxFuel)
                    fuel = card.GetComponent<Card>().GetFuel(fuel);
                break;
        }
    }
}
