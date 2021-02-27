using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private int PointsToWin;
    private int PointsCnt;
    public GameObject MyPieces;
    void Start()
    {
        PointsToWin = MyPieces.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
     if(PointsCnt >= PointsToWin){
         transform.GetChild(0).gameObject.SetActive(true);
     }   
    }
    public void AddPoints(){
        PointsCnt++;
    }
}
