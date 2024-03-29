Shader "Unlit/TestFunctionTex2Dlod"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Line ("Texture", 2D) = "white" {}
        [Space(10)]
        _ColorB ("Color Background", Color) = (1, 1, 1, 1)
        _ColorT ("Color Tint", Color) = (1, 1, 1, 1)
        _Displacement ("Displacement", Range(0, 1)) = 1
        _RangeYBeAffect("RangeYBeAffect", Range(0, 2))=0.2
        _SpeedX("SpeedX", Range(0, 2))=0.2
        _SpeedY("SpeedY", Range(0, 2))=0.2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float2 uv_line : TEXCOORD1;
                float4 normal : NORMAL;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float2 uv_line : TEXCOORD1;
                float4 normal : TEXCOORD2;
            };
            
            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _Line;
            float4 _Line_ST;
            float4 _ColorB;
            float4 _ColorT;
            float _Displacement;
            float _RangeYBeAffect;
            float _SpeedX;
            float _SpeedY;

            v2f vert (appdata v)
            {
                v2f o;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv_line = TRANSFORM_TEX(v.uv_line, _Line);
                
                float displacement = tex2Dlod(_Line, float4(o.uv_line + _Time.y, 0, 0)).x;
                if(v.vertex.y>_RangeYBeAffect)
                {
                    v.vertex.x += displacement * _Displacement*_SpeedX;
                    v.vertex.y += displacement * _Displacement*_SpeedY;
                }
                o.vertex = UnityObjectToClipPos(v.vertex);     
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // cap -> tex2D and tex2Dlod- is similar - tex2Dlod only for detail more than
                return col;
            }
            ENDCG
        }
    }
}
