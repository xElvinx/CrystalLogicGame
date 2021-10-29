using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivent : MonoBehaviour
{
    // Testing
    public void Close(GameObject gameObject)
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
