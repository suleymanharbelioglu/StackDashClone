using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance{set; get;}
    void Awake()
    {
        Instance = this;
    }
    Rigidbody _rb;
    public float _speed;
    public bool _isMoving = false;

    public GameObject _dashesParent;
    public GameObject _prevDash;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || MobileInputScript.Instance._swipeLeft && !_isMoving)
        {
            _isMoving = true;
            _rb.velocity = Vector3.left * _speed * Time.deltaTime;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) || MobileInputScript.Instance._swipeRight && !_isMoving)
        {
            _isMoving = true;
            _rb.velocity = Vector3.right * _speed * Time.deltaTime;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) || MobileInputScript.Instance._swipeUp && !_isMoving)
        {
            _isMoving = true;
            _rb.velocity = Vector3.forward * _speed * Time.deltaTime;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || MobileInputScript.Instance._swipeDown && !_isMoving)
        {
            _isMoving = true;
            _rb.velocity = Vector3.back * _speed * Time.deltaTime;
        }
        if(_rb.velocity == Vector3.zero)
        {
            _isMoving = false;
        }
        
    }

    public void TakeDashes ( GameObject _dash)
    {
        _dash.transform.SetParent(_dashesParent.transform);
        Vector3 _pos = _prevDash.transform.localPosition ;
        _pos.y -= 0.06f;
        _dash.transform.localPosition = _pos;
        Vector3 _characterPos = transform.localPosition; 
        _characterPos.y += 0.06f;
        transform.localPosition = _characterPos;
        _prevDash = _dash;
        _prevDash.GetComponent<BoxCollider>().isTrigger = false;

    }
}
