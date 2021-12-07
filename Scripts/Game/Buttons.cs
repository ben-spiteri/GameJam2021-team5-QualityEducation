using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public Variables variables;
    
    public int check;
    public int c = 0;
    
    void Start()
    {
       check = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void YesButtonClass()
    {
        //variables = GetComponent<Variables>();

        variables.educMetric += check;

        check = 0;
    }

    public void YesButtonGym(){

        variables.sportMetric += check;

        check = 0;

        c = 5;
    }

    public void YesButtonCanteen(){

        variables.studMoral += check; 

        check = 0;
    }
    public void YesButtonStaffRoom(){

        variables.tMoral += check;

        check = 0;
    }
}