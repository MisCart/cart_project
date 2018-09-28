////////////////////////////////////////////
///// CameraPlay - by VETASOFT 2018    /////
////////////////////////////////////////////

Shader "CameraPlay/XRay" { 
Properties 
{
_MainTex ("Base (RGB)", 2D) = "white" {}
_TimeX ("Time", Range(0.0, 1.0)) = 1.0
_ScreenResolution ("_ScreenResolution", Vector) = (0.,0.,0.,0.)
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
uniform float _TimeX;
uniform float _Value;
uniform float _Value2;
uniform float _Value3;
uniform float _Value4;
uniform float _Intensity;
uniform float _Number;
uniform float4 Color;
	uniform float2 _MainTex_TexelSize;


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
float4 color    : COLOR;
};
v2f vert(appdata_t IN)
{
v2f OUT;
OUT.vertex = UnityObjectToClipPos(IN.vertex);
OUT.texcoord = IN.texcoord;
OUT.color = IN.color;
return OUT;
}



float4 Xray(float2 uv, float posx, float posy, float number, float speed)
{
	uv -= float2(posx,posy);
float dist = 1.;
float a1 = atan2(uv.y,uv.x) + 3.14;
a1 = a1 / 6.28;

a1+=_Time * speed;

if (fmod(a1 * number, 2.0) < 1)
{
  dist = 0.;   
}
return dist;
}

half4 _MainTex_ST;
float4 frag(v2f i) : COLOR
{
	float2 uvst = UnityStereoScreenSpaceUVAdjust(i.texcoord, _MainTex_ST);
	float2 uv = uvst;
	float2 uv2 = i.texcoord;
	
	#if UNITY_UV_STARTS_AT_TOP
	if (_MainTex_TexelSize.y < 0) uv.y = 1 - uv.y;
	#endif	
	float dist = Xray(uv2,_Value3,_Value4,_Number,_Value2);
	float4 v = tex2D(_MainTex,uvst);
	v = v + ((Color*dist)*_Intensity);
	return v;


}
ENDCG
}
}
}
