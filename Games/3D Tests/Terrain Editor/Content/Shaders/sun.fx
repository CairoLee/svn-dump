float4x4 WorldViewProj : WorldViewProjection;
texture Material;
float Alpha;
float glow;

sampler TextureSampler = sampler_state
{
   Texture = (Material);
   ADDRESSU = CLAMP;
   ADDRESSV = CLAMP;
   MIPFILTER = LINEAR; 
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
   MIPFILTER = LINEAR;
};

struct VS_INPUT
{
	float4 Position		: POSITION0;
	float2 Texcoord		: TEXCOORD0;
	float3 Normal		: TEXCOORD1;
};

struct VS_OUTPUT
{
	float4 Position		: POSITION0;
	float2 Texcoord		: TEXCOORD0;
	float3 Normal		: TEXCOORD1;
};

VS_OUTPUT Transform(VS_INPUT Input)
{
	VS_OUTPUT Output;
	
	Output.Position = mul(Input.Position, WorldViewProj);
	Output.Texcoord = Input.Texcoord;
	Output.Normal = Input.Normal;
	return Output;
}

struct PS_INPUT
{
	float2 Texcoord		: TEXCOORD0;
	float3 Normal		: TEXCOORD1;
};

float4 Texture(PS_INPUT Input) : COLOR0
{
	float4 FinalColor = tex2D(TextureSampler, Input.Texcoord);	
	FinalColor.rgb += (1.0 - FinalColor.a) / 2;
	FinalColor.rgb += glow;
			
	return FinalColor * Alpha;
	
};

technique TransformTexture
{
	pass P0
	{
		AlphaBlendEnable = true;
        SrcBlend = SrcAlpha;
        DestBlend = InvSrcAlpha;
		VertexShader = compile vs_2_0 Transform();
		PixelShader = compile ps_2_0 Texture();
	}
}
