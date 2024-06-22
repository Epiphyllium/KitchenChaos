using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player : FoodMaterialHolder
{
    private Rigidbody _rigidbody;

    //public static Player _player { get; private set; }
    
    [SerializeField] private LayerMask _counterLayerMask ;
    [SerializeField] private GameInput _gameInput;
    
    private float _moveSpeed = 7.0f;
    private float _rotateSpeed = 10.0f;
    private float _interactWithClearCounterDis = 2.0f;
    
    private bool _isWalking;
    private BaseCounter _curSelectedCounter;
    // Start is called before the first frame update

    private void Awake()
    {
        //_player = this;
    }

    void Start()
    {
        // _rigidbody = GetComponent<Rigidbody>();
        // _rigidbody.position = transform.position;
        _gameInput.OnInterAction += GameInput_OnInteractAction;
        _gameInput.OnOperateAction += GameInput_OnOperateAction;

    }

    // Update is called once per frame
    void Update()
    {
        CounterStatusMonitor();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public bool GetIsWalking()
    {
        return _isWalking;
    }

    private void HandleMovement()
    {
        
        var direction = _gameInput.GetNormalizedMovementDir();
        
        _isWalking = (direction != Vector3.zero);
        transform.position += direction*Time.deltaTime*_moveSpeed;
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime*_rotateSpeed);
        }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        _curSelectedCounter?.Interact(this);
    }

    private void GameInput_OnOperateAction(object sender, System.EventArgs e)
    {
        _curSelectedCounter?.Operate(this);
    }

    private bool IsCollideWithCounter(out RaycastHit hitInfo)
    { 
        return Physics.Raycast(transform.position, transform.forward, out hitInfo,_interactWithClearCounterDis,_counterLayerMask);
    }
    
    public void SetCurSelectedCounter(BaseCounter counter)
    {
        if (counter != _curSelectedCounter)
        {
            _curSelectedCounter?.CancelSelectedCounter();
            counter?.SelectCounter();
            _curSelectedCounter = counter;
        }
    }
    private void CounterStatusMonitor()
    {
        if (IsCollideWithCounter(out RaycastHit hitInfo))
        {
            if (hitInfo.transform.TryGetComponent<BaseCounter>(out BaseCounter curInterCounter))
            {
                SetCurSelectedCounter(curInterCounter);
            }
            else
            {
                SetCurSelectedCounter(null);
            }
        }
        else
        {
            SetCurSelectedCounter(null);
        }
    }
    
}
