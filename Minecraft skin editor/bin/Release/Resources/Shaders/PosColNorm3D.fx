float4x4 gWorld : WORLD;
float4x4 gWorldViewProj : WORLDVIEWPROJECTION; 
float3 gLightDirection = float3(-0.577f, -0.577f, 0.577f);

struct VS_INPUT{
	float3 pos : POSITION;
	float3 normal : NORMAL;
	float4 color : COLOR;
};

struct VS_OUTPUT{
	float4 pos : SV_POSITION;
	float4 color : COLOR;
	float3 normal : NORMAL;
};

SamplerState samLinear
{
    Filter = MIN_MAG_MIP_LINEAR;
    AddressU = Wrap;// or Mirror or Clamp or Border
    AddressV = Wrap;// or Mirror or Clamp or Border
};

RasterizerState Solid
{
	FillMode = SOLID;
	CullMode = NONE;
};

RasterizerState Wire
{
	FillMode = WIREFRAME;
	CullMode = NONE;
};


//--------------------------------------------------------------------------------------
// Vertex Shader
//--------------------------------------------------------------------------------------
VS_OUTPUT VS(VS_INPUT input){
	VS_OUTPUT output;
	// Step 1:	convert position into float4 and multiply with matWorldViewProj
	output.pos = mul ( float4(input.pos,1.0f), gWorldViewProj );
	// Step 2:	rotate the normal: NO TRANSLATION
	//			this is achieved by clipping the 4x4 to a 3x3 matrix, 
	//			thus removing the postion row of the matrix
	output.normal = mul(normalize(input.normal).xyz, (float3x3)gWorld);
	// Step3:	Just copy the color
	output.color=input.color;
	return output;
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 PS(VS_OUTPUT input) : SV_TARGET{

	input.normal = normalize(input.normal);
	float3 color_rgb= input.color.rgb;
	float color_a = input.color.a;
	
	//HalfLambert Diffuse :)
	float diffuseStrength = dot(input.normal, -gLightDirection);
	diffuseStrength = diffuseStrength * 0.5 + 0.5;
	diffuseStrength = saturate(diffuseStrength);

	color_rgb = color_rgb * diffuseStrength;
	
	return float4( color_rgb , color_a );
}

//--------------------------------------------------------------------------------------
// Technique
//--------------------------------------------------------------------------------------
technique10 SolidTech
{
    pass P0
    {
		SetRasterizerState(Solid);
        SetVertexShader( CompileShader( vs_4_0, VS() ) );
		SetGeometryShader( NULL );
        SetPixelShader( CompileShader( ps_4_0, PS() ) );
    }
}

technique10 WireTech
{
    pass P0
    {
		SetRasterizerState(Wire);
        SetVertexShader( CompileShader( vs_4_0, VS() ) );
		SetGeometryShader( NULL );
        SetPixelShader( CompileShader( ps_4_0, PS() ) );
    }
}

