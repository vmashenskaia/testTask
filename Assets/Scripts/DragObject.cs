using UnityEngine;

public class DragObject : MonoBehaviour
{
    [SerializeField]
    private CameraMove _cameraMove;
    private Vector3 _offset; 
    private float _zDepth; 
    private Rigidbody2D _rb;
    private bool _isDragging;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        if (_rb != null)
        {
            _rb.gravityScale = 1; 
        }
    }

    private void OnMouseDown()
    {
        _cameraMove.enabled = false;

        if (_rb != null)
        {
            _rb.gravityScale = 0;
            _rb.velocity = Vector2.zero; 
        }
        
        _zDepth = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _zDepth;
        _offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
        _isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (!_isDragging) return;
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _zDepth;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + _offset;
    }

    private void OnMouseUp()
    {
        _cameraMove.enabled = true;
        _isDragging = false;
        
        if (_rb != null)
        {
            _rb.gravityScale = 1;
        }
    }
}