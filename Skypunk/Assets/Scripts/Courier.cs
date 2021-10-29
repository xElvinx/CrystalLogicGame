using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courier : MonoBehaviour
{
    public PanelLoot loot;
    public Transform panelCourier;
    public Transform panelWarning;
    public UIManager panelLoot;

    public void Warning()
    {
        panelWarning.parent.gameObject.SetActive(true);
        panelWarning.gameObject.SetActive(true);
    }

    public void Delivery()
    {
        panelWarning.gameObject.SetActive(false);
        panelCourier.parent.gameObject.SetActive(true);
        panelCourier.gameObject.SetActive(true);
        loot.isDelete = false;
    }

    public void DeckBtn()
    {
        panelLoot.OpenPanel();
    }

    public void ClosePanel(GameObject gameObject)
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
