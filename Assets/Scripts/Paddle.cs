using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config parameters
    [SerializeField] float screenWidthInUnits = 16;
    [SerializeField] float minPos;
    [SerializeField] float maxPos;

    //cached references
    GameStatus theGameStatus;
    Ball theBall;
    // Start is called before the first frame update
    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall  = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddelPos = new Vector2(transform.position.x, transform.position.y);
        paddelPos.x = Mathf.Clamp(GetXPos(), minPos, maxPos);
        transform.position = paddelPos;
    }

    private float GetXPos(){
        if(theGameStatus.IsAutoPlayEnabled()){
            return theBall.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
