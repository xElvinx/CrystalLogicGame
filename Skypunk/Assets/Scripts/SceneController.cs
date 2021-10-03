using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public float health = 5f;
    [SerializeField] private Text healthText;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseCard(GameObject card)
    {
        DataCard dataCard = card.GetComponent<DataCard>();

        switch (dataCard.card)
        {
            case 0:
                health -= dataCard.Damage;
                healthText.text = Convert.ToString(health);
                break;
        }
    }
}
