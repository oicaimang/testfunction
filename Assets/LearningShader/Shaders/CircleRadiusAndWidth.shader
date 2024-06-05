Shader "Quyet/CircleRadiusAndWidth"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Radius ("Radius", Range(0.0, 0.5)) = 0.3
        _Width ("Width", Range(0.0, 0.5)) = 0.1
        _Center ("Center", Range(0, 1)) = 0.5
        _Smooth ("Smooth", Range(0.0, 0.5)) = 0.01
        _Color ("Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        AlphaToMask On
        Tags { "RenderType"="Transparency" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float _Radius;
            float _Width;
            float _Center;
            float _Smooth;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            float circle (float2 p, float center, float radius, float smooth)
            {
                float c = length(p - center);
                return smoothstep(c - smooth, c + smooth, radius);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                // fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                // UNITY_APPLY_FOG(i.fogCoord, col);
                float c = circle(i.uv, _Center, _Radius, _Smooth);
                float cIn= circle(i.uv, _Center, _Radius-_Width, _Smooth);
                if(i.uv.x<=cIn)
                {
                    return 0;
                }
                else
                {
                    fixed4 col = tex2D(_MainTex, c.xx);
                    col*=_Color;
                    return fixed4(col.rbg,c.x);
                }
            }
            ENDCG
        }
    }
}
