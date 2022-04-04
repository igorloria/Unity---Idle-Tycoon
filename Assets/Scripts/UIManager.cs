using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    //public static UIManager instance;
    public Text txtSaldoTotal; //TEXT onde mostra o saldo do jogador

    // Use this for initialization
    void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        gamemanager.OnUpdateSaldo += UpdateUI;
    }

    void OnDisable()
    {
        gamemanager.OnUpdateSaldo -= UpdateUI;
    }

    //void Awake()
    //{
    //    if(instance==null)
    //    {
    //        instance = this;
    //    }
    //}

    public void UpdateUI()
    {
        txtSaldoTotal.text = gamemanager.instance.GetBalance().ToString("C2");

    }
}
