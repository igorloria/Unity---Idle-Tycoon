using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gamemanager : MonoBehaviour {


    public delegate void UpdateSaldo();
    public static event UpdateSaldo OnUpdateSaldo;

    public static gamemanager instance; //variavel para controlar o game maneger atraves do singleton

    float saldoTotal; //saldo do jogador CurrentBalance
    

    // Use this for initialization
    void Start () {
        saldoTotal = 5f;
        if (OnUpdateSaldo != null)
        {
            OnUpdateSaldo();
        }
        //UIManager.instance.UpdateUI();


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void AddToBalance(float valor)
    {
        saldoTotal += valor;
        if(OnUpdateSaldo != null)
        {
            OnUpdateSaldo();
        }
        //UIManager.instance.UpdateUI();
    }

    public float GetBalance()
    {
        return saldoTotal;
    }
}
