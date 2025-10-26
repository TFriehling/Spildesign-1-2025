using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject[] powerUpPrefabs = new GameObject[3];
    public GameObject powerUpObject;
    [SerializeField] List<GameObject> p1PowerUps = new List<GameObject>();
    [SerializeField] List<GameObject> p2PowerUps = new List<GameObject>();
    public List <float> p1powerUpTimers = new List<float>();
    public List<float> p2powerUpTimers = new List<float>();
    bool hasDeliveredOnce;
    [SerializeField] List<GameObject> objTestList = new List<GameObject>();
    GameObject compareObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUpObject = new GameObject();
        compareObj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject tempRef;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            UseSinglePowerUpP1(0);
        }

        if (p1powerUpTimers.Count >= 1)
        {
            //p1PowerUps[0].GetComponent<SpeedBoost>().isActive = true;
            if (p1powerUpTimers[0] <= 0)
            {
                p1powerUpTimers.Remove(p1powerUpTimers[0]);
                p1PowerUps[0].GetComponent<PowerUp>().ResetOnP1();
                tempRef = p1PowerUps[0];
                p1PowerUps.RemoveAt(0);
                Destroy(tempRef);
            }
        }
        if (p1powerUpTimers.Count >= 2)
        {
            if (p1powerUpTimers[1] <= 0)
            {
                p1powerUpTimers.Remove(p1powerUpTimers[1]);
                p1PowerUps[1].GetComponent<PowerUp>().ResetOnP1();
                tempRef = p1PowerUps[1];
                p1PowerUps.RemoveAt(1);
                Destroy(tempRef);
            }
        }
        if (p1powerUpTimers.Count >= 3)
        { 
            if (p1powerUpTimers[2] <= 0)
            {
            p1powerUpTimers.Remove(p1powerUpTimers[2]);
            p1PowerUps[2].GetComponent<PowerUp>().ResetOnP1();
                tempRef = p1PowerUps[2];
                p1PowerUps.RemoveAt(2);
                Destroy(tempRef);
            } 

        }

        if (p2powerUpTimers.Count >= 1)
        {
            if (p2powerUpTimers[0] <= 0)
            {
                p2powerUpTimers.Remove(p2powerUpTimers[0]);
                p2PowerUps[0].GetComponent<PowerUp>().ResetOnP2();
                p2PowerUps.RemoveAt(0);
            }
        }
        if (p2powerUpTimers.Count >= 2)
        {
            if (p2powerUpTimers[1] <= 0)
            {
                p2powerUpTimers.Remove(p2powerUpTimers[1]);
                p2PowerUps[1].GetComponent<PowerUp>().ResetOnP2();
                p2PowerUps.RemoveAt(1);
            }
        }
        if (p2powerUpTimers.Count >= 3)
        {
            if (p2powerUpTimers[2] <= 0)
            {
                p2powerUpTimers.Remove(p2powerUpTimers[2]);
                p2PowerUps[2].GetComponent<PowerUp>().ResetOnP2();
                p2PowerUps.RemoveAt(2);
            }

        }

        for (int i = 0; i < p1powerUpTimers.Count; i++)
        {
            if (p1PowerUps[i].GetComponent<PowerUp>().IsActive() == true)
            {
                p1powerUpTimers[i] -= Time.deltaTime;
            }

        }

        for (int i = 0; i < p2powerUpTimers.Count; i++)
        {
            if (p2PowerUps[i].GetComponent<PowerUp>().IsActive() == true)
            {
                p2powerUpTimers[i] -= Time.deltaTime;
            }
        }
    }


    public void DeliverAllPowerUpsToP1()
    {
        bool duplicateFound = false;
        for (int i = 0; i < p2PowerUps.Count; i++)
        {
            GameObject compareObj = p2PowerUps[i];
            for (int j = 0; j < p1PowerUps.Count; ++j)
            {
                if (p1PowerUps[i].Equals(compareObj))
                {
                    duplicateFound = true;
                }

            }
            if (duplicateFound == false && p2PowerUps[i].GetComponent<PowerUp>().IsActive() == false)
            {
                p1PowerUps.Add(p2PowerUps[i]);
                if (p2PowerUps[i].GetComponent<SpeedBoost>().powerTime % 1 >= 0)
                {
                    p1powerUpTimers.Add(p2PowerUps[i].GetComponent<SpeedBoost>().powerTime);
                }
                if (p2PowerUps[i].GetComponent<Shield>().powerTime % 1 >= 0)
                {
                    p1powerUpTimers.Add(p2PowerUps[i].GetComponent<Shield>().powerTime);
                }
                if (p2PowerUps[i].GetComponent<MultiShot>().powerTime % 1 >= 0)
                {
                    p1powerUpTimers.Add(p2PowerUps[i].GetComponent<MultiShot>().powerTime);
                }
                p2powerUpTimers.Remove(p2powerUpTimers[i]);
                p2PowerUps.Remove(p2PowerUps[i]);
            }
            duplicateFound = false;
        }
    }

    public void DeliverOnePowerUpToP1(int powerNumber)
    {
        bool duplicateFound = false;
        
         for (int i = 0; i < p1PowerUps.Count; i++)
         {

            
            compareObj = p2PowerUps[p2PowerUps.Count - powerNumber - 1];


            if (p1PowerUps[i].Equals(compareObj))
            {
                duplicateFound = true;
            }

         }
        
        if (duplicateFound == false && p2PowerUps[p2PowerUps.Count - powerNumber-1].GetComponent<PowerUp>().IsActive() == false)
        {
            
            p1PowerUps.Add(p2PowerUps[p2PowerUps.Count - powerNumber - 1]);
            

            if (p2PowerUps[p2PowerUps.Count - powerNumber - 1].GetComponent<SpeedBoost>().powerTime % 1 >= 0)
            {
                p1powerUpTimers.Add(p2PowerUps[p2PowerUps.Count - powerNumber - 1].GetComponent<SpeedBoost>().powerTime);
            }
            else if (p2PowerUps[p2PowerUps.Count - powerNumber - 1].GetComponent<Shield>().powerTime % 1 >= 0)
            {
                p1powerUpTimers.Add(p2PowerUps[p2PowerUps.Count - powerNumber - 1].GetComponent<Shield>().powerTime);
            }
            else if (p2PowerUps[p2PowerUps.Count - powerNumber - 1].GetComponent<MultiShot>().powerTime % 1 >= 0)
            {
            p1powerUpTimers.Add(p2PowerUps[p2PowerUps.Count - powerNumber - 1].GetComponent<MultiShot>().powerTime);
            }


            p2powerUpTimers.RemoveAt(p2powerUpTimers.Count - powerNumber -1);
            p2PowerUps.RemoveAt(p2PowerUps.Count - powerNumber - 1);
            
        }
        duplicateFound = false;
        hasDeliveredOnce = true;
    }

    public void AddPowerUpToPlayer2(string pickUp)
    {
        bool duplicateFound = false;
        if (p2PowerUps.Count < 3)
        {
            if (pickUp == "SpeedBoost")
            {
                GameObject compareObj = new GameObject();
                compareObj.AddComponent<SpeedBoost>();
                for (int i = 0; i < p2PowerUps.Count; i++)
                {
                    if (p2PowerUps[i].Equals(compareObj))
                    {
                        duplicateFound = true;
                    }

                }
                Destroy(compareObj);
                if (duplicateFound == false)
                {
                    GameObject tempObj = new GameObject();
                    tempObj.name = "SpeedBoost";
                    p2PowerUps.Add(tempObj);
                    p2PowerUps[p2PowerUps.Count - 1].AddComponent<SpeedBoost>();
                    p2powerUpTimers.Add(p2PowerUps[p2PowerUps.Count - 1].GetComponent<SpeedBoost>().powerTime);
                }

            }
            else if (pickUp == "Shield")
            {
                GameObject compareObj = new GameObject();
                compareObj.AddComponent<Shield>();
                for (int i = 0; i < p2PowerUps.Count; i++)
                {
                    if (p2PowerUps[i].Equals(compareObj))
                    {
                        duplicateFound = true;
                    }

                }
                Destroy(compareObj);
                if (duplicateFound == false)
                {
                    GameObject tempObj = new GameObject();
                    tempObj.name = "Shield";
                    p2PowerUps.Add(tempObj);
                    p2PowerUps[p2PowerUps.Count - 1].AddComponent<Shield>();
                    p2powerUpTimers.Add(p2PowerUps[p2PowerUps.Count - 1].GetComponent<Shield>().powerTime);
                }

            }
            else if (pickUp == "MultiShot")
            {
                GameObject compareObj = new GameObject();
                compareObj.AddComponent<MultiShot>();
                for (int i = 0; i < p2PowerUps.Count; i++)
                {
                    if (p2PowerUps[i].Equals(compareObj))
                    {
                        duplicateFound = true;
                    }

                }
                Destroy(compareObj);
                if (duplicateFound == false)
                {
                    GameObject tempObj = new GameObject();
                    tempObj.name = "MultiShot";
                    p2PowerUps.Add(tempObj);
                    p2PowerUps[p2PowerUps.Count - 1].AddComponent<MultiShot>();
                    p2powerUpTimers.Add(p2PowerUps[p2PowerUps.Count - 1].GetComponent<MultiShot>().powerTime);
                }

            }

            duplicateFound = false;

        }
    }

    public void AddPowerUpToPlayer1(string pickUp)
    {
        bool duplicateFound = false;
        if (p1PowerUps.Count < 3)
        {
            if (pickUp == "SpeedBoost")
            {
                GameObject compareObj = new GameObject();
                compareObj.AddComponent<SpeedBoost>();
                for (int i = 0; i < p1PowerUps.Count; i++)
                {
                    if (p1PowerUps[i].Equals(compareObj))
                    {
                        duplicateFound = true;
                    }

                }
                Destroy(compareObj);
                if (duplicateFound == false)
                {
                    GameObject tempObj = new GameObject();
                    tempObj.name = "SpeedBoost";
                    p1PowerUps.Add(tempObj);
                    p1PowerUps[p1PowerUps.Count - 1].AddComponent<SpeedBoost>();
                    p1powerUpTimers.Add(p1PowerUps[p1PowerUps.Count - 1].GetComponent<SpeedBoost>().powerTime);
                }

            }
            else if (pickUp == "Shield")
            {
                GameObject compareObj = new GameObject();
                compareObj.AddComponent<Shield>();
                for (int i = 0; i < p1PowerUps.Count; i++)
                {
                    if (p1PowerUps[i].Equals(compareObj))
                    {
                        duplicateFound = true;
                    }

                }
                Destroy(compareObj);
                if (duplicateFound == false)
                {
                    GameObject tempObj = new GameObject();
                    tempObj.name = "Shield";
                    p1PowerUps.Add(tempObj);
                    p1PowerUps[p1PowerUps.Count - 1].AddComponent<Shield>();
                    p1powerUpTimers.Add(p1PowerUps[p1PowerUps.Count - 1].GetComponent<Shield>().powerTime);
                }

            }
            else if (pickUp == "MultiShot")
            {
                GameObject compareObj = new GameObject();
                compareObj.AddComponent<MultiShot>();
                for (int i = 0; i < p1PowerUps.Count; i++)
                {
                    if (p1PowerUps[i].Equals(compareObj))
                    {
                        duplicateFound = true;
                    }

                }
                Destroy(compareObj);
                if (duplicateFound == false)
                {
                    GameObject tempObj = new GameObject();
                    tempObj.name = "MultiShot";
                    p1PowerUps.Add(tempObj);
                    p1PowerUps[p1PowerUps.Count - 1].AddComponent<MultiShot>();
                    p1powerUpTimers.Add(p1PowerUps[p1PowerUps.Count - 1].GetComponent<MultiShot>().powerTime);
                }

            }

            duplicateFound = false;
        }
    }

    public void UseSinglePowerUpP1(int powerNumber)
    {
        if (p1PowerUps.Count > 0)
        {
            if (powerNumber == 0 && p1PowerUps[p1PowerUps.Count - 1].GetComponent<PowerUp>().IsActive() == false)
            {
                p1PowerUps[p1PowerUps.Count - 1].GetComponent<PowerUp>().UseOnP1();
            }
            else if (p1PowerUps[p1PowerUps.Count - 1].GetComponent<PowerUp>().IsActive() == false)
            {
                p1PowerUps[powerNumber-1].GetComponent<PowerUp>().UseOnP1();
            }

        }
    }
    public void UseSinglePowerUpP2(int powerNumber)
    {
        if (p2PowerUps.Count > 0)
        {
            if (powerNumber == 0 && p2PowerUps[p2PowerUps.Count - 1].GetComponent<PowerUp>().IsActive() == false)
            {
                p2PowerUps[p2PowerUps.Count - 1].GetComponent<PowerUp>().UseOnP2();
            }
            else if (p2PowerUps[p2PowerUps.Count - 1].GetComponent<PowerUp>().IsActive() == false)
            {
                p2PowerUps[powerNumber - 1].GetComponent<PowerUp>().UseOnP2();
            }

        }

    }

    public void UseAllPowerUpsP1()
    {
        for (int i = 0; i < p1PowerUps.Count; i++)
        {
            if (p1PowerUps[i].GetComponent<PowerUp>().IsActive() == false)
            {
                p1PowerUps[i].GetComponent<PowerUp>().UseOnP1();
            }
        }

    }
    public void UseAllPowerUpsP2()
    {
        for (int i = 0; i < p2PowerUps.Count; i++)
        {
            if (p2PowerUps[i].GetComponent<PowerUp>().IsActive() == false)
            {
                p2PowerUps[i].GetComponent<PowerUp>().UseOnP2();
            }
        }

    }
}




abstract class PowerUp : MonoBehaviour
{
    public abstract bool IsActive();
    public abstract void UseOnP1();
    public abstract void ResetOnP1();
    public abstract void UseOnP2();
    public abstract void ResetOnP2();

}


class SpeedBoost : PowerUp
{
    
    public float maxSpeedBonus = 10;
    public float accelerationBonus = 5;
    public float powerTime = 10;
    public bool isActive = false;
    public override bool IsActive()
    {
        if (isActive == true)
        {
            return true;
        }
        else 
        { 
            return false; 
        
        }
    }
    public override void UseOnP1()
    {
        GameObject.Find("Player1").GetComponent<PlayerMovement>().maxSpeed += maxSpeedBonus;
        GameObject.Find("Player1").GetComponent<PlayerMovement>().acceleration += accelerationBonus;
        isActive = true;
    }
    public override void UseOnP2()
    {
        GameObject.Find("Player2").GetComponent<NormalPlayerMovement>().maxSpeed += maxSpeedBonus;
        GameObject.Find("Player2").GetComponent<NormalPlayerMovement>().acceleration += accelerationBonus;
        isActive = true;
    }
    public override void ResetOnP1()
    {
        GameObject.Find("Player1").GetComponent<PlayerMovement>().maxSpeed -= maxSpeedBonus;
        GameObject.Find("Player1").GetComponent<PlayerMovement>().acceleration -= accelerationBonus;
    }
    public override void ResetOnP2()
    {
        GameObject.Find("Player2").GetComponent<NormalPlayerMovement>().maxSpeed -= maxSpeedBonus;
        GameObject.Find("Player2").GetComponent<NormalPlayerMovement>().acceleration -= accelerationBonus;
    }

}

class Shield : PowerUp
{

    public string name = "Shield";
    public int shieldBonus = 2;
    public float powerTime = 20;
    public bool isActive = false;

    public override bool IsActive()
    {
        if (isActive == true)
        {
            return true;
        }
        else
        {
            return false;

        }
    }
    public override void UseOnP1()
    {
        isActive = true;
    }
    public override void UseOnP2()
    {
        isActive = true;
    }
    public override void ResetOnP1()
    {

    }
    public override void ResetOnP2()
    {

    }
}

class MultiShot : PowerUp
{
    public string name = "MultiShot";
    public int shots = 3;
    public float powerTime = 40;
    public bool isActive = false;

    public override bool IsActive()
    {
        if (isActive == true)
        {
            return true;
        }
        else
        {
            return false;

        }
    }
    public override void UseOnP1()
    {
        isActive = true;
    }
    public override void UseOnP2()
    {
        isActive = true;
    }
    public override void ResetOnP1()
    {

    }
    public override void ResetOnP2()
    {

    }
}
