using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_Manager : MonoBehaviour
{
  public GameObject ClassBlock;
  public GameObject Canteen;
  public GameObject StaffRoom;
  public GameObject Gym;
  public GameObject Hall;
  public bool Is_clicked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
// if (myGameObject.activeSelf)
//    print ("Active")
    public void OpenPanel_ClassBlock()
    {




      if(ClassBlock != null )
      {
            bool isActive = ClassBlock.activeSelf;
            ClassBlock.SetActive(!isActive);
      }



    }

    public void OpenPanel_Canteen()
    {

      if(Canteen != null)
      {
          bool isActive = Canteen.activeSelf;
          Canteen.SetActive(!isActive);
      }

    }
    public void OpenPanel_Staff()
    {
      if(StaffRoom != null)
      {
          bool isActive = StaffRoom.activeSelf;
          StaffRoom.SetActive(!isActive);
      }

    }
    public void OpenPanel_Gym()
    {
      if(Gym != null)
      {
          bool isActive = Gym.activeSelf;
          Gym.SetActive(!isActive);
      }

    }
    public void OpenPanel_Hall()
    {
      if(Hall != null)
      {
          bool isActive = Hall.activeSelf;
          Hall.SetActive(!isActive);
      }

    }

}
