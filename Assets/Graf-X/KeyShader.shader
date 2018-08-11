
Shader "Custom/KeyShader"
{
	Properties
	{
		_MainTex("Yooo", Color) = (1,1,1,1)
		_PlayerPos("PlayerPos", Color) = (1,1,1,1)
		PulseDist("Pulse distance", Range(0,1)) = 0
	}
	SubShader
	{
		
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float4 _MainTex;
			float4 _PlayerPos;
			float PulseDist;
			
			v2f vert (appdata v)
			{
				v2f o;

				//v.vertex.xyz += v.normal.xyz * 0.3 * sin(v.vertex.y * 32) * _SinTime.w;
				v.vertex.xz += v.normal.xz * (abs(v.vertex.y) - 0.5) * sin(v.vertex.y * 1.5) * _SinTime.w;

				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				//float4 col = float4(0.2 + clamp(0.9 * lerp(0, 1, sin(_Time.w + 2)), 0, 1), 0.2 * lerp(0, 1, _SinTime.w), 0.2 + clamp(0.9 * lerp(0, 1, _SinTime.w), 0, 1), 1);
				float4 col = float4(i.uv.y, 0, 1 - i.uv.y, 1);
				
				fixed4 OUT = col;

				return OUT;
			}
			ENDCG
		}
	}
}
