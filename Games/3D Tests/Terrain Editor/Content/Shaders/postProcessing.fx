sampler samplerState;
float speed;

struct PS_INPUT 
{ 
    float2 TexCoord : TEXCOORD0; 
}; 

float4 bloomEffect(PS_INPUT Input) : COLOR0
{ 
    float2 coordinates = Input.TexCoord;
    float2 center = (0.5, 0.5);    
    float4 color = tex2D(samplerState, coordinates);

	if(length(color.r) > 0.8)
	{
		for(int x=0;x<6;x++)
		{
			coordinates.x += x * 0.0065;
			coordinates.y += 1.0 * 0.0065;
			color += tex2D(samplerState, coordinates);
		}

		color = color / 8.0;
	} 
	
	color.a = 1.0;
    return color;
}

float4 zoomEffect(PS_INPUT Input): COLOR0
{
	float4 color = tex2D(samplerState, Input.TexCoord);
	float2 center = (0.5, 0.5);
	
	for(int i=0; i<6; i++)
	{
		color += tex2D(samplerState, Input.TexCoord - (Input.TexCoord - center) * speed * i );
	}

	color = color / 6;
	
	color.a = 1.0;
	
	return color;
}

technique Bloom
{ 
    pass P0
    { 
        //PixelShader = compile ps_2_0 bloomEffect(); 
        PixelShader = compile ps_2_0 zoomEffect(); 
    } 
    
}