using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField]
    private List<FindObjectData> findObjectsList;
   
    private List<FindObjectData> activeObjectsList;

    //public List<FindObjectData> foundObjectsList;
    [SerializeField]
    private int maxActiveFindObjectCount;

    private int totalObjectsFound = 0;

    //help
    //public ItemClicked foundItem;
    //public UIManager outtaHere;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance == null) Destroy(gameObject);
    }

    //Objects are active so can tap on them
    void AssignHiddenObjects()
    {
        totalObjectsFound = 0;
        activeObjectsList.Clear();
        for (int i = 0; i < findObjectsList.Count; i++)
        {
            findObjectsList[i].findObject.GetComponent<Collider2D>().enabled = false;
        }

        //Select some objects to be active
        int k = 0;
        while (k < maxActiveFindObjectCount)
        {
            int randomVal = Random.Range(0, findObjectsList.Count);
            if (!findObjectsList[randomVal].makeSet)
            {
                findObjectsList[randomVal].findObject.name = "" + k; //ensure when any object is tapped,
                                                                     //object match the list
                findObjectsList[randomVal].makeSet = true;
                //findObjectsList[randomVal].findObject.name = "" + k;
                findObjectsList[randomVal].findObject.GetComponent<Collider2D>().enabled = true;

                /*foundObjectsList[randomVal].findObject.name = "" + k; //ensure when any object is tapped,
                                                                      //object match the list
                foundObjectsList[randomVal].makeSet = true;*/

                activeObjectsList.Add(findObjectsList[randomVal]);
                //activeObjectsList.Add(foundObjectsList[randomVal]); 

                k++; 
                

            }
        }

        /*while (k < maxActiveFindObjectCount)
        {
            int randomVal = Random.Range(0, foundObjectsList.Count);
            if (!foundObjectsList[randomVal].makeSet)
            {
                foundObjectsList[randomVal].findObject.name = "" + k; //ensure when any object is tapped,
                                                                     //object match the list
                foundObjectsList[randomVal].makeSet = true;

                activeObjectsList.Add(foundObjectsList[randomVal]);

                k++;

            }
        }*/

        /*UIManager.instance.PopulateFindObjectIcon(activeObjectsList);*/
        //ItemClicked.instance.PopulateFindObjectIcon(activeObjectsList);
    }

    
                 

    [System.Serializable]
    public class FindObjectData
    {
        public string name;
        public GameObject findObject;
        public bool makeSet = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        activeObjectsList = new List<FindObjectData> ();
        AssignHiddenObjects();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0))  //click on object
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

            if(hit && hit.collider != null)
            {
                //Debug.Log("Object Name:" + hit.collider.gameObject.name);

                hit.collider.gameObject.SetActive(false);
                UIManager.instance.CheckSelectedFindObject(hit.collider.gameObject.name);

                for(int i = 0; i<activeObjectsList.Count; i++)
                {
                    if(activeObjectsList[i].findObject.name == hit.collider.gameObject.name)
                    {
                        activeObjectsList.RemoveAt(i);
                        //outtaHere.CheckSelectedFindObject(name);
                        //foundItem.Found();
                        break;
                    }
                }

                totalObjectsFound++;
                ScoreManager.instance.AddPoint();


                if (totalObjectsFound >= maxActiveFindObjectCount)
                {
                    Debug.Log("Level Complete");
                    UIManager.instance.Gamepanel.SetActive(true);
                }
            }
        }
    }
}
