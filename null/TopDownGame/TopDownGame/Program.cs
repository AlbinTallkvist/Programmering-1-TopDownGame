using Raylib_cs;

// 1. Lägg in en snygg logga/bakgrund på startskärmen
// 2. Lägg till en gameover-skärm om man kommer till om man går utanför skärmen
// 3. Lägg till en "starta-om" knapp


Raylib.InitWindow(1024, 768, "Topdown game");
Raylib.SetTargetFPS(60);

float speed = 4.5f;

Texture2D avatarImage = Raylib.LoadTexture("warrior.png");

Rectangle character = new Rectangle(0, 60, avatarImage.width, avatarImage.height);
Rectangle trapRect = new Rectangle(700, 500, 64, 64);

//                       r   g    b    a
Color myColor = new Color(0, 200, 30, 255);

string currenctScene = "start"; // Start, win, game, gameover


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
  
  if (Raylib.CheckCollisionRecs(character, trapRect))
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

    Raylib.DrawRectangleRec(trapRect, Color.RED);
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