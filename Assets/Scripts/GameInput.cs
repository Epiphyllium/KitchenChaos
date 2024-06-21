using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private GameControl _gameControl;
    
    //OnInterAction:触发事件的接口
    public event EventHandler OnInterAction;
    public event EventHandler OnOperateAction;
    private void Awake()
    {
        _gameControl = new GameControl();
        _gameControl.Player.Enable(); //Player means a defined action map 
        //将 Interact_Performed 方法添加为performed事件的一个监听器。
        //换句话说，当玩家执行了 "Interact" 动作时，就会调用 Interact_Performed 方法。
        _gameControl.Player.Interact.performed += Interact_Performed;
        _gameControl.Player.Operate.performed += Operate_Performed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //obj 带有操作触发的相关信息
    //Interact_Performed触发了一个名为 OnInterAction 的事件。
    //在C#中，事件通常是用来实现发布者-订阅者模式，即当某个事件发生时，所有订阅了该事件的对象都会收到通知并执行相应的逻辑。
    //在这里，OnInterAction 事件用于通知其他对象或脚本，表明玩家已执行了交互操作。
    //通过 Invoke 方法，将事件触发，并传递了当前对象(事件的触发者)this 以及一个空的 EventArgs 对象作为参数。
    private void Interact_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInterAction?.Invoke(this,EventArgs.Empty);
    }

    private void Operate_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this,EventArgs.Empty);
    }
    public Vector3 GetNormalizedMovementDir()
    {
        var inputVector2= _gameControl.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputVector2.x,0,inputVector2.y);
        direction = direction.normalized;
        return direction;
    }
}
