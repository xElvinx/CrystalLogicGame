using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public DataCard dataCard;
    void Start()
    {
        //dataCard = GetComponent<DataCard>();

        //dataCard.Damage = Random.Range(1, 5);

    }

    void Update()
    {
        //dataCard.DamageText.text = System.Convert.ToString(dataCard.Damage);
    }

    public List<int> GetLoot(List<int> list)
    {
        int count = Random.Range(1, 4);

        list[Random.Range(1, 5)] += count; // 1 - 5 перечисляемые ресурсы (ткань, металл и т.д.)

        return list;
    }

    public int GetFuel(int fuel)
    {
        fuel += Random.Range(2, 2);
        return fuel;
    }
}
