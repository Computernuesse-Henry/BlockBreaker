using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] AudioClip BreakeSound;
    [SerializeField] GameObject BlockParticleEffect;    
    [SerializeField] public int Blockleben;
    [SerializeField] Sprite[] hitSprites;
    LevelController level;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(BreakeSound, Camera.main.transform.position);
        ShowEffect();
        if (tag == "breakable")
        {
            Blockleben--;            
            if (Blockleben <= 0)
            {                
                
                var gameStatus = FindObjectOfType<GameStatus>();
                gameStatus.Scorecalculador();
                Destroy(gameObject);
            } 
            else
            {
                ShowNextHitSprite(); 
            }
        }
        
    }


    private void Start()
    {
       level = FindObjectOfType<LevelController>();
       level.CountBreakableBlocks();
    }

    private void ShowEffect()
    {
        Instantiate(BlockParticleEffect, transform.position, transform.rotation);
    }
    private void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[Blockleben -1];
    }
}
