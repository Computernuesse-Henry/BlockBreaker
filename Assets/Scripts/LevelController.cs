using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int totalblocks;
    SceneLoader sceneLoader;

    public void CountBreakableBlocks()
    {
        totalblocks++;
    }

    public void DestroyBlock()
    {
        totalblocks--;
        if (totalblocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
         
    }
    
    void Start()
    {
        
    }

   
    
}
