using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateScale : MonoBehaviour {

    public Transform cameraTran;

    public Transform zero_tran;
    public Transform can_zhao;
    public Transform can_zhao1;
    public Transform target;

    float origin_dis = 0f;
	// Use this for initialization
	void Start () {
        origin_dis = Mathf.Abs(can_zhao.position.z - cameraTran.position.z);

        DebugLine();
	}

    float new_dis = 0f;
    float new_scale = 1f;
    Vector3 scaleV3 = new Vector3();
	// Update is called once per frame
	void Update () {
        //new_dis = Mathf.Abs(target.position.z - cameraTran.position.z);
        //new_scale = new_dis / origin_dis;
        //scaleV3.Set(new_scale, new_scale, new_scale);
        //target.localScale = scaleV3;

    }

    void DebugLine()
    {
        Debug.DrawLine(Vector3.zero, can_zhao.position, Color.red);
        Debug.DrawLine(Vector3.zero, can_zhao1.position, Color.blue);

        Quaternion quaternion = Quaternion.identity;

        quaternion.SetFromToRotation(can_zhao.position, can_zhao1.position);
        target.rotation = quaternion;
    }
}
