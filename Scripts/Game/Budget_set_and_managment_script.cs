using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Budget_set_and_managment_script : MonoBehaviour
{
  public GameManager1 gameManager1;

  public Slider Gym;
  public Slider Canteen;
  public Slider Staff;
  public Slider Classroom;

  public Button Next_page_button;

  public Text Budget;
  public float starting_budget;

  public Text Reserve;
  public float reserve_left;

  public Text Month;
  public float CurrentMonth = 0;


  public Text Gym_val;
  public float GymVal;

  public Text Canteen_val;
  public float CanteenVal;

  public Text Staff_val;
  public float StaffVal;

  public Text Classroom_val;
  public float ClassroomVal;

  public Variables variables;


  public bool Button_is_active = false;
    // Start is called before the first frame update
    void Start()
    {
      
      variables.init_vars();
      if (gameManager1 == null)    
        gameManager1 = GetComponent<GameManager1>();

        if (variables == null)
          variables = GetComponent<Variables>();

        starting_budget = variables.budget;
        Debug.Log(variables.budget);

        reserve_left = variables.reserve;

        Button Btn = Next_page_button.GetComponent<Button>();
        Btn.onClick.AddListener(TaskOnClick);

        Gym.maxValue = starting_budget;
        Canteen.maxValue = starting_budget;
        Staff.maxValue = starting_budget;
        Classroom.maxValue = starting_budget;

        CurrentMonth = variables.month;

    }

    // Update is called once per frame
    void Update()
    {

      Gym.maxValue = starting_budget;
      Canteen.maxValue = starting_budget;
      Staff.maxValue = starting_budget;
      Classroom.maxValue = starting_budget;


      CurrentMonth = variables.month;

      reserve_left = variables.reserve;
      starting_budget = variables.budget;

      Budget.text = starting_budget.ToString();

      Reserve.text = reserve_left.ToString();

      Month.text = CurrentMonth.ToString();

      GymVal = Gym.value;
      Gym_val.text = GymVal.ToString();

      CanteenVal = Canteen.value;
      Canteen_val.text = CanteenVal.ToString();

      StaffVal = Staff.value;
      Staff_val.text = StaffVal.ToString();

      ClassroomVal = Classroom.value;
      Classroom_val.text = ClassroomVal.ToString();


      if ((GymVal + CanteenVal + StaffVal + ClassroomVal) <= starting_budget)
      {
        Button_is_active = true;
      }
      else
      {
        Button_is_active = false;
      }
    }

    void TaskOnClick(){
      if (Button_is_active == true) {
        //Filler line to be replaced by code.

      }
      else
      {
        // Make text box saying that the maximum amount has been exceeded.
      }
  	}


}
