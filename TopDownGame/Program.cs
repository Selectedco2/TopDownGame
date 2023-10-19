﻿using Raylib_cs;
using System.Numerics;

// - Vektorer för förflyttning
// - Vektorer för positioner (cirklar)
// - Rektanglar
// - Texturer
// - Färger

// - Input
// - Olika scener
// - Kollisioner

Raylib.InitWindow(800, 600, "Hello");
Raylib.SetTargetFPS(60);

int floorY = 550;
int floorSpeedY = -1;
string scene = "start";

Vector2 movement = new Vector2(0.1f, 0.1f);

Color hotPink = new Color(255, 105, 180, 255);


Texture2D characterImage = Raylib.LoadTexture("champ.png");
Rectangle characterRect = new Rectangle(10, 10, 32, 32);
characterRect.width = 32;
characterRect.height = 32;

float speed = 5;

while (!Raylib.WindowShouldClose())
{
  movement = Vector2.Zero;

  if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
  {
    movement.X = -1;
  }
  else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
  {
    movement.X = 1;
  }

  if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
  {
    movement.Y = -1;
  }
  else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
  {
    movement.Y = 1;
  }

  if (movement.Length() > 0)
  {
    movement = Vector2.Normalize(movement);
  }

  movement *= speed;

  characterRect.x += movement.X;
  characterRect.y += movement.Y;

  // x++;
  floorY += floorSpeedY;
  if (floorY < 0)
  {
    floorSpeedY = 1;
  }
  else if (floorY > 550)
  {
    floorSpeedY = -1;
  }

  // position += movement;

  Raylib.BeginDrawing();
  Raylib.ClearBackground(Color.GOLD);


  // Raylib.DrawCircle(x, 300, 30, Color.BLACK);
  // Raylib.DrawCircleV(position, 20, hotPink);
  Raylib.BeginDrawing();
  if (scene == "start")
  {
    Texture2D StartScreen = Raylib.LoadTexture("champ.png");

    if (Raylib.GetKeyPressed() != 0)
    {
      scene = "game";
    }

  }

    else if (scene == "game")
  {
    Raylib.DrawRectangle(0, floorY, 800, 30, Color.BLACK);

    Raylib.DrawRectangleRec(characterRect, Color.BLUE);
    Raylib.DrawTexture(characterImage, (int)characterRect.x, (int)characterRect.y, Color.WHITE);

  }
  Raylib.EndDrawing();

}
