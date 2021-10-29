using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ivent : MonoBehaviour
{
    // Testing
    public GameObject Scene;
    [SerializeField] private Transform panelIvent;
    
    public DataIvent Ivents = new DataIvent();
    public Sprite lootBox;

    public void Close(GameObject gameObject)
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
        panelIvent.GetChild(3).gameObject.SetActive(true);
        panelIvent.GetChild(4).gameObject.SetActive(true);

        panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = lootBox;
        panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = "";
        panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = "";

        panelIvent.GetChild(6).gameObject.SetActive(false);
    }

    public void VarA(GameObject gameObject)
    {
        panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextA;
        if (Ivents.dataLootA != null)
        {
            panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootA.img;
            panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootA.Name;
            panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = Ivents.countA.ToString();
        } else if (Ivents.name == "Dinner" || Ivents.name == "EasyNavar" || Ivents.name == "Wanderers")
        {
            Scene.GetComponent<SceneController>().fuel -= 2;
        } else if (Ivents.name == "Precious" || Ivents.name == "TaleTraveler" || Ivents.name == "ThornyPath")
        {
            for (int i = 0; i < 2; i++)
            {
                if (Scene.GetComponent<SceneController>().iron > 0)
                    Scene.GetComponent<SceneController>().iron -= 1;
                else
                    Scene.GetComponent<SceneController>().health -= 1;
            }
        }

        panelIvent.GetChild(3).gameObject.SetActive(false);
        panelIvent.GetChild(4).gameObject.SetActive(false);

        panelIvent.GetChild(6).gameObject.SetActive(true);
    }

    public void VarB(GameObject gameObject)
    {
        //DataIvent thisEvent = Scene.GetComponentInChildren<Search>().GetComponent<DataIvent>();
        panelIvent.GetChild(2).GetComponent<Text>().text = Ivents.TextB;
        if (Ivents.dataLootB != null)
        {
            panelIvent.GetChild(5).GetChild(0).GetComponent<Image>().sprite = Ivents.dataLootB.img;
            panelIvent.GetChild(5).GetChild(1).GetComponent<Text>().text = Ivents.dataLootB.Name;
            panelIvent.GetChild(5).GetChild(2).GetComponent<Text>().text = Ivents.countB.ToString();
            if (Ivents.name == "Wanderers")
            {
                Scene.GetComponent<SceneController>().fuel -= 1;
            }
        } else if (Ivents.name == "DeathLuck" || Ivents.name == "ThornyPath")
        {
            Scene.GetComponent<SceneController>().fuel += 2;
        } else if (Ivents.name == "Silhouettes")
        {
            Scene.GetComponent<SceneController>().fuel -= 2;
        }

        panelIvent.GetChild(3).gameObject.SetActive(false);
        panelIvent.GetChild(4).gameObject.SetActive(false);

        panelIvent.GetChild(6).gameObject.SetActive(true);
    }
}
