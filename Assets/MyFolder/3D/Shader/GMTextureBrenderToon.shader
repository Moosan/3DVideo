﻿// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/GMTextureBrenderToon" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white" {}
	_SubTex("Sub Texture", 2D) = "white" {} // 追加
	_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
#pragma target 3.0

		sampler2D _MainTex;
	sampler2D _SubTex; // 追加

	struct Input {
		float2 uv_MainTex;
	};

	half _Glossiness;
	half _Metallic;
	half _Blend; // 追加
	fixed4 _Color;

	// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
	// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
	// #pragma instancing_options assumeuniformscaling
	UNITY_INSTANCING_BUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf(Input IN, inout SurfaceOutputStandard o) {
		// Albedo comes from a texture tinted by color
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		fixed4 c2 = tex2D(_SubTex, IN.uv_MainTex) * _Color; // 
		fixed3 rgb;
		float h1,h2;
		float v1,v2;
		float s1,s2;
		float min1,min2;
		float max1,max2;
		float sa1,sa2;
		min1 = min(c.r,min(c.g,c.b)); 
		min2 = min(c2.r,min(c2.g,c2.b)); 
		max1 = max(c.r,max(c.g,c.b)); 
		max2 = max(c2.r,max(c2.g,c2.b)); 
		sa1 = max1 - min1;
		sa2 = max2 - min2;
		if(min1 == c.b)
		{
			h1 = 60.0 * (c.g - c.r) / sa1 + 60.0;
		}
		else if(min1 == c.r)
		{
			h1 = 60.0 * (c.b - c.g) / sa1 + 180.0;
		}
		else if(min1 == c.g)
		{
			h1 = 60.0 * (c.r - c.b) / sa1 + 300.0;
		}
		
		if(min2 == c.b)
		{
			h2 = 60.0 * (c2.g - c2.r) / sa2 + 60.0;
		}
		else if(min2 == c2.r)
		{
			h2 = 60.0 * (c2.b - c2.g) / sa2 + 180.0;
		}
		else if(min2 == c2.g)
		{
			h2 = 60.0 * (c2.r - c2.b) / sa2 + 300.0;
		}

		v1 = max1;
		v2 = max2;
		s1 = sa1;
		s2 = sa2;

		if(v1 < 0.2){
			v1 = 0.0;
		}
		else if(v1 < 0.4){
			v1 = 0.45;
		} 
		else if(v1 < 0.75){
			v1 = 0.7;
		}
		else{
			v1 = 1.0;
		}

		if(v2 < 0.2){
			v2 = 0.0;
		}
		else if(v2 < 0.4){
			v2 = 0.45;
		} 
		else if(v2 < 0.75){
			v2 = 0.7;
		}
		else{
			v2 = 1.0;
		}

		float x1,x2;

		x1 = s1 * (1 - abs(fmod(h1,2) - 1.0));
		x2 = s2 * (1 - abs(fmod(h2,2) - 1.0));
		fixed3 rgb1,rgb2;
		rgb1 = fixed3(v1-s1,v1-s1,v1-s1);
		rgb2 = fixed3(v2-s2,v2-s2,v2-s2);
		if(h1 >= 0 && h1 < 1)
		{
			rgb1 += fixed3(s1,x1,0);
		}
		else if(h1 >= 1 &&h1 < 2)
		{
			rgb1 += fixed3(x1,s1,0);
		}
		else if(h1 >= 2 && h1 < 3)
		{
			rgb1 += fixed3(0,s1,x1);
		}
		else if(h1 >= 3 && h1 < 4)
		{
			rgb1 += fixed3(0,x1,s1);
		}
		else if(h1 >= 4 && h1 < 5)
		{
			rgb1 += fixed3(x1,0,s1);
		}
		else if(h1 >= 5 &&h1 < 6)
		{
			rgb1 += fixed3(s1,0,x1);
		}
		
		if(h2 >= 0 && h2 < 1)
		{
			rgb2 += fixed3(s2,x2,0);
		}
		else if(h2 >= 1 &&h2 < 2)
		{
			rgb2 += fixed3(x2,s2,0);
		}
		else if(h2 >= 2 && h2 < 3)
		{
			rgb2 += fixed3(0,s2,x2);
		}
		else if(h2 >= 3 && h2 < 4)
		{
			rgb2 += fixed3(0,x2,s2);
		}
		else if(h2 >= 4 && h2 < 5)
		{
			rgb2 += fixed3(x2,0,s2);
		}
		else if(h2 >= 5 &&h2 < 6)
		{
			rgb2 += fixed3(s2,0,x2);
		}
		rgb.x = rgb1.x;
		rgb.y = rgb2.y;
		rgb.z = rgb1.z;
		o.Albedo = rgb; // 修正
												// Metallic and smoothness come from slider variables
		o.Metallic = _Metallic;
		o.Smoothness = _Glossiness;
		o.Alpha = c.a;
	}
	ENDCG
	}
		FallBack "Diffuse"
}
