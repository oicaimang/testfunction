Shader "Unlit/TurtorialShader"
{
    Properties
    {
        _MainTexure ("Main Texture", 2D) = "white" {}
        _AnimateXY("Animate XY", Vector)=(0,0,0,0)
        _Color("Color", Color)=(0,0,0,0)
        _ScaleXTexture("_ScaleTexture", Range(0,1000)) = 3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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
            };
           
            struct v2f
            {
                float2 uv : TEXCOORD0;
              
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTexure;
            float4 _MainTexure_ST;
            float4 _AnimateXY;
            float4 _Color;
            float _ScaleXTexture;
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv,_MainTexure);
                o.uv.xy+=frac(_AnimateXY.xy*_MainTexure_ST.xy*_Time.yy);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uvs =i.uv;
                uvs.x*=(int)_ScaleXTexture;
                fixed4 textureColor=tex2D(_MainTexure,uvs);
                if(textureColor.a==0)
                {
                    textureColor=_Color;
                }
                return textureColor;
            }
            ENDCG
        }
    }
}
