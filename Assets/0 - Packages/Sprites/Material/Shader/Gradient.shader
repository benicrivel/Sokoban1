
Shader "Custom/Gradient" {
	Properties{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
		_ColorTop("Top", Color) = (1,1,1,1)
		_ColorBottom("Bottom", Color) = (1,1,1,1)
		_Gradient("Gradient", Range(0,1)) = 0.5
	}
		SubShader{
			Tags { "Queue" = "Background" }

			Pass {

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 3.0

				#include "UnityCG.cginc"

				fixed4 _ColorTop;
				fixed4 _ColorBottom;
				fixed _Gradient;

				float4 vert(appdata_base v) : POSITION {
					return UnityObjectToClipPos(v.vertex);
				}

				fixed4 frag(float4 sp:VPOS) : SV_Target {
					fixed r = min(_Gradient, 1 - _Gradient);

					#if !SHADER_API_METAL	// non-iOS
					return lerp(_ColorBottom, _ColorTop, smoothstep(_Gradient - r, _Gradient + r, sp.y / _ScreenParams.y));
					#else	// iOS
				// A dirty fix for the upside-down color issue on iOS
				return lerp(_ColorTop, _ColorBottom, smoothstep(_Gradient - r, _Gradient + r, sp.y / _ScreenParams.y));
				#endif
			}
			ENDCG
		}
		}
			Fallback "Unlit/Color"
}
