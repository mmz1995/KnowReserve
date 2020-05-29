using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKnowScript : MonoBehaviour {

    public Camera main_camera;
    public Transform tran_p0;
    public Transform tran_p1;
    public Transform tran_p2;

    public Transform target_3d;

    public Camera ui_camera;
    public Transform target_ui;

	// Use this for initialization
	void Start () {
        ChangeWorldPosToUIPos();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeWorldPosToUIPos();
        }
    }

    void ScreenFunc()
    {
        Vector3 screen_pos0 = main_camera.WorldToScreenPoint(tran_p0.position);
        Vector3 screen_pos1 = main_camera.WorldToScreenPoint(tran_p1.position);
        Vector3 screen_pos2 = main_camera.WorldToScreenPoint(tran_p2.position);
        Debug.Log(screen_pos0 + "______" + screen_pos1 + "______" + screen_pos2);
        Debug.Log(Screen.width + "++++++++" + Screen.height);
        Vector3 view_pos0 = main_camera.WorldToViewportPoint(tran_p0.position);
        Vector3 view_pos1 = main_camera.WorldToViewportPoint(tran_p1.position);
        Vector3 view_pos2 = main_camera.WorldToViewportPoint(tran_p2.position);
        Debug.Log(view_pos0 + "=====" + view_pos1 + "=====" + view_pos2);
    }

    void ChangeWorldPosToUIPos()
    {
        Vector3 screenPos = main_camera.WorldToScreenPoint(target_3d.position);
        Vector3 ui_worldPos = ui_camera.ScreenToWorldPoint(screenPos);
        target_ui.position = new Vector3(ui_worldPos.x, ui_worldPos.y, 100);
    }
}
