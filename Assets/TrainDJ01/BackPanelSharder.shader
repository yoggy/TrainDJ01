Shader "Custom/BackpanelSharder" {
	Properties {
	    _Alpha ("Alpha", Range (0, 1) ) = 1
	    _Alpha2 ("Alpha2", Range (0, 1) ) = 1
	    _Color ("Color", Color) = (1, 1, 1, 1)  
	}

    SubShader {
        Tags { "RenderType"="Transparent" "IgnoreProjector"="True" "Queue"="Transparent" }
        
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            uniform float _Alpha;
            uniform float _Alpha2;
            uniform float4 _Color;

			struct vertexInput {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
            };

            struct fragmentInput{
                float4 position : SV_POSITION;
                float4 texcoord0 : TEXCOORD0;
            };

            fragmentInput vert(vertexInput i){
                fragmentInput o;
                UNITY_INITIALIZE_OUTPUT(vertexInput, o);
                o.position = mul (UNITY_MATRIX_MVP, i.vertex);
                o.texcoord0.xy = i.texcoord0.xy;
                return o;
            }

            fixed4 frag(fragmentInput i) : COLOR {            
                return fixed4(_Color.rgb, _Alpha * _Alpha2);
            }
            ENDCG
        }
    }
}