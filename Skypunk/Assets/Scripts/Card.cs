using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public DataCard dataCard;
    public float Damage;

    private Text header;
    private Text text;
    private Text VarA;
    private Text VarB;

    [SerializeField] private Text textDamage;
    [SerializeField] private DataIvent Ivent;

    public Transform panelIvent;
    public GameObject search;

    void Start()
    {
        if (dataCard.card == DataCard.classCard.Enemy)
        {
            Damage = Random.Range(dataCard.minDamage, dataCard.maxDamage);
            textDamage.text = System.Convert.ToString(Damage);
        }

        if (Ivent != null)
        {
            header = panelIvent.GetChild(0).GetComponent<Text>();
            text = panelIvent.GetChild(2).GetComponent<Text>();
            VarA = panelIvent.GetChild(3).GetChild(0).GetComponent<Text>();
            VarB = panelIvent.GetChild(4).GetChild(0).GetComponent<Text>();
        }
    }

    public Dictionary<string, int> GetLoot(Dictionary<string, int> list)
    {
        if (Random.Range(0, 100) < 50)
        {
            search.GetComponent<Search>().Restart();
            search.SetActive(true);

        } else if (Ivent != null)
        {
            header.text = Ivent.TextHeader;
            text.text = Ivent.Text;
            VarA.text = Ivent.VarA;
            VarB.text = Ivent.VarB;

            panelIvent.parent.gameObject.SetActive(true);
            panelIvent.gameObject.SetActive(true);
        }

        return list;
    }

    public int GetFuel(int fuel)
    {
        fuel += Random.Range(3, 6);
        return fuel;
    }
}
