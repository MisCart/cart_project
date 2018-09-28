////////////////////////////////////////////
///// CameraPlay - by VETASOFT 2018    /////
////////////////////////////////////////////

Shader "CameraPlay/Pitch" { 
Properties 
{
_MainTex ("Base (RGB)", 2D) = "white" {}
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
uniform float _PosX;
uniform float _distortion;
uniform float _PosY;
uniform float _Fade;
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

};
v2f vert(appdata_t IN)
{
v2f OUT;
OUT.vertex = UnityObjectToClipPos(IN.vertex);
OUT.texcoord = IN.texcoord;

return OUT;
}
half4 _MainTex_ST;
float4 frag(v2f i) : COLOR
{
float2 uvst = UnityStereoScreenSpaceUVAdjust(i.texcoord, _MainTex_ST);
	float2 p = uvst.xy;
	
	float2 m = float2(_PosX, _PosY);
#if UNITY_SINGLE_PASS_STEREO
	p.x = fmod(p, 0.5);
#endif
	float2 d = p - m;
	float r = sqrt(dot(d, d));
	float power = 0.444289334 * (_Fade-0.01)*_distortion;
	float bind = m.y;
	float2 uv=float2(0,0);
	uv = m + normalize(d) * atan(r * -power * 10.0) * bind / atan(-power * bind * 10.0);
	float3 col = tex2D(_MainTex, float2(uv.x, uv.y)).xyz;
	return float4(col, 1.0);

}
ENDCG
}
}
}
