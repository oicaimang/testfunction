Shader "Quyet/BGSprite"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" { }
        _BlurAmount ("Blur Amount", Range(0, 10)) = 5.0
        _CenterX("CenterX", Range(0.0,1)) = 0.5
        _CenterY("CenterY", Range(0.0,1)) = 0.5
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        ZWrite Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            uniform float _BlurAmount;
            uniform sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _CenterX;
            float _CenterY;
            
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
            
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float2 uvs=i.uv;
                uvs.x-=_CenterX;
                uvs.y-=_CenterY;
                float2 texSize = _MainTex_TexelSize.xy;
                half4 col = half4(0, 0, 0, 0);
                int blurRadius = _BlurAmount;
                
                // Simple box blur effect (sample pixels around the current pixel)
                for (int x = -blurRadius; x <= blurRadius; x++)
                {
                    for (int y = -blurRadius; y <= blurRadius; y++)
                    {
                        col += tex2D(_MainTex, uvs + float2(x * texSize.x, y * texSize.y));
                    }
                }
                
                col /= (blurRadius * 2 + 1) * (blurRadius * 2 + 1);
                return col;
            }
            ENDCG
        }
    }
}