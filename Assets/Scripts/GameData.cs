using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;

public class GameData : MonoBehaviour {

    public delegate void LoadDataComplete();
    public static event LoadDataComplete OnLoadDataComplete;

    public TextAsset _GameData;
    public GameObject StorePrefab;
    public GameObject StorePanel;

    public void Start()
    {
        Invoke("LoadData", .1f);
        if (OnLoadDataComplete != null)
            OnLoadDataComplete();
    }

    public void LoadData()
    {
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.LoadXml(_GameData.text);

        XmlNodeList storeList = xmlDoc.GetElementsByTagName("store");

        foreach(XmlNode storeInfo in storeList)
        {
            
            GameObject NewStore = (GameObject)Instantiate(StorePrefab);

            store storeObj = NewStore.GetComponent<store>();


            XmlNodeList StoreNodes = storeInfo.ChildNodes;

            foreach (XmlNode StoreNode in StoreNodes)
            {

                if(StoreNode.Name == "name")
                {
                    

                    Text _NomeLoja = NewStore.transform.Find("txtNomeLoja").GetComponent<Text>();

                    _NomeLoja.text = StoreNode.InnerText;

                }
                
                if(StoreNode.Name =="image")
                {
                    Sprite newSprite = Resources.Load<Sprite>(StoreNode.InnerText);
                    Image _imgLoja = NewStore.transform.Find("ImageButtonClick").GetComponent<Image>();

                    _imgLoja.sprite = newSprite;
                }


                if (StoreNode.Name == "BaseStoreProfit")
                {
                    storeObj.baseStoreProfit = float.Parse(StoreNode.InnerText);
                }
                if (StoreNode.Name == "BaseStoreCost")
                {
                    storeObj.BaseStoreCost = float.Parse(StoreNode.InnerText);
                }
                if (StoreNode.Name == "StoreTimer")
                {
                    storeObj.SetStoreTimer(float.Parse(StoreNode.InnerText));
                }

                if (StoreNode.Name == "storeMultiplier")
                {
                    storeObj.storeMultiplier = float.Parse(StoreNode.InnerText);
                }
                if (StoreNode.Name == "StoreTimerDivision")
                {
                    storeObj.StoreTimerDivision = int.Parse(StoreNode.InnerText);
                }



            }
            NewStore.transform.SetParent(StorePanel.transform);

        }
    }
}
