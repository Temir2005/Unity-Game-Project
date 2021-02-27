using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class MoveSystem : MonoBehaviour
{

    public GameObject correctForm;
    private bool moving;
    private bool finish;
    private float startPosX;
    private float startPosY;
    private Vector3 resetPosition;
    public GameObject WrongText;
    [SerializeField] private AudioSource WrongAnswer;
    [SerializeField] private AudioSource RightAnswer;
    [SerializeField] private AudioSource DropItem;
    [SerializeField] private AudioSource PickItem;
    // Update is called once per frame
    void Start()
    {
        resetPosition = this.transform.localPosition;
    }
    void Update()
    {
        if(finish == false){
            if(moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }
    }

    private void OnMouseDown(){
        if(Input.GetMouseButton(0))
        {
            PickItem.Play();
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }
    public void deleteWrongone()
    {
        WrongText.SetActive(false);
    }
    private void OnMouseUp(){
        moving = false;
        if(Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 1.5f && Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 1.5f)
        {
            this.transform.localPosition = new Vector3(correctForm.transform.localPosition.x, correctForm.transform.localPosition.y, correctForm.transform.localPosition.z);
            finish = true;
            GameObject.Find("PointsHandler").GetComponent<WinScript>().AddPoints();
            RightAnswer.Play();
        }
        else{
            if(Mathf.Abs(this.transform.localPosition.x - 5f) <= 1.5f && Mathf.Abs(this.transform.localPosition.y - 3.5f) <= 1.5f){
                this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
                WrongAnswer.Play();
                WrongText.SetActive(true);
                Invoke("deleteWrongone", 0.5f);
            }
            else if(Mathf.Abs(this.transform.localPosition.x + 6f) <= 1.5f && Mathf.Abs(this.transform.localPosition.y - 3.5f) <= 1.5f){
                this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
                WrongAnswer.Play();
                WrongText.SetActive(true);
                Invoke("deleteWrongone", 0.5f);
            }
            else if(Mathf.Abs(this.transform.localPosition.x - 0f) <= 1.5f && Mathf.Abs(this.transform.localPosition.y - 3.5f) <= 1.5f){
                this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
                WrongAnswer.Play();
                WrongText.SetActive(true);
                Invoke("deleteWrongone", 0.5f);
            }
            else{
                DropItem.Play();
            }
        }
    }
}
