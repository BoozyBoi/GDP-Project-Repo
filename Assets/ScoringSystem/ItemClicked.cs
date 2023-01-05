using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClicked : MonoBehaviour
{
    //public GameObject thingy;
    //SpriteRenderer sprite;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        //sprite = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

            //Debug.Log("Clicked");
            //Destroy(thingy);
            //sprite.color = new Color(1, 1, 1, 0);
            Color c = image.color;
            c.a = 0;
            image.color = c;
        }*/
    }

    public void Found()
    {
        Color c = image.color;
        c.a = 0;
        image.color = c;
    }
}
