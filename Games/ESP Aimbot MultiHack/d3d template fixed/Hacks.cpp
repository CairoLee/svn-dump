#include "hacks.h";


/*--------------Colour RELATED VARS-------------------*/

int MenuIndex = 0;

// Create a colour for the text 
D3DCOLOR fontRed = D3DCOLOR_ARGB(255, 255, 0, 0);  
D3DCOLOR fontGreen = D3DCOLOR_ARGB(255, 0, 255, 0);    
D3DCOLOR fontBlue = D3DCOLOR_ARGB(255, 0, 42, 255);    
D3DCOLOR fontWhite = D3DCOLOR_ARGB(255, 255, 255, 255);  
D3DCOLOR fontBlack = D3DCOLOR_ARGB(255, 0, 0, 0);  
/*---------------------------------------------------*/


void Hacks::CreateFont(IDirect3DDevice9 *d3dDevice, std::string choiceFont)
{
	D3DXCreateFont( d3dDevice, 20, 0, FW_BOLD, 0, FALSE, DEFAULT_CHARSET, 
			OUT_DEFAULT_PRECIS, DEFAULT_QUALITY, DEFAULT_PITCH | FF_DONTCARE, 
			choiceFont.c_str(), &m_font );
}

void Hacks::InitializeMenuItems()
{
	hack[ESP_BOX_NAME].name = "ESP Box";
	hack[ESP_HEALTH].name = "ESP Health";
	hack[ESP_DISTANCE].name = "ESP Name + Distance";
	hack[SNAP_LINE].name = "Snap Line";
	hack[AIMBOT_HK].name = "Aimbot[Mouse 2]";
	hack[HIDE_MENU].name = " Hide hack [INSERT]";
	//make the hack visible by default
	hack[HIDE_MENU].on = false; //shows hack by default
}


void Hacks::DrawMenu(IDirect3DDevice9 *d3dDevice)
{
	if(!hack[HIDE_MENU].on)
	{
		//Add game name here, and put border around it
		Drawing::DrawFilledRect( 55, 20, 200, 50, fontBlue, d3dDevice );
		Drawing::DrawBorderBox(55, 20, 200, 50, 4, fontBlack, d3dDevice );
		Drawing::Draw_Text("COD 4 MP hack", 190, 30, fontWhite, m_font);

		//draw back of our hack, transparent black
		Drawing::DrawFilledRect( 30, 55, 250, (62*MAX_MENU_ITEMS),fontBlue, d3dDevice );
		//draw hack border
		Drawing::DrawBorderBox(30, 55, 250, (62*MAX_MENU_ITEMS), 6/*was 6*/, fontBlack, d3dDevice );
		//Reset our time and update the text again in 2 secs
		int y = 40;
		for(int i = 0; i < MAX_MENU_ITEMS; i ++)
		{
			//Draw each box's back colour, this will be based on whether the hack is on e.g.
			//red means off and green means on
			Drawing::DrawFilledRect( 45, 30+y, 220, 40, hack[i].on ? fontGreen : fontRed, d3dDevice );

			//draw box Around Each hack item If the item is highlighted it will show with a white border
			Drawing::DrawBorderBox(45, 30+y, 220, 40, 4, fontBlack, d3dDevice );

			//draw White border to show the user which hack item is currently selected
			if(MenuIndex == i)
			{
				Drawing::DrawBorderBox(41, 26+y, 228, 48, 4, fontWhite, d3dDevice );
			}

			//Ternary at its finest, if the  hack is on we display the text colour in green
			//otherwise its green
			//Draw_Text(hack[i].KeyAssigned.c_str(), 160 , 32+y, fontWhite);
			Drawing::Draw_Text(hack[i].name.c_str(), 170 , 39+y, fontBlack, m_font);
			//Draw_Text(hack[i].state. c_str(), 355 , 32+y, hack[i].on ? fontGreen : fontRed);
			//used to position the next item below by 30 height units
			y+= 50;
		}
		Drawing::Draw_Text("Select using arrow keys", 170, ((62*MAX_MENU_ITEMS)+7), fontWhite, m_font);
		Drawing::Draw_Text("Turn ON/OFF [END] key", 170, ((62*MAX_MENU_ITEMS)+27), fontWhite, m_font);
	}
}




void Hacks::KeyboardInput()
{
	if(GetAsyncKeyState(VK_UP)&1)
	{
		if(MenuIndex > 0)
		{
			MenuIndex--;
		}
	}

	if(GetAsyncKeyState(VK_DOWN)&1)
	{
		if(MenuIndex < MAX_MENU_ITEMS-1)
		{
			MenuIndex++;
		}
	}

	if(GetAsyncKeyState(VK_END)&1)
	{
		hack[MenuIndex].on = !hack[MenuIndex].on;
		if(MenuIndex == ESP_DISTANCE)
		{
			//this is where we write memory, these are nop values
		}
		if(MenuIndex == SNAP_LINE)
		{
			//this is where we write memory
		}
	}

	if(GetAsyncKeyState(VK_INSERT)&1)
	{
		//TEXT DOESNT CHANGE as the hack is either hidden or not 
		//and if its hidden you cant tell the user to turn hack on(at least we wont)
		hack[HIDE_MENU].on = !hack[HIDE_MENU].on;
	}
}


