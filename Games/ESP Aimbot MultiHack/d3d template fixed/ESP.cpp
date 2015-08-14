#include "Hacks.h"
#include "ESP.h"
#include "EspVars.h"


//our constructor this is where we start everything
ESP::ESP()
{

}

void ESP::SetupDirect3D(IDirect3DDevice9 *d3dDevice, LPD3DXFONT *m_font)
{
    //Assign our Drawing device
	M_font = *m_font;
	D3dDevice = d3dDevice;
	//Initialize our Line otherwise we go into crash town when using it
	D3DXCreateLine(D3dDevice, &S_Line);

	//Replace game name with what ever game YOU ARE PLAYING AT ESP.H
	Handle = FindWindow(NULL, GAMENAME);
}


//By using our PlayerData pointers and memory addresses we grab all information from the player including:
//Xmouse(YAW), Ymouse(PITCH) coordinates, player's position on the game x,y and z as well as the player's health
//with that we can ignore dead enemies and not aim when OUR player is dead
PlayerDataVec GetPlayerVec()
{
    PlayerDataVec playerRet;

	playerRet.health =*(int*)(0x12886A0);
    playerRet.isInGame =*(int*)(0x74E35C);
    //Get our client number
    playerRet.clientNum = *(int*)(0x74E338);
    playerRet.team = *(int*)(0x83928C); //GET OUR current team so we don't shoot at team mates
    //GET OUR FIELD OF VIEW
    fov[0] = *(float*)(0x797610);
    fov[1] = *(float*)(0x797614);
      
    viewAngles.x = *(float*)(0x79B698);
    viewAngles.y = *(float*)(0x79B69C);
    viewAngles.z = *(float*)(0x79B6A0);
    playerRet.xPos = *(float*)(0x797618);
    playerRet.yPos = *(float*)(0x79761C);
    playerRet.zPos = *(float*)(0x797620);
    playerRet.clientNum = *(float*)(0x74E338);

    return playerRet;
}

Vect3d ESP::SubVectorDist(PlayerDataVec &playerFrom, PlayerDataVec &playerTo)
{
     return Vect3d(playerFrom.xPos - playerTo.xPos, playerFrom.yPos - playerTo.yPos, playerFrom.zPos - playerTo.zPos);
}

Vect3d ESP::SubVectorDist(Vect3d &playerFrom, Vect3d &playerTo)
{
	return Vect3d(playerFrom.x - playerTo.x, playerFrom.y - playerTo.y, playerFrom.z - playerTo.z);
}

//Use the well known 3d distance formula to see  how 2 players are from each other
//i didnt make this myself its just FACT. Almost every 3D game uses this formula. 2D games use a simpler variation
float ESP::Get3dDistance(PlayerDataVec to, PlayerDataVec from)
{
    return (sqrt(
    ((to.xPos - from.xPos) * (to.xPos - from.xPos)) +
    ((to.yPos - from.yPos) * (to.yPos - from.yPos)) +
    ((to.zPos - from.zPos) * (to.zPos - from.zPos))
    ));
}

//We need to update res information incase our player decides to change it mid game or after game
//Also when the game first loads it receives bad data(0) which means res vars haven't been declared yet
void ESP::UpdateResolution()
{
    //Although if you can find the values from memory then you can adapt to any res
    resolution[0] = *(int*)0xD573F34;
    resolution[1] = *(int*)0xD573F38;

    screencenter[0] = resolution[0] / 2;
    screencenter[1] = resolution[1] / 2;
	GotRes = true;
}

void ESP::DrawMyHealth()
{
	//if you want to change the size of your health bar you do it here, 
	//you may need to change other variables below to adjust to the new sizes
	const int barWidth = 200;
	const int barHeight = 35;
	//Where to draw our health bar
	int x = resolution[0]-220;
	int y = resolution[1]-50;

	//Get our player's information so we can display the health
	PlayerDataVec playerVec = GetPlayerVec();
	//Make a blue border box for our health near the bottom right corner of our screen(just modify these values to position it where ever you like)
	Drawing::DrawBorderBox(x, y, barWidth/*w*/, barHeight/*h*/, 4, D3DCOLOR_ARGB(255, 0, 0, 255), D3dDevice );
	//DRAW WITHIN THE BORDER BOX OUR CURRRENT HEALTH

	//int percentageHealth = (playerVec.health / MAXHEALTH)*100;
	//now we have our percentage we need to now what the percentage of our drawn bar that is e.g.
	//if we have 75% out of 100 health then we only want to draw that on our bar
	//my bar default size is 200 so i would need to find 75% of 200
	int barPercentage = (barWidth/100/*Gets 1% of our bar*/) * playerVec.health;
 
	// Create a rectangle to indicate where on the screen TEXT should be drawn
	//THIS IS USED TO POSITION OUR TEXT saying "Health"
	//Left, Top, Right, Bottom that's the order
	RECT healthRect = 
	{
		x, //L 
		y-20,//T
		x + barWidth,//R
		y + barHeight//B
	};
	//Join up our Health text with the actual health number so we can see our main health bar
	std::stringstream ss;
	ss << "Health:" << playerVec.health;

	M_font->DrawText(NULL, ss.str().c_str() , -1, &healthRect, DT_NOCLIP, D3DCOLOR_ARGB(255, 255, 0, 0));
	//Draw our Health bar
	Drawing::DrawFilledRect( x+2, y+2, barPercentage, barHeight-2, GetHealthColor(playerVec.health), D3dDevice );
}

//Here we draw our enemy's health bars dynamically
void ESP::DrawEnemyHealth(int x, int y, int w, int h, int health)
{
	//Get our player's information so we can display the health
	//PlayerDataVec playerVec = GetPlayerVec();
	//Make a blue border box for our health near the bottom right corner of our screen(just modify these values to position it where ever you like)
	Drawing::DrawBorderBox(x, y, w/*w*/, h/*h*/, 4, D3DCOLOR_ARGB(255, 0, 0, 255), D3dDevice );

	//Find out what percentage of our maximum health we have
	float healthPercentage = ((float)health/(float)MAXHEALTH) * 100.0f;
	
	//Now find what healthPercentage of our bar is
	//e.g.we healthPercentage = 80% then we do (w)50/(80/100) = 50/0.8 = 40 
	//which means we draw 40/50 for width showing our 80%
	float barPercentage = ((float)w*(float)(healthPercentage/100));

	RECT healthRect = 
	{
		x, //L 
		y-20,//T
		x + w,//R
		y + h//B
	};

	//Draw our Health value in numbers for enemy
	M_font->DrawText(NULL, I_O::IntToString(health).c_str() , -1, &healthRect, DT_NOCLIP, D3DCOLOR_ARGB(255, 255, 0, 0));
	
	//Draw our Health bar at the appropriate size according to the enemy's distance
	Drawing::DrawFilledRect( x, y, (int)barPercentage, h, GetHealthColor(health), D3dDevice );
}




//Find out what colour to display a player/enemy's health bar
D3DCOLOR ESP::GetHealthColor(int currentHealth)
{
	//Here are a variety of colours that we display based on how much health a player has left.
	//Full Health starting at a solid green and slowly decreasing in color until we have a bright red
	if(currentHealth > 89 && currentHealth <= 100)
		return D3DCOLOR_ARGB(255, 0, 255, 0);
	else if(currentHealth > 79 && currentHealth < 90)
		return D3DCOLOR_ARGB(255, 0, 255, 155);
	else if(currentHealth > 69 && currentHealth < 80)
		return D3DCOLOR_ARGB(255, 255, 255, 0);
	else if(currentHealth > 59 && currentHealth < 70)
		return D3DCOLOR_ARGB(255, 255, 205, 0);
	else if(currentHealth > 49 && currentHealth < 60)
		return D3DCOLOR_ARGB(255, 255, 170, 0);
	else if(currentHealth > 39 && currentHealth < 50)
		return D3DCOLOR_ARGB(255, 255, 128, 0);
	else if(currentHealth > 29 && currentHealth < 40)
		return D3DCOLOR_ARGB(255, 255, 97, 0);
	else if(currentHealth > 19 && currentHealth < 30)
		return D3DCOLOR_ARGB(255, 255, 58, 0);
	else if(currentHealth > 9 && currentHealth < 20)
		return D3DCOLOR_ARGB(255, 255, 0, 66);
	else if(currentHealth > 1 && currentHealth < 9)
		return D3DCOLOR_ARGB(255, 255, 0, 0);
}

//With this we see which enemy is closest to OUR player, we return their index that way we aim directly
//at our closest enemy
int ESP::FindClosestEnemyIndex(PlayerDataVec * enemiesDataVec, int enemiesDvLength, PlayerDataVec myPosition)
{
    float * distances = new float[enemiesDvLength];
    //store all our distances between us and the enemies to see which is closest
    for (int i = 0; i < enemiesDvLength; i++)
    {
        //only store their distance if they are ALIVE
		if (enemiesDataVec[i].health > 0)
            distances[i] = Get3dDistance(enemiesDataVec[i], myPosition);
        //This is kind of a cheat here and im not really proud of it :/ but it was done in a rush
        //in theory it just sets these as very high floats and ensures that DEAD enemies dont get 
        //aimed at
        else
        {
            distances[i] = 60000.0;
        }
    }
    //Make a copy of our array so we dont lose track of which position our closest enemy is
	float * newDistances = new float[enemiesDvLength];
	//Make a copy of our float array into another array
	std::copy(&distances[0], &distances[0] + enemiesDvLength, &newDistances[0]);
    
	//Sort our array in LOWEST TO HIGHEST order to find out which enemy is closest to us so we can shoot them
	//in the face
	std::sort(&newDistances[0], &newDistances[0] + enemiesDvLength);

    //See which enemy was closest and return that Index for us to aim at them
    for (int i = 0; i < enemiesDvLength; i++)
    {
        if (distances[i] == newDistances[0]) //0 BEING THE CLOSEST
        {
			delete distances;
			delete newDistances;
            return i;
        }
    }
	delete newDistances;
	delete distances;
    return -1;
}




//Note this function may look like a lot but if you have trouble with it have a good read of the comments and
//you will realize that its not as bad as it seems 
//We send in all our variables from the menu to see if we turn ESP specific functions on or not e.g. ESP Distance
void ESP::Esp_Aimbot(bool Esp_box_Name, bool ESPhealth, bool ESPdistance, bool ESPsnapLine, bool ESPaimbot)
{
	//Get our player's information
	PlayerDataVec playerVec = GetPlayerVec();
	int enemyCount = 0; // used to loop our enemy data 
	//Set up our array to hold enemy data, 64 in our example is the max number a cod 4 game can have
	PlayerDataVec enemiesVec[MAXPLAYERS]; 
	PlayerDataVec viableEnemiesVec[MAXPLAYERS]; 

	//if we are not in game then no point in running hack
	if(playerVec.isInGame)
	{
		//If we haven't added added our resolution to our array then we need to do that before drawing anything
		//the reason why this is here is because getting the resolution at the beginning fails although there are probably better ways to do this
		if(!GotRes)
			UpdateResolution();

        for (int i = 0; i < MAXPLAYERS; i++)
        {
			PlayerDataVec enemyVec;
            enemyVec.isValid = *(int*)(0x839270 + i * 0x4CC);

            enemyVec.isAlive = *(int*)(0x84F2D8 + i * 0x1DC + 0x1C0);

            enemyVec.clientNum = *(int*)(0x84F2D8 + i * 0x1DC + 0xCC);

            //read our player's name :), i believe it has up to 16 chars
            for (int x = 0; x < 16; x++)
                enemyVec.name[x] = *(char*)(0x839270 + i * 0x4CC + (0xC + x));

            //get our enemy's team
            enemyVec.team = *(int*)(0x839270 + i * 0x4CC + 0x1C);
			
			//Get our enemy's health
			enemyVec.health = *(int*)(0x12886A0 + i * 0x274);

            //if player is alive, valid and is NOT US then we add him to the list of possible victims and ESP targets
            if (enemyVec.isValid == 1 && enemyVec.clientNum != playerVec.clientNum)
            {
                //Same team as us so color them green
                if (enemyVec.team == playerVec.team)
                    enemyVec.color = Color(0, 255, 0); //change your friendly color here if you like
                //Enemy
                else
                    enemyVec.color = Color(255, 0, 0);//change your enemy color here if you like

                //grab enemy's pos
                enemyVec.xPos = *(float*)(0x839270 + i * 0x4CC + 0x398); // 0x4CC size of struct
                enemyVec.yPos = *(float*)(0x839270 + i * 0x4CC + 0x39C);
                enemyVec.zPos = *(float*)(0x839270 + i * 0x4CC + 0x3A0);
                //grab the enemy's pose, we need this incase the enemy is prone that way we move the ESP box down and aimbot lower
                enemyVec.pose = *(int*)(0x839270 + i * 0x4CC + 0x470);

                //Add our new player info to our [array/list]
                //add our enemy information to the list if hes alive otherwise ignore them
                enemiesVec[enemyCount] = enemyVec;
				enemyCount++;
            }
		}

		playerVec = GetPlayerVec();
        float dist;
        float drawx;
        float drawy;

        //Now we have all our enemies stored and we need to display the ESP on them
        for (int i = 0; i < enemyCount; i++)
        {
			//Find the Distance between Us and the enemy
			dist = SubVectorDist(playerVec, enemiesVec[i]).length() / 48;

            //converts our 3d Coordinates to 2d
			if (WorldToScreen(enemiesVec[i].VecCoords(), playerVec.VecCoords()))
            {
                //say that our enemy is ok to aim at
                enemiesVec[i].visible = true;

                if ((((enemiesVec[i].pose & 0x08) != 0)) ||
                    ((enemiesVec[i].pose & 0x100) != 0) ||
                    ((enemiesVec[i].pose & 0x200) != 0))
                {
                    drawx = 700.0f / dist;
                    drawy = 400.0f / dist;
                    ScreenY += 4.6f;
                }
                else
                {
                    drawx = 400.0f / dist;
                    drawy = 700.0f / dist;
                }
                //We find exacly where to draw including from our Window's e.g. 
                //if the window has been moved since our last loop
                //add an extra bit to our screenX depending on our pos in relation to the en
                //take away any height based on our own position e.g. if were crawling the ESP needs to be slightly adjusted

				//DRAW OUR DAMN ESP :) Looks more complicated than it is
				if(Esp_box_Name)
				{
					DrawESPBox((int)(ScreenX)-(drawx/2), // so we don't start our rectangle in the middle of the player but to their left a bit that way the rectangle covers most of the player
						(int)(ScreenY - (drawy+(drawy/2))), //a bit of a workaround but you can adapt your own pos to your game
						drawx,
						drawy,
						2,
						D3DCOLOR_ARGB(255/*Alpha*/,
						enemiesVec[i].color.R,
						enemiesVec[i].color.G,
						enemiesVec[i].color.B),
						D3dDevice );

				}
				//how our player name with distance
				if(ESPdistance)
				{
					// Create a rectangle to indicate where on the screen TEXT should be drawn
					//THIS IS USED TO POSITION OUR TEXT
					//Left, Top, Right, Bottom that's the order
					RECT nameRect = {(ScreenX)-(drawx/2), //L 
						(ScreenY - drawy/2),//T
						(ScreenX)+(drawx*4),//R
						(ScreenY + drawy)};//B

					//DRAW OUR PLAYER NAME AND DISTANCE, Get our player's name and distance string to display
					std::stringstream nameNdistance;
					nameNdistance << std::string(enemiesVec[i].name) << " (" << I_O::FloatToString(dist) << "m)";


					//Display our Player's name
					M_font->DrawText(NULL, nameNdistance.str().c_str(), -1, &nameRect, DT_NOCLIP,
					//Text is the Same colour as our ESP rectangle
					D3DCOLOR_ARGB(255, enemiesVec[i].color.R, enemiesVec[i].color.G, enemiesVec[i].color.B));
				}

				if(ESPhealth)
				{
					//Here we call our function in charge of drawing our ENEMY's health Bar
					DrawEnemyHealth(
						(int)(ScreenX - (drawx/2)),
						(int)(ScreenY - (drawy*2)),
						drawx, drawy/4, enemiesVec[i].health);
				}

				if(ESPsnapLine)
				{
					//These are the lines that you see from our player to the enemies
					//Oh snap
					//-----------------------------DRAW SNAP LINES-----------------------
					//Draw From us to the enemies
					DrawLine(
						resolution[0]/2, //Start X
						resolution[1],//Start Y
						(ScreenX - (drawx/2)),//End line X
						(ScreenY - (drawy/2)),//End line Y
						//Draw line color based on who we are aiming, Enemies line goes RED, Friendlies GO Green
						D3DCOLOR_ARGB(255, enemiesVec[i].color.R, enemiesVec[i].color.G, enemiesVec[i].color.B));
				}
			}
            else enemiesVec[i].visible = false;
		}

		//ESP OVER WE NOW START DEALING WITH AIMBOT :)
		//---------------------------------AIMBOT PART-------------------------------
		if(ESPaimbot)
		{
			//Get only valid player's for our aimbot to use
			//with this array we filter out any team mates so that we only shoot at enemies
			int validPlayerCounter = 0;
			PlayerDataVec validAimbotEnemies[MAXPLAYERS]; 
			for (int i = 0; i < enemyCount; i++)
			{
				if (enemiesVec[i].team != playerVec.team)
				{
					validAimbotEnemies[validPlayerCounter] = enemiesVec[i];
					//This is something to do with our Aimbot, here we simply check if we had a previous target, if that target has been killed 
					//then we force the game to find a new player to aim at
					if(FocusTarget == validPlayerCounter)
					{
						if(validAimbotEnemies[validPlayerCounter].health < 1)
							FocusTarget = -1;
					}
					validPlayerCounter++;
				}
			}

			//check if our hot key is being pressed
			//Mouse 2, if you want to use other hot keys Go here
			//http://msdn.microsoft.com/en-us/library/ms927178.aspx
			//Currently its RIGHT MOUSE KEY 0x02
			if (GetAsyncKeyState(0x02))
			{
				//FocusingOnEnemy = true;
				int target = 0;
				if (/*FocusingOnEnemy && */FocusTarget != -1)
				{
					//If our previous target is still alive we focus on them otherwise go after someone else
					if (validAimbotEnemies[FocusTarget].health > 0)
						target = FocusTarget;
					else target = FindClosestEnemyIndex(validAimbotEnemies, validPlayerCounter, playerVec);
				}
				else//By default aim at the first guy that appears, with this we focus on whos closest to us
					target = FindClosestEnemyIndex(validAimbotEnemies, validPlayerCounter, playerVec);
                 
				//if there are more enemies we find the closest one to us then aim
				if (target != -1) //-1 means something went wrong
				{
					dist = SubVectorDist(playerVec, validAimbotEnemies[target]).length() / 48;
					//needs to be called so certain vars are set for our aimsys
					WorldToScreen(validAimbotEnemies[target].VecCoords(), playerVec.VecCoords());
					//(FocusTarget)AS long as our hotkey is pressed we keep looking at the same guy,
					//if this wasn't here and you held down the hotkey button, if another enemy got closer to you than your 
					//current target then the aimbot would aim at the other guy.
					//This would be a problem if enemies keep moving around the aimbot is always locking into different people
					FocusTarget = target;
					if ((((validAimbotEnemies[target].pose & 0x08) != 0)) ||
						((validAimbotEnemies[target].pose & 0x100) != 0) ||
						((validAimbotEnemies[target].pose & 0x200) != 0))
					{
						drawx = 700.0f / dist;
						drawy = 400.0f / dist;
						ScreenY += 4.6f;
					}
					else
					{
						drawx = 400.0f / dist;
						drawy = 700.0f / dist;
					}

					//We find exacly where to draw including from our Window's e.g. 
					//if the window has been moved since our last loop
					int x = (int)(ScreenX);
					int y = (int)(ScreenY - drawy);

					//this condition is only here in case all enemies are dead to aim at NO one
					//previously if all were dead it would aim at the last guy killed
					if (validAimbotEnemies[target].health > 0)
					{
						//Incase the window is moved we need to grab window Rect again
						GetWindowRect(Handle, &WindowRect);
						//put our mouse on the enemy, WindowRect is grabbed on our constructor at the top
						//And this is optimized for Windowed Games but will work just fine on Non Windowed
						SetCursorPos((WindowRect.left)  + x, (WindowRect.top) + y);
					}
				}
			}
			//stopped pressing Hotkey aimbot, therefore we look for a new target as soon as its pressed again
			//if player leaves key held we keep aiming at the same target until hes dead or invalid
			else//otherwise we stop staring at them and change targets
				FocusTarget = -1;	
		}
	}
}


void ESP::DrawLine(float StartX, float StartY, float EndX, float EndY, D3DCOLOR dColor )
{
    S_Line[0].SetWidth( 1 ); 
    S_Line[0].SetGLLines( 0 ); 
    S_Line[0].SetAntialias( 1 ); 

    D3DXVECTOR2 v2Line[2]; 
    v2Line[0].x = StartX; 
    v2Line[0].y = StartY; 
    v2Line[1].x = EndX; 
    v2Line[1].y = EndY; 

    S_Line[0].Begin(); 
    S_Line[0].Draw( v2Line, 2, dColor ); 
    S_Line[0].End(); 
}












//Draw our ESP Hack
void ESP::DrawESPBox( int x, int y, int w, int h, int thickness, D3DCOLOR Colour, IDirect3DDevice9 *pDevice)
{
	//Top horiz line
	DrawFilledRect( x, y, w, thickness,  Colour, pDevice );
	//Left vertical line
	DrawFilledRect( x, y, thickness, h, Colour, pDevice );
	//right vertical line
	DrawFilledRect( (x + w), y, thickness, h, Colour, pDevice );
	//bottom horiz line
	DrawFilledRect( x, y + h, w+thickness, thickness, Colour, pDevice );
}

//We receive the 2-D Coordinates the colour and the device we want to use to draw those colours with
void ESP::DrawFilledRect(int x, int y, int w, int h, D3DCOLOR color, IDirect3DDevice9* dev)
{
	//We create our rectangle to draw on screen
	D3DRECT BarRect = { x, y, x + w, y + h }; 
	//We clear that portion of the screen and display our rectangle
	dev->Clear(1, &BarRect, D3DCLEAR_TARGET | D3DCLEAR_TARGET, color, 0, 0);
}



//Grabs our 3d Coordinates and changes them to 2d for us to play with
//---------------------------------------------------------------------------
bool ESP::WorldToScreen(Vect3d &WorldLocation, Vect3d &mypos)
{
    Vect3d vLocal, vTransForm;
	vForward = new Vect3d();
	vRight = new Vect3d();
	vUpward = new Vect3d();

    AngleVectors();
    vLocal = SubVectorDist(WorldLocation, mypos);

    vTransForm.x = vLocal.dotproduct(*vRight);
    vTransForm.y = vLocal.dotproduct(*vUpward);
    vTransForm.z = vLocal.dotproduct(*vForward);

    if (vTransForm.z < 0.01)
        return false;

    ScreenX = screencenter[0] + (screencenter[0] / vTransForm.z * (1 / fov[0])) * vTransForm.x;
    ScreenY = screencenter[1] - (screencenter[1] / vTransForm.z * (1 / fov[1])) * vTransForm.y;

    return true;
}

/// <summary>
/// One of Kn4cker's functions, this beauty does all our complex maths
/// if you want to know more about it get very comfortable with Pythagora
/// </summary>
void ESP::AngleVectors()
{
    float angle;
    float sr, sp, sy, cr, cp, cy, 
        cpi = (3.141f * 2 / 360);

    angle = viewAngles.y * cpi;
    //cpi = same view angles.x isn't

    sy = (float)sin(angle);
    cy = (float)cos(angle);
    angle = viewAngles.x * cpi;
    sp = (float)sin(angle);
    cp = (float)cos(angle);
    angle = viewAngles.z * cpi;
    sr = (float)sin(angle);
    cr = (float)cos(angle);

    vForward->x = cp * cy;
    vForward->y = cp * sy;
    vForward->z = -sp;


    vRight->x = (-1 * sr * sp * cy + -1 * cr * -sy);
    vRight->y = (-1 * sr * sp * sy + -1 * cr * cy);
    vRight->z = -1 * sr * cp;


    vUpward->x = (cr * sp * cy + -sr * -sy);
    vUpward->y = (cr * sp * sy + -sr * cy);
    vUpward->z = cr * cp;
}





