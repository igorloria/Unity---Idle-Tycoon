using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIStore : MonoBehaviour {

    public store Store;

    public Button btnComprar; //botão comprar de cada painel das lojas
    public Text txtContadorLoja; //TEXT onde mostra quantas lojas jogador possui
    public Text txtPrecoLoja; //TEXT onde possui o preço da loja
    public Slider ProgressSlider; // slider do tempo de cada profit


    void OnEnable()
    {
        gamemanager.OnUpdateSaldo += UpdateUI;
        GameData.OnLoadDataComplete += UpdateUI;
    }

    void OnDisable()
    {
        gamemanager.OnUpdateSaldo -= UpdateUI;
    }


    void Awake()
    {
        Store = transform.GetComponent<store>();
    }

    // Use this for initialization
    void Start () {
        txtContadorLoja.text = Store.storeCount.ToString();
        //Atualiza o valor da loja
        txtPrecoLoja.text = "Comprar " + Store.GetNextStoreCost().ToString("C2");

        UpdateUI();

    }
	
	// Update is called once per frame
	void Update () {
        ProgressSlider.value = Store.GetCurrentTimer() / Store.GetStoreTimer();
        
    }


    public void UpdateUI()
    {
        CanvasGroup cg = this.transform.GetComponent<CanvasGroup>();

        if (Store.storeUnlocked == false && gamemanager.instance.GetBalance() < Store.GetNextStoreCost())
        {


            cg.interactable = false;
            cg.alpha = 0;
        }
        else
        {

            cg.interactable = true;
            cg.alpha = 1;
            Store.storeUnlocked = true;

            if (gamemanager.instance.GetBalance() >= Store.GetNextStoreCost())
            {
                btnComprar.interactable = true;
            }
            else { btnComprar.interactable = false; }
        }

        
        
    }

    public void ComprarLojaOnClick()
    {
        Store.ComprarLoja();
        //Atualiza o valor da loja
        txtPrecoLoja.text = "Comprar " + Store.GetNextStoreCost().ToString("C2");
        txtContadorLoja.text = Store.storeCount.ToString();
    }

    public void OnTimerClick()
    {
        Store.OnStartTimer();
    }
}

