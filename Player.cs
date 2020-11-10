using System;
using SplashKitSDK;

public class Player
{
    
    private Bitmap _PlayerBitmap; 

    public Window window;

    public double X {get; private set;}

    public double Y {get; private set;}
    
    public bool Quit {get; private set;}


    public int SPEED;



    public int Width 
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }

    public int Height 
    {
        get
        {
            return _PlayerBitmap.Height;
        }
    
    }
    
    public Player(Window gameWindow)
    {
        window = gameWindow;
    
        _PlayerBitmap = new Bitmap("Player","Player.png");

        X = (gameWindow.Width - Width ) / 2;

        Y = (gameWindow.Height - Height) / 2;

        Quit = false; 
    }


    public void Draw()
    {
        window.DrawBitmap(_PlayerBitmap, X, Y);
    }

    public bool CollidedWith(Robot other)
    {
        return _PlayerBitmap.CircleCollision(X, Y, other.CollisionCircle);
    }
    
    public void HandleInput()
    {
    
        SPEED = 5;

        SplashKit.ProcessEvents();
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Y = Y - SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Y = Y + SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            X = X - SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            X = X + SPEED;
        }

        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
          Quit = true;
        }
      
    }

    public void StayOnWindow(Window gameWindow)
    {  
        const int GAP = 10; 

        if ( X < GAP)
        {
            X = GAP;
        }

        if ( X > (gameWindow.Width - GAP) - Width )
        {
            X = (gameWindow.Width - GAP) - Width;
        }

        if (Y < GAP)
        {
             Y = GAP;
        }

         if ( Y > (gameWindow.Height - GAP) - Height )
        {
            Y = (gameWindow.Height - GAP) - Height;
        }
   
    }
}