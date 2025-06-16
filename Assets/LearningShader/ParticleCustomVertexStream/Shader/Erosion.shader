Shader "Unlit/Erosion"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _ErodeTex ("Erode Texture", 2D) = "white" {}
        _EmberColor("Ember Color", Color)=(0,0,0,0)
        _CharColor("Char Color", Color)=(0,0,0,0)
        _Feather("Feather",Range(0,0.1))=0.05
        _EmberBoost("Ember Boost",Range(0,10))=0.05
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
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _EmberColor,_CharColor;
            sampler2D _ErodeTex;
            float _Feather,_EmberBoost;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv.xy = TRANSFORM_TEX(v.uv.xy, _MainTex);
                o.uv.z=v.uv.z;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv.xy);
                float cutoff=i.uv.z;
                fixed erode = tex2D(_ErodeTex, i.uv.xy).r;

                fixed3 emberArea=step(erode-_Feather,cutoff);
                emberArea=saturate(emberArea/fwidth(emberArea));
                fixed3 burntArea=smoothstep(erode-_Feather,erode+_Feather,cutoff);
                fixed3 emberColor=lerp(col,_EmberColor*_EmberBoost,emberArea);
                fixed3 color=lerp(col,emberColor,burntArea);
                fixed alpha=saturate(col.a-step(erode+_Feather,cutoff));

                return fixed4(color,alpha);
            }
            ENDCG
        }
    }
}
