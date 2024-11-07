using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishgame : MonoBehaviour
{
    public Animator playeranim;
        public bool isfishing;
        public bool poleback;
        public bool throwbobber;
        public Transform fishingpoint;
        public GameObject bobber;
        public GameObject originalfish;
        public GameObject[] setPosition;

        public float targetTime = 0.0f;
        public float savetargettime;
        public float extrabobberdistance;

        public GameObject Startfishgame;
        public GameObject pointFishbar;
        public GameObject zonefishing;
        public float timetillcatch = 0.0f;
        public bool winneranim;
        public bool inzone;
        Vector3 originalPos;

        // Start is called before the first frame update
        void Start()
        {
            isfishing = false;
            Startfishgame.SetActive(false);
            throwbobber = false;
            targetTime = 0.0f;
            savetargettime = 0.0f;
            extrabobberdistance = 0.0f;
            originalPos = new Vector3(-3.989f,-2.0877745f,4.42f);
            
   
        }

        // Update is called once per frame
        void Update()
        {
          if(GameObject.FindGameObjectWithTag("zonef"))
          {
            
            inzone = true;
                
            if(Input.GetKeyDown(KeyCode.Space) && isfishing == false && winneranim == false)
            {
                
                poleback = true;
                //Startfishgame.SetActive(true);
                //int randomNumber = Random.Range(0,setPosition.Length);
                //GameObject randomPositionObject = setPosition[randomNumber];
                //Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation); 
                
            }

            if(isfishing == true)
            {
                timetillcatch += Time.deltaTime;
                if(timetillcatch >= 3)
                {
                        poleback = false;
                        Startfishgame.SetActive(true);
                        //GameObject.FindGameObjectWithTag("fish").SetActive(true);
                        int randomNumber = Random.Range(0,setPosition.Length);
                        GameObject randomPositionObject = setPosition[randomNumber];
                        Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation);
                        timetillcatch = -10;
                        
                }

            }
            //if(isfishing == true)
           // {
             //   timetillcatch += Time.deltaTime;
              //  if(timetillcatch >= 2)
              //  {
                //    Startfishgame.SetActive(true);
               
              // }
           // }

           

            if(Input.GetKeyUp(KeyCode.Space) && isfishing == false && winneranim == false)
            {
                poleback = false;
                isfishing = true;
                throwbobber = true;
                if(targetTime >= 0)
                {
                    extrabobberdistance += 0;
                    
                    //int randomNumber = Random.Range(0,setPosition.Length);
                   // GameObject randomPositionObject = setPosition[randomNumber];
                   // Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation);
                }
                else
                {
                    extrabobberdistance += targetTime;
                    Destroy(GameObject.Find("Fish point(Clone)"));
                }
            }

            Vector3 temp = new Vector3(extrabobberdistance, 0, 0);
            fishingpoint.transform.position += temp;

            if(poleback == true)
            {
                playeranim.Play("playerSwingback");
                savetargettime = targetTime;
                targetTime += Time.deltaTime;
                Destroy(GameObject.Find("Fish point(Clone)"));

            }

            if(isfishing == true)
            {
                if(throwbobber == true)
                {
                    //Instantiate(bobber, fishingpoint.position, fishingpoint.rotation, transform);
                    fishingpoint.transform.position -= temp;
                    poleback = false;
                    throwbobber = false;
                    targetTime = 0.0f;
                    savetargettime = 0.0f;
                    extrabobberdistance = 0.0f;
                    //int randomNumber = Random.Range(0,setPosition.Length);
                    //GameObject randomPositionObject = setPosition[randomNumber];
                    //Instantiate(originalfish , randomPositionObject.transform.position, originalfish.transform.rotation);
                    //GameObject.Find("fish point(Clone)").SetActive(false);
                }
                playeranim.Play("playerfishing");
            }

            if(Input.GetKeyDown(KeyCode.P))
            {
                playeranim.Play("Idle_Animation");
                Startfishgame.SetActive(false);
                Destroy(GameObject.Find("Fish point(Clone)"));
                poleback = false;
                throwbobber = false;
                isfishing = false;
                timetillcatch = 0;
                //pointFishbar.transform.position = originalPos;
            }
          }
        }

        public void fishGameWon()
        {
            playeranim.Play("playerWonfish");
            Destroy(GameObject.Find("Fish point(Clone)"));
            Startfishgame.SetActive(false);
            poleback = false;
            throwbobber = false;
            isfishing = false;
            timetillcatch = 0;
        }

        public void fishGameLossed()
        {
            playeranim.Play("playerLostfish");
            Destroy(GameObject.Find("Fish point(Clone)"));
            Startfishgame.SetActive(false);
            poleback = false;
            throwbobber = false;
            isfishing = false;
            timetillcatch = 0;
            
        } 
}
