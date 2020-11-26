using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassSensor : MonoBehaviour
{
     [SerializeField]
    Transform device;

    void Start () {
        Input.compass.enabled = true;
        Input.location.Start ();


        Debug.Log (string.Format("<b>精度</b>：{0}", Input.compass.headingAccuracy));
        Debug.Log (string.Format("<b>タイムスタンプ</b>：{0}", Input.compass.timestamp));

    }
    
    void Update () {
        Input.location.Start();
        Debug.Log (
            string.Format ("magneticHeading : {0}, rawVector : {1}, trueHeading : {2}",
                Input.compass.magneticHeading,
                Input.compass.rawVector,
                Input.compass.trueHeading
            )
        );

        // Transformの向きを真北にする
        device.rotation = Quaternion.Euler(new Vector3 (0, Input.compass.magneticHeading, 0));
    }
}
