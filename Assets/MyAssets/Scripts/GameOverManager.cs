using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    
    public Scrollbar lifeBar;
    public static GameOverManager gameOverManager;
    // Start is called before the first frame update
    void Start()
    {
        gameOverManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeBar.size <= 0)
        {
            //print("Game Over");
            CallGameOver();
        }
    }
    public void CallGameOver()
    {
        //player.SetActive(false);
        ScenesManager.scenesManager.GameOverScene();
        
    }
}
