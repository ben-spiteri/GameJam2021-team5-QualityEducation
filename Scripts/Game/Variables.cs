using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Variables : MonoBehaviour
{
    public int month;

    public float sdi;//studnt development index -- the main index that we will use to measure the efficiency of our player

    public float budget, reserve, //The value of the budget granted at the start of each iteration, the reserve is the ammount left over after the budget is allocated
    studMoral, tMoral, sportMetric, educMetric; //the 4 main metrics that determine the Student Development Index

    public float TgymBud, TclassesBud, TstaffBud, TcanteenBud;//the total budget being spend on these resources throughout the game
    public float gymBud, classesBud, staffBud, canteenBud; //Variables that determines the ammount of money spent by the user on that resource. 

    public int gymLevel, clsLevel, stfrLevel, cntLevel;//The level of the physical structurs of the environment of our school
    public float gymProg, clsProg, stfrProg, cntProg;
    


    public void init_vars(){

        month = 1;

        budget = 50000f;//setting initial budget value
        reserve = 0f;//setting initial reserve to zero
        studMoral = tMoral = sportMetric = educMetric = 25f;//setting the 4 main metrics to 25%
        
        gymBud = classesBud = staffBud = canteenBud = 0f;
        TgymBud = TclassesBud = TstaffBud = TcanteenBud = 0f;


        gymLevel = clsLevel = stfrLevel = cntLevel = 1; //initializing building level to 1
        gymProg = clsProg = stfrProg = cntProg = 0f;

        sdi = _sdi_(studMoral, tMoral, sportMetric, educMetric); //getting an inital sdi

    }

    public void start_Game(float gym, float classes, float staff, float canteen){
        
        upgradeGym();
        upgradeClass();
        upgradeStaffRoom();
        upgradeCanteen();
        
        sdi = _sdi_(studMoral, tMoral, sportMetric, educMetric); //getting an inital sdi
        
        gymBud = gym;
        classesBud = classes;
        staffBud = staff;
        canteenBud = canteen;

        update_variables();
        CheckBudget();

    }

    public void update_variables(){
        upgradeGym();
        upgradeClass();
        upgradeStaffRoom();
        upgradeCanteen();

        sdi = _sdi_(studMoral, tMoral, sportMetric, educMetric); //getting an inital sdi

        CalcBudget(sdi);
    }


    public int getBase(int level){
        switch(level){
            case 1: return 2;
            break;

            case 2: return 3;
            break;

            case 3: return 4;
            break; 

            case 4: return 5;
            break;

            default: return 0;
            break;
        }
    }

    public List<GameObject> classblock = new List<GameObject>();
    public List<GameObject> gymblock = new List<GameObject>();
    public List<GameObject> canteenblock = new List<GameObject>();
    public List<GameObject> staffblock = new List<GameObject>();
    
    public void upgradeGym(){
        TgymBud = TgymBud + gymBud;

        if(TgymBud < 25000){
            gymLevel = 1;

            gymblock[0].SetActive(true);       
            gymblock[1].SetActive(false);
            gymblock[2].SetActive(false);
            gymblock[3].SetActive(false);

        }
        else if(TgymBud >= 25000 && TgymBud <68000){
            gymLevel = 2;

            gymblock[0].SetActive(false);       
            gymblock[1].SetActive(true);
            gymblock[2].SetActive(false);
            gymblock[3].SetActive(false);
        }
        else if(TgymBud >= 68000 && TgymBud <100000){
            gymLevel = 3;

            gymblock[0].SetActive(false);       
            gymblock[1].SetActive(false);
            gymblock[2].SetActive(true);
            gymblock[3].SetActive(false);
        }
        else if(TgymBud >= 100000){
            gymLevel = 4;

            gymblock[0].SetActive(false);       
            gymblock[1].SetActive(false);
            gymblock[2].SetActive(false);
            gymblock[3].SetActive(true);
        }
    }

    public void upgradeClass(){
        TclassesBud = TclassesBud + classesBud;

        if(TclassesBud < 25000){
            clsLevel = 1;

            classblock[0].SetActive(true);       
            classblock[1].SetActive(false);
            classblock[2].SetActive(false);
            classblock[3].SetActive(false);
        }
        else if(TclassesBud >= 25000 && TclassesBud <68000){
            clsLevel = 2;

            classblock[0].SetActive(false);       
            classblock[1].SetActive(true);
            classblock[2].SetActive(false);
            classblock[3].SetActive(false);
        }
        else if(TclassesBud >= 68000 && TclassesBud <100000){
            clsLevel = 3;

            classblock[0].SetActive(false);       
            classblock[1].SetActive(false);
            classblock[2].SetActive(true);
            classblock[3].SetActive(false);
        }
        else if(TclassesBud >= 100000){
            clsLevel = 4;

            classblock[0].SetActive(false);
            classblock[1].SetActive(false);
            classblock[2].SetActive(false);
            classblock[3].SetActive(true);
        }
    }


    public void upgradeStaffRoom(){
        TstaffBud = TstaffBud + staffBud;

        if(TstaffBud < 25000){
            stfrLevel = 1;

            staffblock[0].SetActive(true);       
            staffblock[1].SetActive(false);
            staffblock[2].SetActive(false);
            staffblock[3].SetActive(false);
        }
        else if(TstaffBud >= 25000 && TstaffBud <68000){
            stfrLevel = 2;

            staffblock[0].SetActive(false);       
            staffblock[1].SetActive(true);
            staffblock[2].SetActive(false);
            staffblock[3].SetActive(false);
        }
        else if(TstaffBud >= 68000 && TstaffBud <100000){
            stfrLevel = 3;

            staffblock[0].SetActive(false);       
            staffblock[1].SetActive(false);
            staffblock[2].SetActive(true);
            staffblock[3].SetActive(false);
        }
        else if(TstaffBud >= 100000){
            stfrLevel = 4;

            staffblock[0].SetActive(false);       
            staffblock[1].SetActive(false);
            staffblock[2].SetActive(false);
            staffblock[3].SetActive(true);
        }
    }


    public void upgradeCanteen(){
        TcanteenBud = TcanteenBud + canteenBud;

        if(TcanteenBud < 25000){
            cntLevel = 1;

            canteenblock[0].SetActive(true);       
            canteenblock[1].SetActive(false);
            canteenblock[2].SetActive(false);
            canteenblock[3].SetActive(false);
        }
        else if(TcanteenBud >= 25000 && TcanteenBud <68000){
            cntLevel = 2;

            canteenblock[0].SetActive(false);       
            canteenblock[1].SetActive(true);
            canteenblock[2].SetActive(false);
            canteenblock[3].SetActive(false);

            
        }
        else if(TcanteenBud >= 68000 && TcanteenBud <100000){
            cntLevel = 3;

            canteenblock[0].SetActive(false);       
            canteenblock[1].SetActive(false);
            canteenblock[2].SetActive(true);
            canteenblock[3].SetActive(false);
        }
        else if(TcanteenBud >= 100000){
            cntLevel = 4;

            canteenblock[0].SetActive(false);       
            canteenblock[1].SetActive(false);
            canteenblock[2].SetActive(true);
            canteenblock[3].SetActive(false);
        }
    }



    //function to calculate the student development index
    public float _sdi_(float sMoral, float tMoral, float educMetric, float sportMetric){
        
        float total = sMoral + tMoral + sportMetric + educMetric;//getting total of all 4 metrics

        if (total < 400 && total > 0){
            total = total/4;
            if (total <= 100)
            {
                return total;
            }
            else { return 100; }
            
        }
        else {
            Debug.Log("SDI larger than 400");
            return -1;
        }
    }



    public float CalcBudget(float sdi) {
        if (sdi > 0 && sdi <= 22) {
            budget = 35000f;


        } else if (sdi > 22 && sdi <= 26)
        {
            budget = 60000f;


        } else if (sdi > 26 && sdi <= 30) {
            budget = 85000f;

        } else if (sdi > 30 && sdi <= 35) {
            budget = 100000f;


        } else if (sdi > 35 && sdi <= 50) {
            budget = 115000f;
        
        }
        else if (sdi > 50){
            budget = 10000000000000f;
        }
        return budget;  
    }


    public void Start()
    {
        init_vars();
        
        Debug.Log(sdi);
        CheckBudget();
    }

    ////////////////////////////////////////////////////////////////

    public void CheckBudget() {//calculating the percentage of the budget spent on the given resource
        
        float gymPerc = ((gymBud/budget) * 100);
        float classesPerc = ((classesBud/budget)*100);
        float staffPerc = ((staffBud/budget)*100);
        float canteenPerc = ((canteenBud/budget)*100);
        

        //calling function to send the monthly updates to the player
        gym_update(fuzzy(gymPerc));
        staff_update(fuzzy(staffPerc));
        canteen_update(fuzzy(canteenPerc));
        class_update(fuzzy(classesPerc));

    }



    //function to determine if the outcome throught the stage of the game will be positive or negative using a form of Fuzzy logic
    public bool fuzzy(float var){
        bool updateType;
        int rand;

        if(var < 10){
            
            rand = Random.Range(1, 10);
            if (rand == 1){
                updateType = true;//true implies that the outcome will be positive
            }else updateType = false;//false implies that the outcome will be negative

        }
        else if(var >=10 & var < 20){

            rand = Random.Range(1, 10);
            if (rand <= 2){
                updateType = true;
            }else updateType = false;
            
            
        }
        else if(var >=20 & var < 30){

            rand = Random.Range(1, 10);
            if (rand <= 3){
                updateType = true;
            }else updateType = false;
            

        }
        else if(var >=30 & var < 40){

            rand = Random.Range(1, 10);
            if (rand <= 4){
                updateType = true;
            }else updateType = false;
            

        }
        else if(var >=40 & var < 50){

            rand = Random.Range(1, 10);
            if (rand <= 5){
                updateType = true;
            }else updateType = false;
            
        }
        else if(var >=50 & var < 95){

            rand = Random.Range(1, 10);
            if (rand <= 6){
                updateType = true;
            }else updateType = false;
            
        }
        else{
            updateType = true;
        }

        return updateType;
    }
    

    ////////////////////////////////////////////////////////////////////////////////////////////////



    
    public Text gymTXT;
    public Text staffTXT;
    public Text canteenTXT;
    public Text classesTXT;



    void gym_update(bool effect){

        int rand;
        /*int priceRandom;
        priceRandom = Random.Range(20, 80);
        float taskPrice = reserve * priceRandom / 100;*/

        int taskPrice = 10;

        if(effect){//positive

            rand = Random.Range(1, 5);

            switch(rand){
                case 1: 
                    string myString = "An opportunity has arisen to send the Basketball team to compete at a local championship. Even participating will earn a great deal of fame for your school, however, transport costs and accommodation is not included. This will have to come from the school funds, and will cost you. Will you send the team, or can these funds be better used elsewhere?";
                    gymTXT.text = myString;
                    break;
                
                case 2: 
                    string myString2 = "You see an opportunity to upgrade the equipment. This will not come cheap, but the prices are more then worthwhile. Will you make the purchase?";
                    gymTXT.text = myString2;
                    break;
                
                case 3: 
                    string myString3 = "An opportunity has arisen! You can hire better staff to help the sports team out. Such an opportunity may be worth the investment. ";
                    gymTXT.text = myString3;
                    break;
                
                case 4:
                    string myString4 = "You have the chance to bring a well-known athlete to speak to the students. Such a talk may inspire them further, to push harder in their studies no matter the topic. Will you take this opportunity?";
                     gymTXT.text = myString4;
                     break;
                
                case 5: 
                    string myString5 = "The students can be sent to a training camp over the weekend. It will be a costly, but overall rewarding experience. However, the final choice lies in your hands.";
                    gymTXT.text = myString5;
                    break;
                
                default: break;
            }

            sportMetric = sportMetric + getBase(gymLevel);
            educMetric = educMetric - (getBase(gymLevel)/4);
            studMoral = studMoral + (getBase(clsLevel)/4);
            
            
        }
        else{//negative

          rand = Random.Range(1, 4);


          switch(rand){
              case 1: gymTXT.text = (string) "A student has injured him/herself while participating in a sporting event. This has resulted in calls being made regarding the safety standards present in the gym. Upgrading is possible, but will cost quite a sum. Would you like to take this action?";
                    break;
              case 2: gymTXT.text = (string) "During training, some of the equipment was broken. Repairing this is a rather costly endeavor, however, and arguments have been made that the equipment broken is minor, and activities can still carry on as usual, albeit at a loss of quality. Will you choose to run the repairs?";
                    break;
              case 3: gymTXT.text = (string) "Complaints have been made by the student board, stating that the gym classes are being neglected. They are complaining that there is a lack of proper faculties, and that the school board does not care about them. You can address this fear by upgrading the existing faculties, however, this will take funds which might be better spent elsewhere.";
                    break;
              case 4: gymTXT.text = (string) "One of the Coaches has quit. A replacement must be hired; however, the recruitment process will cost you. Will you pay? ";
                    break;
              default: break;

          }
            
            sportMetric = sportMetric - getBase(gymLevel);
            educMetric = educMetric + (getBase(gymLevel)/4);
            studMoral = studMoral - (getBase(clsLevel)/4);         
        }

        Debug.Log("Price:" + taskPrice);
        //When yes is clicked, Reserve - taskPrice, else just close task window. 
    }

    
    
    void staff_update(bool effect){
        int rand;
        /*int priceRandom;
        priceRandom = Random.Range(20, 80);
        float taskPrice = reserve * priceRandom / 100;*/

        int taskPrice = 100;

        if(effect){
          rand = Random.Range(1, 4);
          switch(rand)
          {
            case 1: staffTXT.text = (string) "A staff party would greatly raise moral among staff members. However, it can also be regarded as an unneeded expense. The choice on how to proceed is yours.";
            break;

            case 2: staffTXT.text = (string) "Purchasing new furniture for the staff rooms would help in keeping up moral, and you have managed to find some for cheap. Will you make the purchase, or will you save the funds for possibly more urgent needs around the school?";
            break;

            case 3: staffTXT.text = (string) "The staff have worked hard, and showing your appreciation in monetary value may encourage them to work harder. Giving a bonus to the staff could go a long way, but do make sure it’s a worthwhile investment first.";
            break;

            case 4: staffTXT.text = (string) "Some staff members have commented that it would be greatly appreciated if the kitchen. Yet, such an endeavor is costly, and there may be better uses for your limited funds.  ";
            break;

            default: break;

          }

            tMoral = tMoral + getBase(gymLevel);
            educMetric = educMetric + (getBase(gymLevel)/4);
            studMoral = studMoral + (getBase(clsLevel)/4);

        }
        else{
          rand = Random.Range(1, 4);
            switch(rand)
            {
              case 1: staffTXT.text = (string) "Certain faculties within the staff building have broken down. While this is of no great value, it is causing some minor dissatisfaction. You can address this issue, but is it worth it?";
              break;

              case 2: staffTXT.text = (string) "A staff member has quit, and a replacement must be found. You have the opportunity to hire a replacement immediately, however, they are demanding a sum of money up front. Would it be best to pay now, or wait?";
              break;

              case 3: staffTXT.text = (string) "Staff members are dissatisfied with recent conditions, and are planning a strike. This could be prevented; however, it will cost you. What will you choose?";
              break;

              case 4: staffTXT.text = (string) "The Staff room has recently incurred some damage, and while it is not urgent, it is affecting moral negatively. You can fix it immediately, however this will cost quite a bit. The choice is yours.";
              break;

              default: break;
            }
            
            tMoral = tMoral - getBase(clsLevel);
            educMetric = educMetric - (getBase(clsLevel)/4);
            studMoral = studMoral - (getBase(clsLevel)/4);
        }

        Debug.Log("Price:" + taskPrice);
        //When yes is clicked, Reserve - taskPrice, else just close task window.
    }


    void canteen_update(bool effect){
        int rand;
        int taskPrice = 1000;

        if(effect){
          rand = Random.Range(1, 4);
          switch(rand)
          {
            case 1: canteenTXT.text = (string) "Recent researches into modern eating habits have led you to believe that more and more students would be interested in a healthier menu at the canteen. You have the option to invest in it, but will you spare the funds?";
            break;

            case 2: canteenTXT.text = (string)"Giving a discount could raise moral, and overall have a positive effect on the student body. Yet, the money gap will have to come out of the school’s pocket. Will you provide the funds for this? ";
            break;

            case 3: canteenTXT.text = (string)"Better Chefs can go a long way in improving the canteen experience, and yet, they’ll not be cheap to hire. Will you see this as a worthwhile investment?";
            break;

            case 4: canteenTXT.text = (string)"A unique opportunity has arisen. You have found a few Billiard tables being sold at cheap. They would make a great addition to the canteen, and are sure to be well liked by students. The question is, will you secure their purchase?";
            break;

            default: break;
          }

          studMoral = studMoral + getBase(cntLevel);
          sportMetric = sportMetric + (getBase(cntLevel)/4);
          tMoral = tMoral + (getBase(cntLevel)/4);
        }
        else{
          rand = Random.Range(1, 5);
          switch (rand) {
            case 1: canteenTXT.text = (string)"A couple of students have reported feeling unwell after eating food from the canteen. This could be cause for further investigation, but even attempting this will consume precious funds. Will you investigate anyway?";
            break;

            case 2: canteenTXT.text = (string)"Many tables in the canteen are chipped or even outright broken, and this has led to a lot of student complaints. Addressing these is possible, but it’ll siphon funds which could be used to achieve other tasks. Do you judge this to be of enough importance to invest in? ";
            break;

            case 3: canteenTXT.text = (string)"The conditions of the kitchen proper are appalling. Quite honestly, preparing food in them should be unacceptable, and it’s only a matter of time till an accident occurs. This issue should probably be addressed immediately, but it’ll take a bite out of your savings.";
            break;

            case 4: canteenTXT.text = (string)"Some of the more unruly students caused damage to the building proper, breaking windows and the like. This behavior, of course, was not tolerated, and the perpetrators were immediately punished. Yet the damage remains. Fixing it as soon as possible might be beneficial to student moral. What shall you do?";
            break;

            case 5: canteenTXT.text = (string)"A student had an allergic reaction to one of the items on the menu. The student’s parents are greatly upset with you, as well as the school in general. Would it not be wise to pay to revise your menu, to prevent this from happening in the future, despite the costs? ";
            break;

            default: break;

          }
          
          studMoral = studMoral - getBase(cntLevel);
          sportMetric = sportMetric - (getBase(cntLevel)/4);
          tMoral = tMoral - (getBase(cntLevel)/4);
        }

        Debug.Log("Price:" + taskPrice);
        //When yes is clicked, Reserve - taskPrice, else just close task window.
    }


    void class_update(bool effect){
      int rand;

        /*
        int priceRandom;
        priceRandom = Random.Range(20, 80);
        float taskPrice = reserve * priceRandom / 100;*/

        int taskPrice = 10000;

        if(effect){
          rand = Random.Range(1, 4);
          switch (rand) {
            case 1:classesTXT.text = (string) "You have the opportunity to update the lab equipment. Doing so will greatly increase the experience for the students, but cost quite a bit.";
            break;

            case 2: classesTXT.text = (string) "You have the opportunity to update the lab equipment. Doing so will greatly increase the experience for the students, but cost quite a bit.";
            break;

            case 3: classesTXT.text = (string) "Taking the classes on an outing could help raise moral, and provide new learning experiences, but will also cost quite a bit from the school side. ";
            break;

            case 4: classesTXT.text = (string) "You managed to secure an opportunity for a well-known speaker to give a talk at your school. Yet, this will not come cheap, and it’s up to you to decide if it will be a worthwhile investment.";
            break;

            default: break;

          }

          educMetric = educMetric + getBase(clsLevel);
          sportMetric = sportMetric - (getBase(clsLevel)/4);
          tMoral = tMoral + (getBase(clsLevel)/4);

        }
        else{
          rand = Random.Range(1, 5);
          switch (rand) {
            case 1: classesTXT.text = (string) "Lab equipment was damaged, yet you can choose to repair it rather quickly. This, however, will cost quite a bit more than usual.";
            break;

            case 2: classesTXT.text = (string) "Some students have, rather disrespectfully, vandalized some classes. Cleaning this comes at quite the cost, but to learn in such a rundown environment is hardly productive.";
            break;

            case 3: classesTXT.text = (string) "Certain student faculties are outdated. They are still functional, but they’re hardly efficient, nor do they truly give the full educational experience. It ought to be possible to upgrade them, but they’ll cost quite a bit.";
            break;

            case 4: classesTXT.text = (string) "Some classrooms have been described as rather dark and gloomy. Recent studies suggest that this is counterproductive to the educational process. In order to right this, certain, costly, measures must be taken. Will you take this choice?";
            break;

            case 5: classesTXT.text = (string) "Students are suffering under the workload, to the point where their grades are dropping. It might be time to restructure some lessons. Yet this will come at quite the cost to the school. The decision is yours. ";
            break;

            default:
              break;

          }
          
          educMetric = educMetric + getBase(clsLevel);
          sportMetric = sportMetric - (getBase(clsLevel)/4);
          tMoral = tMoral + (getBase(clsLevel)/4);
        }

    }


    ////////////////////////////////////////////////////////////////

    public GameObject gamePanel;
    public GameObject backpanel;
    public GameObject txbPanel;
    public GameObject endPanel;
    public Buttons yescheck;
    

    //function to clean the playing space and set up the game for the next 'iteration'
    public void cleanUp(){
        month = month + 1;
        if(month <= 9)
        {
            sdi = _sdi_(studMoral, tMoral, sportMetric, educMetric);
        CalcBudget(sdi);
        reserve = 0;

        gymBud = classesBud = staffBud = canteenBud = 0f;

        yescheck.check = 3;
        

        txbPanel.SetActive(false);
        backpanel.SetActive(true);
        }
        else
        {
            endPanel.SetActive(true);
            gamePanel.SetActive(false);
            
        }
    }
}

