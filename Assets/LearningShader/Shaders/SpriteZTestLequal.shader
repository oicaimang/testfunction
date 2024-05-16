Shader "Unlit/SpriteZTestLEqual"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _FillColor ("Fill Color", Color) = (1,1,1,1)
		_FillAlpha ("Fill Alpha", Range (0,1)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull Off
		Lighting Off
		ZWrite On
		Blend One OneMinusSrcAlpha
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
                UNITY_FOG_COORDS(1)
                fixed4 color    : COLOR;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
			fixed4 _FillColor;
            float _FillAlpha;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv=v.uv;
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv)*i.color;
                col.rgb = lerp(col.rgb, _FillColor.rgb, _FillAlpha);
                col.rgb*=col.a;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;

                // fixed4 c = SampleSpriteTexture (IN.texcoord) * IN.color;
				// c.rgb = lerp(c.rgb, _FillColor.rgb, _FillAlpha);
				// c.rgb *= c.a;
				// return c;
            }
            ENDCG
        }
    }
}
