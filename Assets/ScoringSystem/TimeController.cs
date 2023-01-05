using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    public GameObject game_over_textholder;
    public Image timer_linear_image;
    float time_remaining;
    public float max_time = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        time_remaining = max_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            timer_linear_image.fillAmount = time_remaining / max_time;


        }

        else
        {
            game_over_textholder.SetActive(true);

        }
    }
}
