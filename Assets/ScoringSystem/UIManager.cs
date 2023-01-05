using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LevelManager;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameObject findObjectIconHolder;
    [SerializeField]
    private GameObject findObjectIconPrefab;
    [SerializeField]
    private GameObject gamePanel;

    //private int totalObjects = 0;
    //add list stuff from levelManager

    private List<GameObject> findObjectIconList;
    public GameObject Gamepanel { get {return gamePanel;}}

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) Destroy(gameObject);

        findObjectIconList = new List<GameObject>();
    }

    public void AssignFindObjectIcon(List<FindObjectData> activeFindObjectList)
    {
        int k = 0;
        findObjectIconList.Clear();
        for (int i = 0; i < activeFindObjectList.Count; i++)
        {
            //aw heck no bruh i'mm dead
            /*findObjectIconList[i].findObject.name = "" + k; //ensure when any object is tapped,
                                                                 //object match the list
            findObjectIconList[i].makeSet = true;

            findObjectIconList.Add(icon);*/

            k++;
        }
    }



    /*public void PopulateFindObjectIcon(List<FindObjectData> activeFindObjectList)
    {
        findObjectIconList.Clear();
        for(int i = 0; i < activeFindObjectList.Count; i++)
        {
            GameObject icon = Instantiate(findObjectIconPrefab, findObjectIconHolder.transform);
            icon.name = activeFindObjectList[i].findObject.name;
            Image childImg = icon.transform.GetChild(0).GetComponent<Image>();
            Text childText = icon.transform.GetChild(1).GetComponent<Text>();

            childImg.sprite = activeFindObjectList[i].findObject.GetComponent<Sprite>();
            childText.text = activeFindObjectList[i].name;

            findObjectIconList.Add(icon);

        }
    }*/

    public void CheckSelectedFindObject(string objectName)
    {
        for (int i = 0; i < findObjectIconList.Count; i++)
        {
            if (findObjectIconList[i].name == objectName)
            {
                findObjectIconList[i].SetActive(false);
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
