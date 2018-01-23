Shader "Custom/RedTone" {
	Properties{
		_MainTex("MainTex", 2D) = ""{}
	}

		SubShader{
		Pass{
		CGPROGRAM

#include "UnityCG.cginc"

#pragma vertex vert_img
#pragma fragment frag

		sampler2D _MainTex;

	fixed4 frag(v2f_img i) : COLOR{
		fixed4 c = tex2D(_MainTex, i.uv);
	float red = c.r;
	c.rgb = fixed3(red, 0, 0);
	return c;
	}

		ENDCG
	}
	}
}
