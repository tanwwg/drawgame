Shader "Custom/BrushShader" {
    Properties {
        _MainTex ("Base", 2D) = "white" {}
        _UV ("UV", Vector) = (0,0,0,0)
        _Color ("Color", Color) = (1,0,0,1)
        _Radius ("Radius", Float) = 0.05
        _Hardness ("Hardness", Float) = 0.1
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            sampler2D _MainTex;
            float4 _UV;
            float4 _Color;
            float _Radius;
            float _Hardness;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                float dist = distance(i.uv, _UV.xy);
                fixed4 col = tex2D(_MainTex, i.uv);

                // if (dist < _Radius)
                // {
                //     return lerp(_Color, col, _Hardness);
                // }
                // else
                // {
                //     return col;
                // }
                
                float alpha = step(_Radius, dist);
                return lerp(_Color, col, alpha);
            }
            ENDCG
        }
    }
}