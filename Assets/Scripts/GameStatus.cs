using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlockDestroyed = 50;
    [SerializeField] int currentScore = 0;
    [SerializeField] Text scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Awake() {
        int gameStatusCount= FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }   else{
            DontDestroyOnLoad(gameObject);
        } 
    }
    private void Start() {
        scoreText = FindObjectOfType<Text>();
    }
    void Update(){
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(){
        currentScore += pointPerBlockDestroyed;
        scoreText.text = currentScore.ToString(); 
    }

    public void ResetGame(){
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }
}
