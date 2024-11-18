using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;

    // skärmbredd: 800px  skärmhöjd: 480px
    Rectangle leftPaddle = new Rectangle(10,200,20,100);
    Rectangle rightPaddle = new Rectangle(770,200,20,100);
    Rectangle ball = new Rectangle(390,230,20,20);
    int ballXVelocity = 1;
    int ballYVelocity = 1; 

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        pixel = new Texture2D(GraphicsDevice,
        1,1);
        pixel.SetData(new Color[]{Color.White});
        //pixel = Content.Load<Texture2D>("pixel");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        KeyboardState kState = Keyboard.GetState();
        if(kState.IsKeyDown(Keys.W)){
            leftPaddle.Y -= 1;
        }
        if(kState.IsKeyDown(Keys.S)){
            leftPaddle.Y += 1;
        }

        if(kState.IsKeyDown(Keys.Up)){
            rightPaddle.Y -= 1;
        }
        if(kState.IsKeyDown(Keys.Down)){
            rightPaddle.Y += 1;
        }

        ball.X += ballXVelocity;
        ball.Y += ballYVelocity;

        if(rightPaddle.Intersects(ball) || 
           leftPaddle.Intersects(ball)){
            ballXVelocity *= -1;
        }

        if(ball.Y <= 0 || ball.Y >= 460){
            ballYVelocity *= -1;
        }

        if(ball.X <= 0 || ball.X >= 780){
            ball.X = 390;
            ball.Y = 230;
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(pixel,leftPaddle,Color.HotPink);
        _spriteBatch.Draw(pixel,rightPaddle,Color.HotPink);
        _spriteBatch.Draw(pixel,ball,Color.Black);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
