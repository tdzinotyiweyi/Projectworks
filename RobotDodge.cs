using System;
using SplashKitSDK;


public class RobotDodge
{
     private Player _Player;
     private Window _GameWindow;
     private Robot _TestRobot;
     public bool Quit
     {
         get 
         {
             return _Player.Quit;
         }
     }

     public RobotDodge(Window gameWindow)
     {
         _GameWindow = gameWindow;
         _Player = new Player(_GameWindow);
         _TestRobot = RandomRobot();
     }

     public Robot RandomRobot()
     {
         Robot randomRobot = new Robot(_GameWindow);
         return randomRobot;
     }

     public void HandleInput()
     {
         _Player.HandleInput();
         _Player.StayOnWindow(_GameWindow);
     }

     public void Draw()
     {
         _GameWindow.Clear(Color.Red);
         _TestRobot.Draw();
         _Player.Draw();
         _GameWindow.Refresh(60);
     }

     public void Update()
     {
         if (_Player.CollidedWith(_TestRobot))
         {
             _TestRobot = RandomRobot();
         }

     }

}
