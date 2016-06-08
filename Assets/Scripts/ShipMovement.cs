using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{

    public float MoveSpeed = 10;
    public Vector3 MoveAxis = Vector3.right;
    public float MaxRotation = 45;
    public Vector3 RotateAxis = Vector3.forward;
    public float MoveLimit = 5;

    private float _displacement = 0;
    private Vector3 _InitialPosition;

	// Use this for initialization
	void Start ()
    {
        _InitialPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float roll = Input.GetAxis("Roll");
        _displacement =  Mathf.Clamp(_displacement + roll * Time.deltaTime * MoveSpeed, -MoveLimit, MoveLimit);
        transform.position = _InitialPosition + MoveAxis.normalized * _displacement;
        transform.rotation = Quaternion.AngleAxis(roll * MaxRotation, RotateAxis);
    }
}
