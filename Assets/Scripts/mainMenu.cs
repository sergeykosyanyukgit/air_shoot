using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public void startLevel(){
        Application.LoadLevel("SampleScene");
    }
    public void exitGame(){
        Application.Quit();
    }
}
