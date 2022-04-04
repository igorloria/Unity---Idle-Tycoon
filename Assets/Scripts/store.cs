using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class store : MonoBehaviour
{


    public float BaseStoreCost; //custo inicial da loja
    public int storeCount; // contador de lojas
    public float baseStoreProfit; //quanto a loja dá de retorno
    float storeTimer;
    public float storeMultiplier;
    public bool storeUnlocked;
    public bool managerUnlocked;
    public int StoreTimerDivision;
    //public gamemanager _gameManager;


    float NextStoreCost;


    float currentTimer = 0;
    bool startTimer;


    // Use this for initialization
    void Start()
    {


        NextStoreCost = BaseStoreCost;


    }



    // Update is called once per frame
    void Update()
    {

        //if (!startTimer)
        //    startTimer = true;
        if (startTimer)
        {
            currentTimer += Time.deltaTime;

            if (currentTimer > storeTimer)
            {
                if (!managerUnlocked)
                    startTimer = false;

                gamemanager.instance.AddToBalance(baseStoreProfit * storeCount);
                currentTimer = 0;
            }
        }

    }

    public float GetCurrentTimer()
    {
        return currentTimer;
    }

    public float GetNextStoreCost()
    {
        return NextStoreCost;
    }

    public float GetStoreTimer()
    {
        return storeTimer;
    }

    public void SetStoreTimer(float _timer)
    {
        storeTimer = _timer;
    }

    public void ComprarLoja()
    {
        if (gamemanager.instance.GetBalance() >= NextStoreCost)
        {

            storeCount += 1;

            gamemanager.instance.AddToBalance(-NextStoreCost);
            NextStoreCost = (BaseStoreCost * Mathf.Pow(storeMultiplier, storeCount));

            if (storeCount % StoreTimerDivision == 0)
            {
                storeTimer = storeTimer / 1.5f;
            }
        }

    }

    public void OnStartTimer()
    {
        if (!startTimer && storeCount > 0)
            startTimer = true;
    }
}


