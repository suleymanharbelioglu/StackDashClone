using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DashEditor : EditorWindow
{
    public float _zValue;
    public int _count;
    public GameObject _parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [MenuItem("Window/Dash")]
    public static void ShowWindow()
    {
        GetWindow<DashEditor>("DashEditor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create From Selected Object",EditorStyles.boldLabel);
        GUILayout.Label("Z Value",EditorStyles.boldLabel);
        _zValue = EditorGUILayout.FloatField(_zValue);
        Debug.Log("Z Value :"+_zValue);
        GUILayout.Label("Count",EditorStyles.boldLabel);
        _count = EditorGUILayout.IntField(_count);
        _parent = GameObject.FindGameObjectWithTag("Parent");

        if(GUILayout.Button("Create"))
        {
            foreach(GameObject _obj in Selection.gameObjects)
            {
                for(int i = 0; i < _count; i++)
                {
                    GameObject g = Instantiate(_obj);
                    Vector3 _pos = _obj.transform.position;
                    _pos.z+= _zValue*(i+1);
                    g.transform.position = _pos;
                    g.transform.SetParent(_parent.transform);
                }
            }
        }
    }
}
