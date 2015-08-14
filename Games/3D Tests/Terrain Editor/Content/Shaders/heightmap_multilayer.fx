float4x4 WorldViewProj : WORLDVIEWPROJECTION;
float4x4 World : WORLD;
float4x4 View : VIEW;

texture t0;
texture t1;
texture t2;
texture t3;
texture t4;
float t0scale;
float t1scale;
float t2scale;
float t3scale;
float t4scale;

bool bDrawDetail = true;

texture colormap;
texture lightMap;
texture normalMap;
texture decalMap;

float3 groundCursorPosition;
texture groundCursorTex;
int groundCursorSize;
bool bShowCursor;

float3 cameraPosition;
float3 cameraDirection;
float3 lightPosition;
float3 lightDirection;

bool bUseSun = true;
float3 sunColor = 1.0;
float3 ambientLight = 10.0;
float lightPower = 1.0;

sampler t0sampler = sampler_state {
   Texture = ( t0 );
   ADDRESSU = WRAP;
   ADDRESSV = WRAP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

sampler t1sampler = sampler_state {
   Texture = ( t1 );
   ADDRESSU = WRAP;
   ADDRESSV = WRAP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;   
};

sampler t2sampler = sampler_state {
   Texture = ( t2 );
   ADDRESSU = WRAP;
   ADDRESSV = WRAP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

sampler t3sampler = sampler_state {
   Texture = ( t3 );
   ADDRESSU = WRAP;
   ADDRESSV = WRAP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

sampler t4sampler = sampler_state {
   Texture = ( t4 );
   ADDRESSU = WRAP;
   ADDRESSV = WRAP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

sampler colormapSampler = sampler_state {
   Texture = ( colormap );
   ADDRESSU = CLAMP;
   ADDRESSV = CLAMP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

sampler LightMapSampler = sampler_state {
   Texture = ( lightMap );
   ADDRESSU = CLAMP;
   ADDRESSV = CLAMP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

sampler NormalMapSampler = sampler_state {
   Texture = ( normalMap );
   ADDRESSU = CLAMP;
   ADDRESSV = CLAMP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

sampler DecalMapSampler = sampler_state {
   Texture = ( decalMap );
   ADDRESSU = CLAMP;
   ADDRESSV = CLAMP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

sampler CursorSampler = sampler_state {
   Texture = ( groundCursorTex );
   ADDRESSU = CLAMP;
   ADDRESSV = CLAMP;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

struct VS_INPUT {
	float4 Position	: POSITION0;
	float3 Normal	: NORMAL0;
	float2 Texcoord	: TEXCOORD0;
};

struct VS_OUTPUT {
	float4 Position		: POSITION0;
	float2 Texcoord		: TEXCOORD0;
	float3 Normal		: TEXCOORD1;
	float3 Position3D	: TEXCOORD2;
};

void Transform( in VS_INPUT Input, out VS_OUTPUT Output )
{
	Output.Position = mul( Input.Position, WorldViewProj );
	Output.Position3D = mul( Input.Position, World );
	Output.Texcoord = Input.Texcoord;
	Output.Normal = Input.Normal;
}

struct PS_INPUT {
	float3 Position		: POSITION0;
	float2 Texcoord		: TEXCOORD0;
	float3 Normal		: TEXCOORD1;
	float3 Position3D	: TEXCOORD2;
};

struct PS_OUTPUT {
	float4 Color : COLOR0;
};

void Texture( in PS_INPUT Input, out PS_OUTPUT Output )
{	
	//--------------------
	// Color Distribution
	//--------------------
    float4 a = tex2D( colormapSampler, Input.Texcoord );
    
    float4 b = tex2D( t0sampler, Input.Texcoord * t0scale );
    
    float4 h = tex2D( t1sampler, Input.Texcoord * t1scale );
    float4 i = tex2D( t2sampler, Input.Texcoord * t2scale );
    float4 j = tex2D( t3sampler, Input.Texcoord * t3scale );
    float4 k = tex2D( t4sampler, Input.Texcoord * t4scale );

    // get colormap invert for each layer
    float4 oneminusx = 1.0 - a.x;
    float4 oneminusy = 1.0 - a.y;
    float4 oneminusz = 1.0 - a.z;
    float4 oneminusw = 1.0 - a.w;
    
    vector l = a.x * h + oneminusx * 1.0;
    vector m = a.y * i + oneminusy * l;
    vector n = a.z * j + oneminusz * m;
    vector o = a.w * k + oneminusw * n;

    // save the resulting pixel color ( o )
    float3 color = o;    
    
   	//Grayscale detail color
	float3 c  = ( b.r + b.g + b.b ) / 3.0;

	//-------------------
	// Per Pixel Lighting
	//-------------------
	float3 light = 1;
	if( bUseSun )
		light = dot( lightDirection, Input.Normal );

	//------------------------	
	// Calculate Output Color
	//------------------------	
	float3 ambientColor = 0;
	float3 diffuseColor = 0;
	float3 detailColor = 0;

	if( bDrawDetail )
	{
		//Detail normal lighting	
		//light = ( light + light * dot( c, lightDirection )) / 2.0;
		
		ambientColor = ( color * ambientLight + c * ambientLight ) / 3.0;
		diffuseColor = color * light * lightPower;
		detailColor = c * light * lightPower;

		Output.Color.rgb = max( ambientColor, ( diffuseColor + detailColor + ambientColor ) / 4.0 );
	} else {
		ambientColor = color * ambientLight;
		diffuseColor = color * light * lightPower;
		detailColor = c * light * lightPower;

		Output.Color.rgb = max( ambientColor, ( diffuseColor + ambientColor ) / 3.0 );
	}
		

	//-------------------
	// Ground Cursor
	//-------------------
	if( bShowCursor )	{
		float CursorScale = 40.0f;
		float4 CursorColor = tex2D( CursorSampler, ( Input.Texcoord * ( CursorScale / groundCursorSize )) - ( groundCursorPosition.xz * ( CursorScale / groundCursorSize )) + 0.5f );	
		Output.Color.rgb += CursorColor;
	}
	
	Output.Color.a = 1.0;
};

technique TransformTexture {
	pass P0 {
		VertexShader = compile vs_2_0 Transform( );
		PixelShader = compile ps_2_0 Texture( );
	}
}

technique TransformWireframe {
	pass P0 {
		VertexShader = compile vs_2_0 Transform( );
		PixelShader = compile ps_2_0 Texture( );
		FillMode = Wireframe;
	}
}

technique TransformTextureWireframe {
	pass P0 {
		VertexShader = compile vs_2_0 Transform( );
		PixelShader = compile ps_2_0 Texture( );
	}

	pass P1 {
		VertexShader = compile vs_2_0 Transform( );
		PixelShader = Null;
		FillMode = Wireframe;
	}
}
