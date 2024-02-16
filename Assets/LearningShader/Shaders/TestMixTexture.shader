Shader "Quyet/MixTexture"
{
    Properties
    {
        _BaseTex ("BaseTex", 2D) = "white" {}
        _PlusTex("PlusTex", 2D)="white" {}
        _ScaleTexture("_ScaleTexture", Range(0.0,10.0)) = 0.1
        _ColorMulti("Color", Color) = (1,1,1,1)
        _TexFadePlus ("FadeTex", 2D) = "white" {}
        _ScaleFadePlus("Fade", Range(-0.1,1.0)) = 1
        _SpecularTex ("Specular Texture", 2D) = "black" {}  // add specular
        _SpecularInt ("Specular Intensity", Range(0, 5)) = 0.5
        _SpecularPow ("Specular Power", Range(1, 128)) = 64
        _Alpha ("Alpha", float)=0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 300
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

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
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 normal_world : TEXCOORD1;
                float3 vertex_world : TEXCOORD2;
            };

            sampler2D _BaseTex;
            float4 _BaseTex_ST;
            sampler2D _PlusTex;
            float4 _PlusTex_ST;
            float _ScaleTexture;
            fixed4 _ColorMulti;
            sampler2D _TexFadePlus;
            float _ScaleFadePlus;
            float4 _LightColor0;
            sampler2D _SpecularTex; 
            float _SpecularInt;
            float _SpecularPow;  
            float _Alpha;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _BaseTex);
                o.normal_world = UnityObjectToWorldNormal(v.normal);
                o.vertex_world = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }
            float3 SpecularShading
            (
                float3 colorRefl, 
                float specularInt, 
                float3 normal, 
                float3 lightDir, 
                float3 viewDir, 
                float specularPow
            )
            {     
                // h is the halfway vector
                float3 h = normalize(lightDir + viewDir);
                return colorRefl * specularInt * pow(max(0, dot(normal, h)), specularPow);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                half3 normal = i.normal_world;
                half3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
                half3 colorRefl = _LightColor0.rgb;
                half3 specCol = tex2D(_SpecularTex, i.uv) * colorRefl;
                half3 viewDir = normalize(_WorldSpaceCameraPos - i.vertex_world);
                float2 uvs=i.uv;
                uvs*=_ScaleTexture;
                fixed4 col1 = tex2D(_PlusTex, uvs);
                fixed4 col1White=tex2D(_TexFadePlus,uvs);
                fixed4 col2 = tex2D(_BaseTex, i.uv)*_ColorMulti;
                float reveal=step(col1.r,_ScaleFadePlus);
                fixed4 col1Total=fixed4(col1.rgb*reveal+col1White.rgb*(1-reveal),1);
                fixed4 col=col1Total*col2;
                half3 specular = SpecularShading(specCol, _SpecularInt, normal, lightDir, viewDir, _SpecularPow);
                col.rbg+=specular;
                UNITY_APPLY_FOG(i.fogCoord, col);
                return fixed4(col.rbg,col.a* _Alpha);
            }
            ENDCG
        }
    }
}
