using Raylib_cs;
using System.Numerics;

// 1. Lägg in en snygg logga/bakgrund på startskärmen
// 2. Lägg till en gameover-skärm om man kommer till om man går utanför skärmen
// 3. Lägg till en "starta-om" knapp


Raylib.InitWindow(1024, 768, "Topdown game");
Raylib.SetTargetFPS(60);

float speed = 4.5f;

Texture2D avatarImage = Raylib.LoadTexture("warrior.png");

Rectangle character = new Rectangle(0, 60, avatarImage.width, avatarImage.height);
Rectangle enemyRect = new Rectangle(700, 500, 64, 64);

//                       r   g    b    a
Color myColor = new Color(0, 200, 30, 255);

string currenctScene = "start"; // Start, win, game, gameover


Vector2 enemyMovement = new Vector2(1, 0);    // Hastighet och riktning
float enemySpeed = 2;   // Hur snabbt han rör sig 


while (Raylib.WindowShouldClose() == false)
{
  // LOGIK

  if (currenctScene == "game")
  {
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
      character.x += speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
      character.x -= speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {
      character.y += speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
  {
    character.y -= speed;
  }
  
    Vector2 playerPos = new Vector2(character.x, character.y);
    Vector2 enemyPos = new Vector2(enemyRect.x, enemyRect.y);

    Vector2 diff = playerPos - enemyPos;

    Vector2 enemyDirection = Vector2.Normalize(diff);


    enemyMovement = enemyDirection * enemySpeed;

    enemyRect.x += enemyMovement.X;
    enemyRect.y += enemyMovement.Y;



  if (Raylib.CheckCollisionRecs(character, enemyRect))
  {
    currenctScene = "gameover";
  }
}
  else if (currenctScene == "start")
  {
    if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
    {
      currenctScene = "game";
    }
  }

  // GRAFIK

  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.WHITE);
  if (currenctScene == "game")
  {
    Raylib.DrawTexture(avatarImage, (int) character.x, (int) character.y, Color.WHITE);

    Raylib.DrawRectangleRec(enemyRect, Color.RED);
  }

  else if (currenctScene == "start")
  {
    Raylib.DrawText("Press ENTER to start", 315, 500, 32, myColor);
  }

  else if (currenctScene == "gameover")
  {
    Raylib.DrawText("GAME OVER", 10, 10, 128, Color.RED);
  }


  Raylib.EndDrawing();
}