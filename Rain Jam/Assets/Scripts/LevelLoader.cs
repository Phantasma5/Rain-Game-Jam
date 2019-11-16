using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(string aLevel)
    {
        if(aLevel == "Level")
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
        SceneManager.LoadScene(aLevel);
    }
    private void Start()
    {
        if(null != References.playerStatSystem)
        {
            References.playerStatSystem.AddCallBack(StatSystem.StatType.Heat, PlayerDead);
        }
    }
    private void PlayerDead(StatSystem.StatType aStat, float aValue)
    {
        if(aValue <= 0)
        {
            LoadLevel("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if("Player" == other.tag)
        {
            LoadLevel("Victory");
        }
    }
}
