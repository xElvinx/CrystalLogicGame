using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightUIManager : MonoBehaviour
{
    [SerializeField] private MusicManager musicManager;

    [SerializeField] private Transform btn;
    [SerializeField] private Transform panelInfo;
    [SerializeField] private Transform panelShield;
    [SerializeField] private Transform panelAttack;
    [SerializeField] private Color activePhaseColor;
    [SerializeField] private Color nonActivePhaseColor;

    [SerializeField] private SceneController controller;
    [SerializeField] private Text healthTextPlayer;
    [SerializeField] private Text ironTextPlayer;

    [SerializeField] private SpriteRenderer imageEnemy;

    [SerializeField] private Text healthTextEnemy;
    [SerializeField] private Text damageTextEnemy;

    [SerializeField] private ParticleSystem particleSystemPlayer;
    [SerializeField] private ParticleSystem particleSystemEnemy;

    [SerializeField] private SearchBaloon searchBaloon;

    public Card card;

    private int phase = 1;
    private Fight fight;

    private void Start()
    {
        fight = new Fight();

        for (int i = 0; i < panelShield.childCount; i++)
        {
            panelShield.GetChild(i).GetComponent<EventTrigger>().enabled = false;
        }
    }

    void Update()
    {
        healthTextPlayer.text = controller.health.ToString();
        ironTextPlayer.text = controller.iron.ToString();

        imageEnemy.sprite = card.dataCard.img;
        healthTextEnemy.text = card.Health.ToString();
        damageTextEnemy.text = card.Damage.ToString();

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) 
        {
            AddPoint(1);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            AddPoint(2);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            AddPoint(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            AddPoint(4);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
        {
            AcceptPhase();
        }

        for (int i = 0; i < panelInfo.childCount; i++) 
        {
            panelInfo.GetChild(i).GetComponent<Text>().color = nonActivePhaseColor;
            if (i == phase - 1)
                panelInfo.GetChild(i).GetComponent<Text>().color = activePhaseColor;
        }

        /*if (phase < 4)
        {
            btn.GetChild(0).GetComponent<Text>().text = "CONTINUE";
        } else
        {
            btn.GetChild(0).GetComponent<Text>().text = "DONE";
        }*/

    }

    public void AddPoint(int point)
    {
        if (phase < 4)
        {
            fight.pointsPlayer[phase - 1] = point;
            if (phase == 1)
            {
                for (var i = 0; i < panelAttack.childCount; i++)
                {
                    if (i == point - 1)
                    {
                        panelAttack.GetChild(i).GetChild(0).gameObject.SetActive(true);
                        panelAttack.GetChild(i).GetChild(1).gameObject.SetActive(false);
                    }
                    else
                    {
                        panelAttack.GetChild(i).GetChild(0).gameObject.SetActive(false);
                        panelAttack.GetChild(i).GetChild(1).gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                for (var i = 0; i < panelShield.childCount; i++)
                {
                    if (i == point - 1)
                    {
                        panelShield.GetChild(i).GetChild(0).gameObject.SetActive(true);
                        panelShield.GetChild(i).GetChild(1).gameObject.SetActive(false);
                    }
                    else
                    {
                        panelShield.GetChild(i).GetChild(0).gameObject.SetActive(false);
                        panelShield.GetChild(i).GetChild(1).gameObject.SetActive(true);
                    }

                    if (phase == 3)
                    {
                        panelShield.GetChild(fight.pointsPlayer[1] - 1).GetChild(0).gameObject.SetActive(true);
                        panelShield.GetChild(fight.pointsPlayer[1] - 1).GetChild(1).gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public void AcceptPhase()
    {
        if (phase < 4)
        {
            if (phase == 1)
            {
                for (var i = 0; i < panelAttack.childCount; i++)
                {
                    panelAttack.GetChild(i).GetComponent<EventTrigger>().enabled = false;
                    panelShield.GetChild(i).GetComponent<EventTrigger>().enabled = true;
                }
            } else if (phase == 3)
            {
                for (var i = 0; i < panelShield.childCount; i++)
                {
                    panelShield.GetChild(i).GetComponent<EventTrigger>().enabled = false;
                }
            }

            phase++;
        }
        else
        {
            phase = 1;
            for (var i = 0; i < panelAttack.childCount; i++)
            {
                panelAttack.GetChild(i).GetComponent<EventTrigger>().enabled = true;
                panelAttack.GetChild(i).GetChild(0).gameObject.SetActive(false);
                panelAttack.GetChild(i).GetChild(1).gameObject.SetActive(true);

                panelShield.GetChild(i).GetChild(0).gameObject.SetActive(false);
                panelShield.GetChild(i).GetChild(1).gameObject.SetActive(true);
            }

            fight.playerParticle = particleSystemPlayer;
            fight.enemyParticle = particleSystemEnemy;

            int healthEnemy = fight.Battle(controller, card);
            musicManager.PlayBattleMusic();
            fight.pointsPlayer = new List<int> { 0, 0, 0 };
            if (healthEnemy <= 0)
                Win();
        }        
    }

    public void Win()
    {
        transform.gameObject.SetActive(false);
        controller.transform.GetChild(0).gameObject.SetActive(true);
        controller.transform.GetChild(1).gameObject.SetActive(true);
        searchBaloon.Reward();
    }
}
