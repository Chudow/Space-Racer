
Shader "Custom/ShipShader"
{
	Properties
	{
		_Color("Albedo", Color) = (1,1,1,1)
		_Tex("Texture", 2D) = "white" {}
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM
		#pragma surface surf MyLight

		sampler2D _Tex;
		float4 _Color;

		half4 LightingMyLight(SurfaceOutput s, half3 lightDir, half atten)
		{
			half newAtten;
			float d = dot(s.Normal, lightDir) * atten;

			if (d > 0.9) newAtten = 1;
			else if (d > 0.8) newAtten = 0.8;
			//else if (d > 0.7) newAtten = 0.7;
			else if (d > 0.6) newAtten = 0.6;
			//else if (d > 0.5) newAtten = 0.5;
			//else if (d > 0.4) newAtten = 0.4;
			else if (d > 0.3) newAtten = 0.3;
			//else if (d > 0.2) newAtten = 0.2;
			else if (d > 0.1) newAtten = 0.1;
			else newAtten = 0;

			half4 c = half4(_LightColor0.xyzw * newAtten);//, 1);

			return c;
		}

		struct Input
		{
			float2 uv_Tex;
		};

		void surf(Input IN, inout SurfaceOutput o)
		{
			o.Albedo = _Color;
			//o.Albedo = float3(IN.uv_Tex.x, IN.uv_Tex.y, 0.5 + _SinTime.w * 0.5);
			//o.Alpha = 1;
		}

		//struct SurfaceOutput
		//{
		//	fixed3 Albedo;  // diffuse color
		//	fixed3 Normal;  // tangent space normal, if written
		//	fixed3 Emission;
		//	half Specular;  // specular power in 0..1 range
		//	fixed Gloss;    // specular intensity
		//	fixed Alpha;    // alpha for transparencies
		//};


		ENDCG
	}
	Fallback "Diffuse"

	
}







/*void LightingMyLight_GI(SurfaceOutput s, UnityGIInput data, inout UnityGI gi)
{

}

half4 LightingMyLight(SurfaceOutput s, half3 viewDir, UnityGI gi)
{
half4 c = half4(viewDir.xyz, 1);

return c;
}*/






