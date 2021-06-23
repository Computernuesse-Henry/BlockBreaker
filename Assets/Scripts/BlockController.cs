using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] AudioClip BreakeSound;
    [SerializeField] GameObject BlockParticleEffect;
    LevelController level;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(BreakeSound, Camera.main.transform.position);
        
        Destroy(gameObject);
        Debug.Log(collision.gameObject.name);
        ShowEffect();
        var gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.Scorecalculador();
        level.DestroyBlock();
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
}
