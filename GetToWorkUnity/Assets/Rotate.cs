using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

    public float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation;
    private bool _isRotating;


    public Material unselected;
    public Material selected;
    public Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _rotation = Vector3.zero;
    }

    void Update()
    {
        if (_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

            // rotate
            transform.Rotate(_rotation);

            // store mouse
            _mouseReference = Input.mousePosition;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            // rotating flag
            _isRotating = true;

            // store mouse
            _mouseReference = Input.mousePosition;

            _renderer.material = selected;
        }


        
    }



    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
        _renderer.material = unselected;
    }

}