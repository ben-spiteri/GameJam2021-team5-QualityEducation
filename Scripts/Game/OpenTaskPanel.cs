using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTaskPanel : MonoBehaviour
{
    public GameObject ClassBlock;
    public GameObject Canteen;
    public GameObject StaffRoom;
    public GameObject Gym;
    

    public bool open = false;

    public void OpenPanel_ClassBlock()
    {
        if(open == true)
        {
           GameObject.FindWithTag("PANEL").SetActive(false);

        }
        if(ClassBlock != null)
        {
            bool isActive = ClassBlock.activeSelf;
            ClassBlock.SetActive(!isActive);
            //open = true;
        }
    }
    public void OpenPanel_Canteen()
    {
        if(open == true)
        {
            GameObject.FindWithTag("PANEL").SetActive(false);

        }
        if(Canteen != null)
        {
            bool isActive = Canteen.activeSelf;
            Canteen.SetActive(!isActive);
        }
    }
    public void OpenPanel_Staff()
    {
        if(open == true)
        {
            GameObject.FindWithTag("PANEL").SetActive(false);

        }
        if(StaffRoom != null)
        {
            bool isActive = StaffRoom.activeSelf;
            StaffRoom.SetActive(!isActive);
            //open = true;
        }

    }
    public void OpenPanel_Gym()
    {
        if(open == true)
        {
            GameObject.FindWithTag("PANEL").SetActive(false);

        }
        if(Gym != null)
        {
            bool isActive = Gym.activeSelf;
            Gym.SetActive(!isActive);
            //open = true;
        }

    }

    public bool closeCheck = true;

    public void YesButtonCanteen()
    {   

        OpenPanel_Canteen();

    }

    public void YesButtonClass()
    {

        OpenPanel_ClassBlock();

    }

    public void YesButtonGym()
    {

        OpenPanel_Gym();

    }

    public void YesButtonStaff()
    {
        OpenPanel_Staff();
    }
}
