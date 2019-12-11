using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaMine : MonoBehaviour
{

    private double height = 0;
    private string direction = "Up";
    public double upperlimit;
    public double lowerlimit;

    private Light Light1;
    private Light Light2;
    void Start()
    {
       Light1 = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Light>();
       Light2 = this.gameObject.transform.GetChild(1).gameObject.GetComponent<Light>();

       InvokeRepeating("ToggleLight", 1f, 1f);
    }

    void FixedUpdate()
    {
        if (height >= upperlimit)
        {
            direction = "Down";
        }
        if (height <= lowerlimit)
        {
            direction = "Up";
        }
        if (height < upperlimit && direction == "Up")
        {
            height += 0.01;
            this.transform.position = new Vector3(transform.position.x, (float)height, transform.position.z);
        }

        if (height > lowerlimit && direction == "Down")
        {
            height -= 0.01;
            this.transform.position = new Vector3(transform.position.x, (float)height, transform.position.z);
        }
    }

    void ToggleLight()
    {
        Light1.enabled = !Light1.enabled;
        Light2.enabled = !Light2.enabled;
    }
}
