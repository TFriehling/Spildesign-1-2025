using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject[] powerUpPrefabs = new GameObject[3];
    public GameObject powerUpObject;
    [SerializeField] List<GameObject> p1PowerUps = new List<GameObject>();
    [SerializeField] List<PowerUp> p2PowerUps = new List<PowerUp>();
    public List <float> p1powerUpTimers = new List<float>();
    public List<float> p2powerUpTimers = new List<float>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerUpObject = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {



        if (p1powerUpTimers.Count >= 1)
        {
            if (p1powerUpTimers[0] <= 0)
            {
                p1powerUpTimers.Remove(p1powerUpTimers[0]);
                p1PowerUps[0].GetComponent<SpeedBoost>().ResetOnP1();
                p1PowerUps.RemoveAt(0);
            }
        }
        if (p1powerUpTimers.Count >= 2)
        {
            if (p1powerUpTimers[1] <= 0)
            {
                p1powerUpTimers.Remove(p1powerUpTimers[1]);
                p1PowerUps[1].GetComponent<SpeedBoost>().ResetOnP1();
                p1PowerUps.RemoveAt(1);
            }
        }
        if (p1powerUpTimers.Count >= 3)
        { 
            if (p1powerUpTimers[2] <= 0)
            {
            p1powerUpTimers.Remove(p1powerUpTimers[2]);
            p1PowerUps[2].GetComponent<SpeedBoost>().ResetOnP1();
            p1PowerUps.RemoveAt(2);
             } 

        }

        //if (p2PowerUps.Count > 0)
        {
            //for (int i = 0; i < p2PowerUps.Count; i++)
            {
                //if (p2powerUpTimers[i] < 0)
                {
                    //p2powerUpTimers.Remove(p2powerUpTimers[i]);
                  
                    //p2PowerUps.RemoveAt(i + 1);

                  
                }
            }
        }

        for (int i = 0; i < p1powerUpTimers.Count; i++)
        {
            p1powerUpTimers[i] -= Time.deltaTime;

        }

        for (int i = 0; i < p2powerUpTimers.Count; i++)
        {
            p2powerUpTimers[i] -= Time.deltaTime;
        }
    }

    public void AddPowerUpToPlayer2(string pickUp)
    {
        if (pickUp == "SpeedBoost")
        {
            PowerUp compare = gameObject.AddComponent<SpeedBoost>();
            //for (int i = 0; i < p2PowerUps.Count; i++)
            {
                //if (p2PowerUps[i].Equals(compare))
                {
                    //p2PowerUps.Remove(p2PowerUps[i]);
                    //i = 0;
                }

            }
            PowerUp temp = gameObject.AddComponent<SpeedBoost>();
            SpeedBoost temp2 = gameObject.AddComponent<SpeedBoost>();
            p2powerUpTimers.Add(temp2.powerTime);
            p2PowerUps.Add(temp);
            
        }
        else if (pickUp == "Shield")
        {
            PowerUp compare = new Shield();
            //for (int i = 0; i < p2PowerUps.Count; i++)
            {
                //if (p2PowerUps[i].Equals(compare))
                {
                    //p2PowerUps.Remove(p2PowerUps[i]);
                    //i = 0;
                }

            }
            PowerUp temp = gameObject.AddComponent<Shield>();
            Shield temp2 = gameObject.AddComponent<Shield>();
            p2powerUpTimers.Add(temp2.powerTime);
            p2PowerUps.Add(temp);

        }
        else if (pickUp == "MultiShot")
        {
            PowerUp compare = new MultiShot();
            //for (int i = 0; i < p2PowerUps.Count; i++)
            {
                //if (p2PowerUps[i].Equals(compare))
                {
                    //p2PowerUps.Remove(p2PowerUps[i]);
                    //i = 0;
                }

            }
            PowerUp temp = gameObject.AddComponent<MultiShot>();
            MultiShot temp2 = gameObject.AddComponent<MultiShot>();
            p2powerUpTimers.Add(temp2.powerTime);
            p2PowerUps.Add(temp);
        }
    }

    public void AddPowerUpToPlayer1(string pickUp)
    {
        if (pickUp == "SpeedBoost")
        {
            //PowerUp compare = gameObject.AddComponent<SpeedBoost>();
            //for (int i = 0; i < p1PowerUps.Count; i++)
            {
                //if (p1PowerUps[i].Equals(compare))
                {
                    //p1PowerUps.Remove(p1PowerUps[i]);
                    //i = 0;
                }

            }
            GameObject tempObj = new GameObject();
            p1PowerUps.Add(tempObj);
            p1PowerUps[p1PowerUps.Count-1].AddComponent<SpeedBoost>();
            p1powerUpTimers.Add(p1PowerUps[p1PowerUps.Count-1].GetComponent<SpeedBoost>().powerTime);
           
        }
        else if (pickUp == "Shield")
        {
            PowerUp compare = new Shield();
            //for (int i = 0; i < p1PowerUps.Count; i++)
            {
                //if (p1PowerUps[i].Equals(compare))
                {
                    //p1PowerUps.Remove(p1PowerUps[i]);
                    //i = 0;
                }

            }
            PowerUp temp = gameObject.AddComponent<Shield>();
            Shield temp2 = gameObject.AddComponent<Shield>();
            p1powerUpTimers.Add(temp2.powerTime);
            //p1PowerUps.Add(temp);

        }
        else if (pickUp == "MultiShot")
        {
            PowerUp compare = new MultiShot();
            //for (int i = 0; i < p1PowerUps.Count; i++)
            {
                //if (p1PowerUps[i].Equals(compare))
                {
                    //p1PowerUps.Remove(p1PowerUps[i]);
                    //i = 0;
                }

            }
            PowerUp temp = gameObject.AddComponent<MultiShot>();
            MultiShot temp2 = gameObject.AddComponent<MultiShot>();
            p1powerUpTimers.Add(temp2.powerTime);
            //p1PowerUps.Add(temp);
        }
    }

    public void UseSinglePowerUpP1(int powerNumber)
    {
        if (p1PowerUps.Count > 0)
        {
            if (powerNumber == 0)
            {
                //p1PowerUps[p1PowerUps.Count - 1].UseOnP1();
            }
            else
            {
                //p1PowerUps[powerNumber-1].UseOnP1();
            }

        }
    }
    public void UseSinglePowerUpP2(int powerNumber)
    {
        if (p2PowerUps.Count > 0)
        {
            if (powerNumber == 0)
            {
                p2PowerUps[p2PowerUps.Count - 1].UseOnP2();
            }
            else
            {
                p2PowerUps[powerNumber - 1].UseOnP2();
            }

        }

    }

    public void UseAllPowerUpsP1()
    {
        for (int i = 0; i < p1PowerUps.Count; i++)
        {
            //p1PowerUps [i].UseOnP1();
        }

    }
    public void UseAllPowerUpsP2()
    {
        for (int i = 0; i < p2PowerUps.Count; i++)
        {
            p2PowerUps[i].UseOnP2();
        }

    }
}




abstract class PowerUp : MonoBehaviour
{
    
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
    public float powerTime;
    public bool isActive = false;

    public override void UseOnP1()
    {

    }
    public override void UseOnP2()
    {

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
    public float powerTime;
    public bool isActive = false;

    public override void UseOnP1()
    {

    }
    public override void UseOnP2()
    {

    }
    public override void ResetOnP1()
    {

    }
    public override void ResetOnP2()
    {

    }
}
