using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class LostScript : MonoBehaviour
{
    public GameObject WrongOne;
    public void ShowWrong()
    {
        transform.GetChild(0).gameObject.SetActive(true); 
    }
}
