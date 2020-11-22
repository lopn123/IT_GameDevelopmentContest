using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMachine : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Machine")
        {
            Destroy(this.gameObject);
            GameManager.Instance.M2count++;
            GameManager.IsHold = false;
            if(GameManager.Instance.M2count == 10)
                particle.Stop();
        }
    }
}
