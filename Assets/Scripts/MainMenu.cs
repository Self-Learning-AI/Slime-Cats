using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : PauseMenu
{
    private void Start()
    {
        pauseMenu.SetActive(true);
    }
    // Override the pause key detection
    public override void Update()
    {
        
    }
}
