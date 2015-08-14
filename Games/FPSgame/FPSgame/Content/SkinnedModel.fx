
#define MaxBones 59
float4x4 View;
float4x4 Projection;
float4x4 Bones[MaxBones];

float3 Light1Direction = normalize(float3(1, 1, 1));
float3 Light1Color = float3(0.9, 0.8, 0.7)*5;

float3 Light2Direction = normalize(float3(-1, -1, 1));
float3 Light2Color = float3(0.3, 0.3, 0.4)*2;

float3 AmbientColor = 0.5;

texture Texture;

float FogFar;
float FogNear;
float3 CameraPosition;
float3 FogColor;



sampler Sampler = sampler_state
{
    Texture = (Texture);

    MinFilter = Linear;
    MagFilter = Linear;
    MipFilter = Linear;
};



struct VS_INPUT
{
    float4 Position : POSITION0;
    float3 Normal : NORMAL0;
    float2 TexCoord : TEXCOORD0;
    float4 BoneIndices : BLENDINDICES0;
    float4 BoneWeights : BLENDWEIGHT0;
};


struct VS_OUTPUT
{
    float4 Position : POSITION0;
    float2 TexCoord : TEXCOORD0;
    float3 Normal : TEXCOORD2;
    float4 worldpos : TEXCOORD3;
};




float ComputeFogFactor(float d,float N,float F)
{
    return clamp((d - N) / (F - N), 0, 1);
}



VS_OUTPUT FuncVertexShader(VS_INPUT input)
{
    VS_OUTPUT output;
    

    float4x4 skinTransform = 0;
    
    skinTransform += Bones[input.BoneIndices.x] * input.BoneWeights.x;
    skinTransform += Bones[input.BoneIndices.y] * input.BoneWeights.y;
    skinTransform += Bones[input.BoneIndices.z] * input.BoneWeights.z;
    skinTransform += Bones[input.BoneIndices.w] * input.BoneWeights.w;
    

    float4 position = mul(input.Position, skinTransform);
    output.worldpos = mul(input.Position, skinTransform);
    output.Position = mul(mul(position, View), Projection);

    float3 normal = normalize(mul(input.Normal, skinTransform));
    output.Normal = normal;

    
    
    output.TexCoord = input.TexCoord;
    
    return output;
}


float4 FuncPixelShader(VS_OUTPUT input) : COLOR0
{
    float4 color = tex2D(Sampler, input.TexCoord);
    
    float3 light1 = max(dot(input.Normal, Light1Direction), 0) * Light1Color;
    float3 light2 = max(dot(input.Normal, Light2Direction), 0) * Light2Color;

    float3 Lighting = light1 + light2 + AmbientColor;
    color.rgb *= Lighting;
    
    
    float fog = ComputeFogFactor(length(CameraPosition - input.worldpos),FogNear,FogFar);

    
    return lerp(color, float4(FogColor,1), fog);
}


technique SkinnedModelTechnique
{
    pass SkinnedModelPass
    {
        VertexShader = compile vs_2_0 FuncVertexShader();
        PixelShader = compile ps_2_0 FuncPixelShader();
    }
}
