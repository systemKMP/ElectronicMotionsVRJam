Shader "b35.200/Post Processing" {
	
	Properties {
		_MainTex ("Framebuffer (set automatically)", 2D) = "" {}
				
		screenRatio ("Screen Ration (set via script)", Float) = 1.0
		random ("RANDOM", Float) = 0.0
		time ("TIIIEEEME", Float) = 0.0
	}
	
	SubShader {
	    Pass{
			ZTest Always Cull Off ZWrite Off
	  		Fog { Mode off }      
	  		
	        CGPROGRAM
// Upgrade NOTE: excluded shader from DX11, Xbox360, OpenGL ES 2.0 because it uses unsized arrays
//#pragma exclude_renderers d3d11 xbox360 gles

//	        #pragma exclude_renderers gles
	        #pragma target 3.0
	        #pragma fragment frag
	        #pragma vertex vert

	        uniform sampler2D _MainTex;
	        uniform float screenRatio;
	        uniform float random;
	        uniform float time;
	        
	        
	        
	        struct VSInput
			{
				float4 vertex : POSITION;
				float2 texCoord : TEXCOORD0;
			};
			
			struct VSOutput
			{
				float4 pos : POSITION;
				float2 texCoord : TEXCOORD0;
			};

	        VSOutput vert (VSInput input)
	        {
			    VSOutput output;
			    output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
			    output.texCoord = input.texCoord;
			    return output;
			}

			float2 toNDC(float2 uv) {
				return (uv * 2.0f+1) / float2(1.0f, screenRatio);
			}
			
			float2 fromNDC(float2 uv) {
				return (uv * float2(1.0f, screenRatio) * 0.5f-0.5f);
			}
				
	        float4 frag(VSOutput input) : COLOR
	        {
	        	float PIXEL_AMOUNT = 320;
	        	float RAND_AMOUNT = 3;
	        	float RAND_COLOR = 0.1f;
	        	float4 output;
				
				//float2 texC  =input.texCoord;
				float2 texC  =toNDC(input.texCoord);
//				if (texC.y > .5f)
//				{
//					texC.y=0.5f;
//				}
				
				
				

				// Pixelate stuff
				texC *= PIXEL_AMOUNT;
				
				texC.x = (int)(texC.x);
				texC.y = (int)(texC.y);
				
				//make a random number
				float rand = 0;
				rand = random*texC.x*random*texC.y*random;
				float absnum = abs(rand);
				rand = (((float)absnum)-((int)absnum)) * sign(rand) *RAND_AMOUNT;
				rand-=0.5f;
				
				//make Sin of screen
				float sinus = sin(texC.x+100*time);
				
				texC.x = (float)texC.x+rand;
				texC.y = (float)texC.y+rand;
				
				texC /= PIXEL_AMOUNT;
				
				texC  =fromNDC(texC);
				
//				float distance = length(float2(0.0f, 0.0f) - texC);
//				float relativeDistance = distance / sqrt(2.0f);
//				
				
				
//				if (texC.x >rand)
//				{
//					texC.x=rand;
//				}

				// chromatic aberation
				
//				int taps = 9;
//				float[] weightR = {0.1, 0.2, 0.4, 0.2, 0.1, 0, 0, 0, 0};
//				float[] weightG = {0, 0, 0.1, 0.2, 0.4, 0.2, 0.1, 0, 0};
//				float[] weightB = {0, 0, 0, 0, 0.1, 0.2, 0.4, 0.2, 0.1};
				
//				int taps = 5;
//				float[] weightR = {0.25, 0.5, 0.25, 0, 0};
//				float[] weightG = {0, 0.25, 0.5, 0.25, 0};
//				float[] weightB = {0, 0, 0.25, 0.5, 0.25};
//				
//				int taps = 3;
//				float[3] weightR = {1, 0, 0};
//				float[3] weightG = {0, 1, 0};
//				float[3] weightB = {0, 0, 1};
//				
//				float3 accumulator = float3(0, 0, 0);
//			
//				for (int i = 0; i < taps; i++) {
//				float offset  = 0;
//					//float offset = lerp(1, 1 - ditheredStrength * i, pow(relativeDistance, aberationPower));
//					float3 sample = tex2D(_MainTex, fromNDC(ndc * offset));
//					
//					accumulator.r += sample.r * weightR[i];
//					accumulator.g += sample.g * weightG[i];
//					accumulator.b += sample.b * weightB[i];
//				}
				
				float3 sample = tex2D(_MainTex, texC);
				output.rgb = sample;
				
//				output.r = output.r+sinus*RAND_COLOR;
				
	            output.a = 1;
	            return output;
	        }

	        ENDCG
	    }
	}
}