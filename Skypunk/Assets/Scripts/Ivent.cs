using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ivent : MonoBehaviour
{
    // Start is called before the first frame update
    public void Close(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
