using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    private Vector3 _lastMousePosition;
    private bool _isDragging;

    private readonly float _minX = 3.06f;
    private readonly float _maxX = 31.7f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
        }

        if (_isDragging)
        {
            float deltaX = Input.mousePosition.x - _lastMousePosition.x;
            float newX = transform.position.x + deltaX * moveSpeed;
            newX = Mathf.Clamp(newX, _minX, _maxX);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            _lastMousePosition = Input.mousePosition;
        }
    }
}
//Скролл реализован за счет перемещения позиции камеры по оси X, перемещение ограничено координатами X начала и конца фона