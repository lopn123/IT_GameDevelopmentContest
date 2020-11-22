using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{
    public GameObject cuntScene1;
    public GameObject cuntScene2;
    public GameObject cuntScene3;
    public GameObject cuntScene4;
    public GameObject cuntScene5;
    public GameObject cuntScene6;
    public GameObject cuntScene7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(cuntScene1.activeSelf)
            {
                cuntScene1.SetActive(false);
                cuntScene2.SetActive(true);
            }
            else if (cuntScene2.activeSelf)
            {
                cuntScene2.SetActive(false);
                cuntScene3.SetActive(true);
            }
            else if(cuntScene3.activeSelf)
            {
                cuntScene3.SetActive(false);
                cuntScene4.SetActive(true);
            }
            else if(cuntScene4.activeSelf)
            {
                cuntScene4.SetActive(false);
                cuntScene5.SetActive(true);
            }
            else if(cuntScene5.activeSelf)
            {
                cuntScene5.SetActive(false);
                cuntScene6.SetActive(true);
            }
            else if(cuntScene6.activeSelf)
            {
                cuntScene6.SetActive(false);
                cuntScene7.SetActive(true);
            }
            else if (cuntScene7.activeSelf)
            {
                cuntScene7.SetActive(true);
                SceneManager.LoadScene("Title");
            }
        }
    }
}
