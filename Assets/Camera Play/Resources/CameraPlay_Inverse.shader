////////////////////////////////////////////
///// CameraPlay - by VETASOFT 2018    /////
////////////////////////////////////////////

Shader "CameraPlay/Inverse" {
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
#include "UnityCG.cginc"


uniform sampler2D _MainTex;
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


half4 _MainTex_ST;
float4 frag(v2f i) : COLOR
{
float2 uvst = UnityStereoScreenSpaceUVAdjust(i.texcoord, _MainTex_ST);
float3 txt = tex2D(_MainTex, uvst.xy).rgb;
float3 Inverse = 1-txt;
Inverse = lerp(txt, Inverse, _Fade);
return float4(Inverse, 1);

}

ENDCG
}

}
}