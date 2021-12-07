using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class level : MonoBehaviour
{
    public List<GameObject> classblock = new List<GameObject>();
    public List<GameObject> gym = new List<GameObject>();
    public int budget = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(budget <= 100)
        {
            classblock[0].SetActive(true);       
            classblock[1].SetActive(false);
            classblock[2].SetActive(false);
            classblock[3].SetActive(false);
        }
        if(budget >= 101)
        {
            classblock[0].SetActive(false);       
            classblock[1].SetActive(true);
            classblock[2].SetActive(false);
            classblock[3].SetActive(false);
        }
        if(budget >= 202)
        {
            classblock[0].SetActive(false);       
            classblock[1].SetActive(false);
            classblock[2].SetActive(true);
            classblock[3].SetActive(false);
        }
        if(budget >= 300)
        {
            classblock[0].SetActive(false);
            classblock[1].SetActive(false);
            classblock[2].SetActive(false);
            classblock[3].SetActive(true);
        }
        if(budget <= 0)
        {
            classblock[0].SetActive(false);
            classblock[1].SetActive(false);
            classblock[2].SetActive(false);
            classblock[3].SetActive(false);
        }

        if(Input.GetKeyDown("space"))
        {
            budget += 100;
        }
    }
}
