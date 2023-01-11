using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RotateDetectEnemy))]
public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        //RotateDetectEnemy brain = target as RotateDetectEnemy;

        //float rad = ((brain.lightAngle* 0.5f) - brain.transform.rotation.eulerAngles.z) * Mathf.Deg2Rad;
        //Vector3 angle = new Vector3(Mathf.Sin(rad), Mathf.Cos(rad), 0);

        //Handles.color = Color.white;
        //Handles.DrawWireDisc(brain.transform.position, Vector3.forward * -1f, brain.lightRadius);

        //Handles.color = new Color(1, 1, 1, 0.1f);
        //Handles.DrawSolidArc(brain.transform.position,
        //    Vector3.forward * 1f,
        //    angle,
        //    brain.lightAngle,
        //    brain.lightRadius);

        //GUIStyle style = new GUIStyle();
        //style.fontSize = 35;
        //Handles.Label(brain.transform.position + brain.transform.up * 2f, brain.lightAngle.ToString(), style);
    }
}
