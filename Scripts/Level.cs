using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks; //for debuging

    SceneLoader sceneLoader; //cached refs

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>(); //add component
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene(); 
        }
    }


}
