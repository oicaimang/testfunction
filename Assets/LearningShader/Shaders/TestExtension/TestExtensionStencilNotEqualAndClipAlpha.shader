Shader "LearningShader/TestExtensionStencilNotEqualAndClipAlpha"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Stencil ("Stencil ID", Float) = 2
        _Color ("Tint", Color) = (1,1,1,1)
        _ClipAlpha ("ClipAlpha", Float) = 0.2
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Stencil
        {
            Ref [_Stencil]
            Comp NotEqual
            Pass Replace
        }
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
                float4 color    : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 color    : COLOR;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed _ClipAlpha;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color=v.color;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                half4 color = tex2D(_MainTex, i.uv);
                // color.rgb=_Color.rgb;
                // color.a*=_Color.a;
                clip (color.a - _ClipAlpha);
                return color;
            }
            ENDCG
        }
    }
}
