# 按E触发交互事件逻辑：
E pressed -> _gameControl.Player.Interact.performed (event) -> Interact_Performed(Func)
-> OnInterAction(Event) -> GameInput_OnInteractAction(Func)
1. 系统检测到按下E后，_gameControl.Player.Interact.performed被触发
   此时，按下E是Pulisher， Interact_Performed()是接收者。
   
2. Interact_Performed(Func) -> OnInterAction(Event) -> GameInput_OnInteractAction(Func)
   Interact_Performed方法会触发OnInterAction;
   此时，OnInterAction也可以看作一个信号弹;
   而在player中，_gameInput.OnInterAction为中注册了GameInput_OnInteractAction(Func)这个方法。
   换言之，一旦OnInterAction被触发，GameInput_OnInteractAction也会被触发。