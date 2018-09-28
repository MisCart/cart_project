////////////////////////////////////////////
///// CameraPlay - by VETASOFT 2018    /////
////////////////////////////////////////////

Shader "CameraPlay/Glitch3" {
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		Texture2("Base (RGB)", 2D) = "white" {}
		_TimeX("Time", Range(0.0, 1.0)) = 1.0
		_Fade("_Fade", Range(0.0, 1.0)) = 1.0
		_ScreenResolution("_ScreenResolution", Vector) = (0.,0.,0.,0.)
	}
		SubShader
	{
		Pass
	{
			Cull Off ZWrite Off ZTest Always
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma fragmentoption ARB_precision_hint_fastest
#pragma target 3.0
#pragma glsl
#include "UnityCG.cginc"
	uniform sampler2D _MainTex;
	uniform sampler2D Texture2;
	uniform float _TimeX;
	uniform float _Fade;
	uniform float4 _ScreenResolution;
	struct appdata_t
	{
		float4 vertex   : POSITION;
		float4 color    : COLOR;
		float2 texcoord : TEXCOORD0;
	};
	struct v2f
	{
		float2 texcoord  : TEXCOORD0;
		float4 vertex   : SV_POSITION;
		float4 color : COLOR;
	};
	v2f vert(appdata_t IN)
	{
		v2f OUT;
		OUT.vertex = UnityObjectToClipPos(IN.vertex);
		OUT.texcoord = IN.texcoord;
		OUT.color = IN.color;
		return OUT;
	}

	

	half4 _MainTex_ST;
float4 frag(v2f i) : COLOR
{
float2 uvst = UnityStereoScreenSpaceUVAdjust(i.texcoord, _MainTex_ST);
	float2 uv = uvst*0.25;
	float tm = _Time.y*1;
	uv.x += floor(fmod(tm, 1.0) * 4) / 4;
	uv.y += (1 - floor(fmod(tm / 4, 1.0) * 8) / 4);
	float4 t2 = tex2D(Texture2, uv);
	tm *= 4;
	uv = uvst*0.25;
	uv.x += floor(fmod(tm, 1.0) * 5) / 5;
	uv.y += (1 - floor(fmod(tm / 5, 1.0) * 8) / 5);
	t2 += tex2D(Texture2, uv);
	float2 uv2 = float2(t2.r*0.02, t2.b*0.02);
	uv2 *= _Fade;
	float4 mt = tex2D(_MainTex, uvst + uv2);
	mt += t2*(0.25*_Fade);
	return mt;
	}
		ENDCG
	}
	}
}