Shader "Custom/LavaShader"
{
    Properties
    {
        _RampTex("Ramp Texture", 2D) = "white" {}
        _MainColor ("Main Colour", Color) = (1,0,0,1)
        _Strength("Strength", Range(0,2)) = 1.0
        _Speed("Speed", Range(-200,200)) = 100
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent"}

        Pass
        {

            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            sampler2D _RampTex;
            half4 _MainColor;
            float _Strength;
            float _Speed;


            uniform int _Length = 0;
            uniform half2 _Points[100];
            uniform fixed3 _Colors[100];

            struct Input {
                float4 uv_MainTex;
            };
            
            struct vertexInput {
                float4 vertex : POSITION;

            };

            struct vertexOutput {
                float4 pos : SV_POSITION;
            };

            vertexOutput vert (vertexInput IN) {
                vertexOutput o;

                float4 worldPos = mul(unity_ObjectToWorld, IN.vertex);

                float displacement = (cos(worldPos.y) + cos(worldPos.x + (_Speed * _Time)));
                worldPos.y = worldPos.y + (displacement * _Strength);

                o.pos = mul(UNITY_MATRIX_VP, worldPos);
                return o;
            }
            
            float4 frag (vertexOutput IN) : COLOR{  
                
                //half minDist = 10000; // (Infinity)
                //int minI = 0;
                //for (int i = 0; i < _Length; i++){
                //    half dist = distance(IN.pos.xy, _Points[i].xy);
                //    if (dist < minDist) {
                //        minDist = dist;
                //        minI = i;
                //    }
                //}
                //half4 color = tex2D(_RampTex, fixed2(minDist, 0.5));
                //color.a = 1;
                return _MainColor;
            }

            ENDCG
        }
        
    }
    Fallback "Diffuse"
}
