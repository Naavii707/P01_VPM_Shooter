using UnityEngine;

public class Rotate : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed = 5;
    [SerializeField]
    private bool _isRotating = true;
    
    public bool IsRotating
    {
        get { return _isRotating; }
        set { _isRotating = value; }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateWeapon();
    }

    
    private void RotateWeapon()
    {
        if (_isRotating)
        {
            gameObject.transform.Rotate(0f, rotateSpeed*Time.deltaTime, 0f);
        }
    }
}
