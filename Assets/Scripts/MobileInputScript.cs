using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputScript : MonoBehaviour
{
    public static MobileInputScript Instance{set; get;}
    void Awake()
    {
        Instance = this;
    }

    public bool _tap, _swipeLeft, _swipeRight, _swipeUp, _swipeDown;
    public Vector2 _swipeDelta, _startTouch;
    private const float deadZonde = 100;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        _tap = _swipeLeft = _swipeRight = _swipeUp = _swipeDown = false;
        
        if(Input.GetMouseButtonDown(0))
        {
            _tap = true;
            _startTouch = Input.mousePosition;

        }
        else if(Input.GetMouseButtonUp(0))
        {
            _startTouch = _swipeDelta = Vector2.zero;

        }


        if(Input.touches.Length != 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                _tap = true;
                _startTouch = Input.mousePosition;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _startTouch = _swipeDelta = Vector2.zero;
            }
        }
        _swipeDelta = Vector2.zero;
        if(_startTouch != Vector2.zero)
        {
            if(Input.touches.Length != 0)
            {
                _swipeDelta = Input.touches[0].position - _startTouch;
            }
            else if(Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;

            }
        }

        if(_swipeDelta.magnitude > deadZonde)
        {
            float x = _swipeDelta.x; 
            float y = _swipeDelta.y;

            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x < 0)
                {
                    _swipeLeft = true;
                }
                else
                {
                    _swipeRight = true;
                }
            }
            else
            {
                if(y < 0)
                {
                    _swipeDown = true;
                }
                else
                {
                    _swipeUp = true;
                }
            }
            _startTouch = _swipeDelta = Vector2.zero;
        }
        
        

        
    }
}
