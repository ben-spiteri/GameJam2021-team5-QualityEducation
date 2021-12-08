using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public Slider SliderClass;
    public Slider SliderStaff;
    public Slider SliderGym;
    public Slider SliderCanteen;

    public Button button;
    public Button EndMonthButton;
    public Button YesButton;
    public Button NoButts;

    public float clas = 0;
    public float staff = 0;
    public float gym = 0;
    public float canteen = 0;

    public float total = 0;

    public GameObject err;

    float budgets = 0;

    public GameObject map;
    public GameObject back;
    public GameObject txbPanel;

    public Variables variables;

    public bool checkPlus = true;

    public Text gymStats;
    public Text staffStats;
    public Text canteenStats;
    public Text classesStats;
    public Text gymStatsf;
    public Text staffStatsf;
    public Text canteenStatsf;
    public Text classesStatsf;
    public Text SD_Index;

    void start(){
        variables.init_vars();
    }

    void Update()
    {   
        
        Screen.SetResolution(1280, 720, false);
        
        variables = GetComponent<Variables>();


        

        clas = SliderClass.value;
        staff = SliderStaff.value;
        gym = SliderGym.value;
        canteen = SliderCanteen.value;
        
        total = (clas + staff + gym + canteen);

        variables.reserve = variables.budget - total;
        budgets = variables.budget;
        if(total > budgets)
        {
            button.enabled = false;
            err.gameObject.SetActive(true);
        }
        else
        {
            button.enabled = true;
            err.gameObject.SetActive(false);
        }
        
        string gymtext = variables.sportMetric.ToString();
        gymStats.text = gymtext;

        string stafftext = variables.tMoral.ToString();
        staffStats.text = stafftext;
        
        string studtext = variables.studMoral.ToString();
        canteenStats.text = studtext;
        
        string edutext = variables.educMetric.ToString();
        classesStats.text = edutext;

        string gymtextf = variables.sportMetric.ToString();
        gymStatsf.text = gymtextf;

        string stafftextf = variables.tMoral.ToString();
        staffStatsf.text = stafftextf;
        
        string studtextf = variables.studMoral.ToString();
        canteenStatsf.text = studtextf;
        
        string edutextf = variables.educMetric.ToString();
        classesStatsf.text = edutextf;

        string SDItext = variables.sdi.ToString();
        SD_Index.text = SDItext;
    }
    


    public void Initiate()
    {

        map.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
        txbPanel.gameObject.SetActive(true);

    
        variables.start_Game(gym, clas, staff, canteen);
        
    }
}
