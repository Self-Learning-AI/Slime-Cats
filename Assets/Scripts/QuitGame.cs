using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    //TRYING TO UNDERSTAND CO ROUTINES AND INVOKE
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Run()
    {
        Debug.Log("Quitting Game...");
        yield return new WaitForSeconds(2f);
        //Application.Quit();
    }

    public void CallExit()
    {
        Invoke("Quit", 5.0f);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
    }
}
