using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public List<int> pointsPlayer = new List<int>() { 0, 0, 0 };

    public List<int> pointsEnemy = new List<int>() { 0, 0, 0 };

    public int Battle(SceneController controller, Card card)
    {
        for (var i = 0; i < pointsEnemy.Count; i++)
        {
            pointsEnemy[i] = Random.RandomRange(1, 5);
        }

        if (pointsEnemy[0] != pointsPlayer[1] && pointsEnemy[0] != pointsPlayer[2])
        {
            for (int i = 0; i < card.Damage; i++)
            {
                if (controller.iron > 0)
                    controller.iron--;
                else
                    controller.health--;
            }
        }

        if (pointsPlayer[0] != pointsEnemy[1] && pointsPlayer[0] != pointsEnemy[2] && pointsPlayer[0] != 0)
        {
            card.Health -= controller.damage;
        }

        return card.Health;
    }
}
