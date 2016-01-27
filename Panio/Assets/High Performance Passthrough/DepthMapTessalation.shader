Shader "Unlit/TessalationDepthMap"
{
	Properties{
		_Tess("Tessellation", Range(1,32)) = 4
		_MainTex("Disp Texture", 2D) = "gray" {}
		_Displacement("Displacement", Range(0, 100.0)) = 0.3
		_Color("Color", color) = (1,1,1,0)
	}
	SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 300
	
		CGPROGRAM
		#pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp tessellate:tessFixed nolightmap
		#pragma target 5.0

		struct appdata {
			float4 vertex : POSITION;
			float4 tangent : TANGENT;
			float3 normal : NORMAL;
			float2 texcoord : TEXCOORD0;
		};

		float _Tess;

		float4 tessFixed()
		{
			return _Tess;
		}

		sampler2D _MainTex;
		float _Displacement;

		void disp(inout appdata v)
		{
			float d = tex2Dlod(_MainTex, float4(v.texcoord.xy,0,0)).r * _Displacement;
			v.vertex.xyz += v.normal * d;
		}

		struct Input {
			float2 uv_MainTex;
		};

		
		sampler2D _NormalMap;
		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color * tex2D(_MainTex, IN.uv_MainTex);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
