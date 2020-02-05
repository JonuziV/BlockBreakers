using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparkleAnimation;
    
    [SerializeField] Sprite[] hitSprites;
    //cached reference 
    Level level;
    GameStatus gameStatus;
   [SerializeField] int timesHit; //only serialized for debug

   private void Start() {
       CountBreakableBlocks();
    }
   private void OnCollisionEnter2D(Collision2D collision) {
      if(tag == "Breakable"){
         HandleHits();
      }
   }

   private void HandleHits(){
      timesHit++;
      int maxHits = hitSprites.Length + 1;
      if(timesHit >= maxHits){
         DestroyBlock();
      }
      else {
         ShowNextHitSprite();
      } 
   }

   private void ShowNextHitSprite(){
      int spriteIndex = timesHit - 1;
      if(hitSprites[spriteIndex] != null){
         GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
      } else{
         Debug.LogError("Block sprite is missing from array " + gameObject.name + "!");
      }
   }
   private void CountBreakableBlocks(){
    level = FindObjectOfType<Level>();
       gameStatus = FindObjectOfType<GameStatus>();
       if(tag == "Breakable"){
          level.CountBlocks();
       }
   }

   private void DestroyBlock(){
       PlayBlockDestroySFX();
       Destroy(gameObject);
       level.BlockDestroyed();
       TriggerSparklesVFX();
   
   }

   private void TriggerSparklesVFX(){
       GameObject sparkles = Instantiate(sparkleAnimation,transform.position,transform.rotation);
       Destroy(sparkles, 1f);
   }

   private void PlayBlockDestroySFX(){
      AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position);
       gameStatus.AddToScore();
   }
}
