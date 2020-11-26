using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ChaseCamera : MonoBehaviour
{

   // private GUIStyle labelStyle;
   // Quaternion start_gyro;
    Quaternion gyro;


    private Vector3 m_accel;
    private Vector3 rot;



    void Start()
    {
       // Input.gyro.enabled = true;
    }

    void Update()
    {

        //  回転を制限
        //gameObject.transform.rotation =
        //  Quaternion.Euler(Input.gyro.rotationRateUnbiased.x, Input.gyro.rotationRateUnbiased.y, Input.gyro.rotationRateUnbiased.z);

        // ジャイロ
        //gyro = Input.gyro.attitude;
        //gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));
        //this.transform.localRotation = gyro;


        // 今ここ加速度センサ//
       // m_accel = Input.acceleration;

        //if (m_accel.x >= -0.01f && m_accel.x <= 0.0f)
        //{
        //    rot.y += 1f;
        //    this.transform.rotation = Quaternion.Euler(rot);
        //}

        //// 加速度センサ
        //float speed = 5.0f;

        //this.transform.rotation = Quaternion.Euler(m_accel);

        //this.transform.rotation = Quaternion.AngleAxis(m_accel.y, Vector3.forward) * Quaternion.AngleAxis(m_accel.x, Vector3.right);


        //var dir = Vector3.zero;
        //dir.x = Input.acceleration.x;
        //dir.y = Input.acceleration.y;

        //if (dir.sqrMagnitude > 1)
        //{
        //    dir.Normalize();
        //}

        //dir *= Time.deltaTime;

        //transform.Rotate(dir * speed);

        //   transform.Translate(0, 0, 0.08f);

    }


    //private void OnGUI()
    //{
    //    var rect = new Rect(200, 50, 500, 500);
    //    GUI.skin.label.fontSize = 50;
    //    GUI.Label(rect, string.Format("X={0:F2}, Y={1:F2}, Z={2:F2}",
    //        m_accel.x, m_accel.y, m_accel.z));
    //}

}
