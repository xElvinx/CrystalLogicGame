using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public List<int> lootList = new List<int>() { 0, 0, 0, 0, 0, 0 };
    public int fuel = 10;
    public int maxFuel = 10;

    public float health = 5f;
    [SerializeField] private Text healthText;

    public void UseCard(GameObject card)
    {
        DataCard dataCard = card.GetComponent<Card>().dataCard;
        fuel -= 1;
        switch (dataCard.card)
        {
            case DataCard.classCard.Enemy:
                health -= dataCard.Damage;
                healthText.text = Convert.ToString(health);
                break;

            case DataCard.classCard.Search:
                lootList = card.GetComponent<Card>().GetLoot(lootList);
                break;

            case DataCard.classCard.Fuel:
                if (fuel < 10)
                    fuel = card.GetComponent<Card>().GetFuel(fuel);
                break;
        }
        Debug.Log(fuel);
    }
}
