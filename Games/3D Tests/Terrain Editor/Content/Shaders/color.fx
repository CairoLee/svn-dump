float4x4 WorldViewProj : WorldViewProjection;
float4 color;

struct VS_INPUT
{
	float4 Position : POSITION0;
};

struct VS_OUTPUT
{
	float4 Position : POSITION0;
};

VS_OUTPUT Transform(VS_INPUT Input)
{
	VS_OUTPUT Output;
	
	Output.Position = mul(Input.Position, WorldViewProj);
	return Output;
}

struct PS_INPUT
{
	float2 Texcoord : TEXCOORD0;
};

float4 Texture(PS_INPUT Input) : COLOR0
{
	return color;
};

technique TransformTexture
{
	pass P0
	{
		VertexShader = compile vs_2_0 Transform();
		PixelShader = compile ps_2_0 Texture();
	}
}
