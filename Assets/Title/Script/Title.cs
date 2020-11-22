using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Image InfoImage;
    public Image ExitImage;

    void Start()
    {
        InfoImage.enabled = false;
        ExitImage.enabled = false;
    }
    // Start is called before the first frame update
    public void LodingBut()
    {
        SceneManager.LoadScene("Loding");
    }

    public void InfoBut()
    {
        InfoImage.enabled = true;
        ExitImage.enabled = true;
    }

    public void InfoExitBut()
    {
        InfoImage.enabled = false;
        ExitImage.enabled = false;
    }
    public void ExitBtn() { Application.Quit(); }

   
}
