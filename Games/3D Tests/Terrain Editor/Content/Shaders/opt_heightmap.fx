float4x4 WorldViewProj : WORLDVIEWPROJECTION;
float4x4 World : WORLD;
float4x4 View : VIEW;

float4 color;

struct VS_INPUT
{
	float4 Position	: POSITION0;
	float3 Normal	: NORMAL0;
	float2 Texcoord	: TEXCOORD0;
};

struct VS_OUTPUT
{
	float4 Position		: POSITION0;
	float2 Texcoord		: TEXCOORD0;
	float3 Normal		: TEXCOORD1;
	float3 Position3D	: TEXCOORD2;
};

void Transform(in VS_INPUT Input, out VS_OUTPUT Output)
{
	Output.Position = mul(Input.Position, WorldViewProj);
	Output.Position3D = mul(Input.Position, World);
	Output.Texcoord = Input.Texcoord;
	Output.Normal = Input.Normal;
}

struct PS_INPUT
{
	float3 Position		: POSITION0;
	float2 Texcoord		: TEXCOORD0;
	float3 Normal		: TEXCOORD1;
	float3 Position3D	: TEXCOORD2;
};

struct PS_OUTPUT
{
	float4 Color : COLOR0;
};

void Texture(in PS_INPUT Input, out PS_OUTPUT Output)
{
	//Output.Color = color;
	Output.Color.rgb = (1,1,1) * Input.Normal;
	Output.Color.a = 1;
};

technique TransformTexture
{
	pass P0
	{
		VertexShader = compile vs_2_0 Transform();
		PixelShader = compile ps_2_0 Texture();
	}
}

technique TransformWireframe
{
	pass P0
	{
		VertexShader = compile vs_2_0 Transform();
		PixelShader = compile ps_2_0 Texture();
		FillMode = Wireframe;
	}
}

technique TransformTextureWireframe
{
	pass P0
	{
		VertexShader = compile vs_2_0 Transform();
		PixelShader = compile ps_2_0 Texture();
	}

	pass P1
	{
		VertexShader = compile vs_2_0 Transform();
		PixelShader = Null;
		FillMode = Wireframe;
	}
}
