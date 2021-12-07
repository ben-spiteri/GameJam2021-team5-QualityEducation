using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progression : MonoBehaviour
{

    public string scene_to_load;
    public Variables variables;
    public void Awake(){
        Scene scene = SceneManager.GetActiveScene(); 
        scene_to_load = scene.name;

        DontDestroyOnLoad(transform.gameObject);
    }

    public int c = 0;


    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
              
    }


    public void loop_around(){
        c = c+1;
        if(variables.month >= 9){
            //load the end scene
        }
        else {
            variables.month++;

            float sdi = variables._sdi_(variables.studMoral, variables.tMoral, variables.educMetric, variables.sportMetric);
            variables.CalcBudget(sdi);


            SceneManager.LoadScene(scene_to_load);
        }
    }
}
