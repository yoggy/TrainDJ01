Shader "Custom/MovieSharder" {
	Properties {
	    _Alpha ("Alpha", Range (0, 1) ) = 1
	    _Alpha2 ("Alpha2", Range (0, 1) ) = 1
	    _MainTex ("Texture", 2D) = "white" { }   
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
            uniform sampler2D _MainTex;

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
                o.texcoord0.x = 1.0 - i.texcoord0.x;
                o.texcoord0.y = i.texcoord0.y;
                return o;
            }

            fixed4 frag(fragmentInput i) : COLOR {            
            	fixed4 color = tex2D(_MainTex, float2(i.texcoord0.x, i.texcoord0.y));
            	
                return fixed4(color.rgb, _Alpha * _Alpha2);
            }
            ENDCG
        }
    }
}