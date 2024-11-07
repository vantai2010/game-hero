using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    [SerializeField] protected float moveHorizontal;
    [SerializeField] protected float moveVertical;
    [SerializeField] protected Vector3 mousePosition;
    [SerializeField] protected float onFiring;
    [SerializeField] protected bool isAlpha1;
    [SerializeField] protected bool isAlpha2;
    [SerializeField] protected bool isAlpha3;
    [SerializeField] protected bool isAlpha4;
    public static InputManager Instance => _instance;
    public float MoveHorizontal => moveHorizontal;
    public float MoveVertical => moveVertical;
    public Vector3 MousePosition => mousePosition;
    public float OnFiring => onFiring;
    public bool IsAlpha1 => isAlpha1;
    public bool IsAlpha2 => isAlpha2;
    public bool IsAlpha3 => isAlpha3;
    public bool IsAlpha4 => isAlpha4;


    protected void Awake()
    {
        if (InputManager._instance != null) Debug.LogError("Only One InputManager allow to exists");
        InputManager._instance = this;  
    }
    protected void Update()
    {
        this.GetValueDirection();
        this.GetMousePosition();
        this.GetMouseDown();
        this.GetKeyMumberDown();
    }
    protected void GetValueDirection()
    {
        this.moveHorizontal = Input.GetAxis("Horizontal");
        this.moveVertical = Input.GetAxis("Vertical");
    }
    protected virtual void GetMousePosition()
    {
        this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    protected void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetKeyMumberDown()
    {
        this.isAlpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        this.isAlpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        this.isAlpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        this.isAlpha4 = Input.GetKeyDown(KeyCode.Alpha4);
    }
}
