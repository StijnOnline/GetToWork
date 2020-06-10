// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-6335-OUT,alpha-7655-OUT,voffset-9780-OUT,tess-3906-OUT;n:type:ShaderForge.SFN_Color,id:1304,x:31101,y:31875,ptovrint:False,ptlb:Color Base,ptin:_ColorBase,varname:node_1304,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:3906,x:32154,y:33436,ptovrint:False,ptlb:Tessellation Value,ptin:_TessellationValue,varname:node_542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1,max:30;n:type:ShaderForge.SFN_TexCoord,id:2787,x:29084,y:32738,varname:node_2787,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:4732,x:29897,y:32890,varname:node_4732,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7232-OUT;n:type:ShaderForge.SFN_Clamp01,id:6786,x:31734,y:33007,varname:node_6786,prsc:2|IN-6005-OUT;n:type:ShaderForge.SFN_Multiply,id:778,x:30129,y:32869,varname:node_778,prsc:2|A-336-OUT,B-4732-OUT,C-413-OUT;n:type:ShaderForge.SFN_Sin,id:8158,x:30316,y:32869,varname:node_8158,prsc:2|IN-778-OUT;n:type:ShaderForge.SFN_RemapRange,id:6005,x:31535,y:33007,varname:node_6005,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-2466-OUT;n:type:ShaderForge.SFN_Tau,id:413,x:29930,y:33041,varname:node_413,prsc:2;n:type:ShaderForge.SFN_Add,id:7232,x:29740,y:32890,varname:node_7232,prsc:2|A-3632-UVOUT,B-7438-OUT;n:type:ShaderForge.SFN_Time,id:7289,x:29241,y:32978,varname:node_7289,prsc:2;n:type:ShaderForge.SFN_Slider,id:5396,x:29084,y:33121,ptovrint:False,ptlb:SpeedWaves,ptin:_SpeedWaves,varname:node_6157,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:50;n:type:ShaderForge.SFN_Multiply,id:7438,x:29489,y:33023,varname:node_7438,prsc:2|A-7289-TSL,B-5396-OUT;n:type:ShaderForge.SFN_NormalVector,id:3154,x:31734,y:33127,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9780,x:31946,y:33079,varname:node_9780,prsc:2|A-6786-OUT,B-3154-OUT,C-6671-OUT;n:type:ShaderForge.SFN_Slider,id:336,x:29740,y:32818,ptovrint:False,ptlb:Waves Density,ptin:_WavesDensity,varname:node_2502,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Slider,id:6671,x:31577,y:33288,ptovrint:False,ptlb:Waves High,ptin:_WavesHigh,varname:node_3183,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-2,cur:0,max:2;n:type:ShaderForge.SFN_Rotator,id:3632,x:29489,y:32807,varname:node_3632,prsc:2|UVIN-2787-UVOUT,ANG-939-OUT;n:type:ShaderForge.SFN_Slider,id:939,x:29084,y:32898,ptovrint:False,ptlb:Wave Angle,ptin:_WaveAngle,varname:node_6342,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:6.5;n:type:ShaderForge.SFN_Tex2dAsset,id:6500,x:30893,y:32051,ptovrint:False,ptlb:Flag Texture,ptin:_FlagTexture,varname:node_6500,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4200,x:31101,y:32013,varname:node_4200,prsc:2,ntxv:0,isnm:False|TEX-6500-TEX;n:type:ShaderForge.SFN_Multiply,id:1806,x:31295,y:31971,varname:node_1806,prsc:2|A-1304-RGB,B-4200-RGB;n:type:ShaderForge.SFN_Tex2d,id:7205,x:32144,y:32882,ptovrint:False,ptlb:Opacity Texture,ptin:_OpacityTexture,varname:node_7205,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:8771,x:31987,y:32796,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_8771,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:7655,x:32323,y:32865,varname:node_7655,prsc:2|A-8771-OUT,B-7205-R;n:type:ShaderForge.SFN_Tex2d,id:5909,x:30129,y:33058,ptovrint:False,ptlb:Waves Pattern,ptin:_WavesPattern,varname:node_5909,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1112,x:30780,y:33132,varname:node_1112,prsc:2|A-8158-OUT,B-9380-OUT;n:type:ShaderForge.SFN_Add,id:1329,x:30780,y:32872,varname:node_1329,prsc:2|A-8158-OUT,B-9380-OUT;n:type:ShaderForge.SFN_Multiply,id:1265,x:31017,y:32872,varname:node_1265,prsc:2|A-1329-OUT,B-1112-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:9380,x:30567,y:33132,ptovrint:False,ptlb:Use Pattern,ptin:_UsePattern,varname:node_9380,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-8158-OUT,B-6094-OUT;n:type:ShaderForge.SFN_Slider,id:5907,x:29972,y:33233,ptovrint:False,ptlb:Pattern Power,ptin:_PatternPower,varname:node_5907,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:10,max:20;n:type:ShaderForge.SFN_Power,id:6094,x:30337,y:33132,varname:node_6094,prsc:2|VAL-5909-RGB,EXP-5907-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:2466,x:31316,y:33007,ptovrint:False,ptlb:Turbulence,ptin:_Turbulence,varname:node_2466,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-1112-OUT,B-1265-OUT;n:type:ShaderForge.SFN_Tex2d,id:3743,x:31101,y:32373,ptovrint:False,ptlb:Logo Texture,ptin:_LogoTexture,varname:node_3743,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:5049,x:31557,y:32144,varname:node_5049,prsc:2|A-1806-OUT,B-3687-OUT;n:type:ShaderForge.SFN_Tex2d,id:4893,x:31311,y:32721,ptovrint:False,ptlb:Dirty Texture,ptin:_DirtyTexture,varname:node_4893,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:9557,x:31101,y:32218,ptovrint:False,ptlb:Color Logo,ptin:_ColorLogo,varname:_ColorBase_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:3687,x:31312,y:32299,varname:node_3687,prsc:2|A-9557-RGB,B-3743-RGB;n:type:ShaderForge.SFN_Color,id:2590,x:31307,y:32553,ptovrint:False,ptlb:Color Dirty,ptin:_ColorDirty,varname:_ColorLogo_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:9661,x:31566,y:32636,varname:node_9661,prsc:2|A-2590-RGB,B-4893-RGB;n:type:ShaderForge.SFN_Add,id:6335,x:31874,y:32334,varname:node_6335,prsc:2|A-5049-OUT,B-9661-OUT;proporder:3906-5396-336-6671-939-9380-2466-5907-8771-1304-6500-3743-9557-4893-2590-7205-5909;pass:END;sub:END;*/

Shader "ORIS/Flag" {
    Properties {
        _TessellationValue ("Tessellation Value", Range(1, 30)) = 1
        _SpeedWaves ("SpeedWaves", Range(0, 50)) = 0
        _WavesDensity ("Waves Density", Range(0, 5)) = 0
        _WavesHigh ("Waves High", Range(-2, 2)) = 0
        _WaveAngle ("Wave Angle", Range(0, 6.5)) = 0
        [MaterialToggle] _UsePattern ("Use Pattern", Float ) = 0
        [MaterialToggle] _Turbulence ("Turbulence", Float ) = 0
        _PatternPower ("Pattern Power", Range(-10, 20)) = 10
        _Opacity ("Opacity", Range(0, 1)) = 1
        _ColorBase ("Color Base", Color) = (1,1,1,1)
        _FlagTexture ("Flag Texture", 2D) = "white" {}
        _LogoTexture ("Logo Texture", 2D) = "white" {}
        _ColorLogo ("Color Logo", Color) = (0,0,0,1)
        _DirtyTexture ("Dirty Texture", 2D) = "white" {}
        _ColorDirty ("Color Dirty", Color) = (0,0,0,1)
        _OpacityTexture ("Opacity Texture", 2D) = "white" {}
        _WavesPattern ("Waves Pattern", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float4 _LightColor0;
            uniform float4 _ColorBase;
            uniform float _TessellationValue;
            uniform float _SpeedWaves;
            uniform float _WavesDensity;
            uniform float _WavesHigh;
            uniform float _WaveAngle;
            uniform sampler2D _FlagTexture; uniform float4 _FlagTexture_ST;
            uniform sampler2D _OpacityTexture; uniform float4 _OpacityTexture_ST;
            uniform float _Opacity;
            uniform sampler2D _WavesPattern; uniform float4 _WavesPattern_ST;
            uniform fixed _UsePattern;
            uniform float _PatternPower;
            uniform fixed _Turbulence;
            uniform sampler2D _LogoTexture; uniform float4 _LogoTexture_ST;
            uniform sampler2D _DirtyTexture; uniform float4 _DirtyTexture_ST;
            uniform float4 _ColorLogo;
            uniform float4 _ColorDirty;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_3632_ang = _WaveAngle;
                float node_3632_spd = 1.0;
                float node_3632_cos = cos(node_3632_spd*node_3632_ang);
                float node_3632_sin = sin(node_3632_spd*node_3632_ang);
                float2 node_3632_piv = float2(0.5,0.5);
                float2 node_3632 = (mul(o.uv0-node_3632_piv,float2x2( node_3632_cos, -node_3632_sin, node_3632_sin, node_3632_cos))+node_3632_piv);
                float4 node_7289 = _Time;
                float node_8158 = sin((_WavesDensity*(node_3632+(node_7289.r*_SpeedWaves)).r*6.28318530718));
                float4 _WavesPattern_var = tex2Dlod(_WavesPattern,float4(TRANSFORM_TEX(o.uv0, _WavesPattern),0.0,0));
                float3 _UsePattern_var = lerp( node_8158, pow(_WavesPattern_var.rgb,_PatternPower), _UsePattern );
                float3 node_1112 = (node_8158*_UsePattern_var);
                v.vertex.xyz += (saturate((lerp( node_1112, ((node_8158+_UsePattern_var)*node_1112), _Turbulence )*0.5+0.5))*v.normal*_WavesHigh);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _TessellationValue;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 node_4200 = tex2D(_FlagTexture,TRANSFORM_TEX(i.uv0, _FlagTexture));
                float4 _LogoTexture_var = tex2D(_LogoTexture,TRANSFORM_TEX(i.uv0, _LogoTexture));
                float4 _DirtyTexture_var = tex2D(_DirtyTexture,TRANSFORM_TEX(i.uv0, _DirtyTexture));
                float3 diffuseColor = (((_ColorBase.rgb*node_4200.rgb)+(_ColorLogo.rgb*_LogoTexture_var.rgb))+(_ColorDirty.rgb*_DirtyTexture_var.rgb));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float4 _OpacityTexture_var = tex2D(_OpacityTexture,TRANSFORM_TEX(i.uv0, _OpacityTexture));
                fixed4 finalRGBA = fixed4(finalColor,(_Opacity*_OpacityTexture_var.r));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float4 _LightColor0;
            uniform float4 _ColorBase;
            uniform float _TessellationValue;
            uniform float _SpeedWaves;
            uniform float _WavesDensity;
            uniform float _WavesHigh;
            uniform float _WaveAngle;
            uniform sampler2D _FlagTexture; uniform float4 _FlagTexture_ST;
            uniform sampler2D _OpacityTexture; uniform float4 _OpacityTexture_ST;
            uniform float _Opacity;
            uniform sampler2D _WavesPattern; uniform float4 _WavesPattern_ST;
            uniform fixed _UsePattern;
            uniform float _PatternPower;
            uniform fixed _Turbulence;
            uniform sampler2D _LogoTexture; uniform float4 _LogoTexture_ST;
            uniform sampler2D _DirtyTexture; uniform float4 _DirtyTexture_ST;
            uniform float4 _ColorLogo;
            uniform float4 _ColorDirty;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_3632_ang = _WaveAngle;
                float node_3632_spd = 1.0;
                float node_3632_cos = cos(node_3632_spd*node_3632_ang);
                float node_3632_sin = sin(node_3632_spd*node_3632_ang);
                float2 node_3632_piv = float2(0.5,0.5);
                float2 node_3632 = (mul(o.uv0-node_3632_piv,float2x2( node_3632_cos, -node_3632_sin, node_3632_sin, node_3632_cos))+node_3632_piv);
                float4 node_7289 = _Time;
                float node_8158 = sin((_WavesDensity*(node_3632+(node_7289.r*_SpeedWaves)).r*6.28318530718));
                float4 _WavesPattern_var = tex2Dlod(_WavesPattern,float4(TRANSFORM_TEX(o.uv0, _WavesPattern),0.0,0));
                float3 _UsePattern_var = lerp( node_8158, pow(_WavesPattern_var.rgb,_PatternPower), _UsePattern );
                float3 node_1112 = (node_8158*_UsePattern_var);
                v.vertex.xyz += (saturate((lerp( node_1112, ((node_8158+_UsePattern_var)*node_1112), _Turbulence )*0.5+0.5))*v.normal*_WavesHigh);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _TessellationValue;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 node_4200 = tex2D(_FlagTexture,TRANSFORM_TEX(i.uv0, _FlagTexture));
                float4 _LogoTexture_var = tex2D(_LogoTexture,TRANSFORM_TEX(i.uv0, _LogoTexture));
                float4 _DirtyTexture_var = tex2D(_DirtyTexture,TRANSFORM_TEX(i.uv0, _DirtyTexture));
                float3 diffuseColor = (((_ColorBase.rgb*node_4200.rgb)+(_ColorLogo.rgb*_LogoTexture_var.rgb))+(_ColorDirty.rgb*_DirtyTexture_var.rgb));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float4 _OpacityTexture_var = tex2D(_OpacityTexture,TRANSFORM_TEX(i.uv0, _OpacityTexture));
                fixed4 finalRGBA = fixed4(finalColor * (_Opacity*_OpacityTexture_var.r),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float _TessellationValue;
            uniform float _SpeedWaves;
            uniform float _WavesDensity;
            uniform float _WavesHigh;
            uniform float _WaveAngle;
            uniform sampler2D _WavesPattern; uniform float4 _WavesPattern_ST;
            uniform fixed _UsePattern;
            uniform float _PatternPower;
            uniform fixed _Turbulence;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float node_3632_ang = _WaveAngle;
                float node_3632_spd = 1.0;
                float node_3632_cos = cos(node_3632_spd*node_3632_ang);
                float node_3632_sin = sin(node_3632_spd*node_3632_ang);
                float2 node_3632_piv = float2(0.5,0.5);
                float2 node_3632 = (mul(o.uv0-node_3632_piv,float2x2( node_3632_cos, -node_3632_sin, node_3632_sin, node_3632_cos))+node_3632_piv);
                float4 node_7289 = _Time;
                float node_8158 = sin((_WavesDensity*(node_3632+(node_7289.r*_SpeedWaves)).r*6.28318530718));
                float4 _WavesPattern_var = tex2Dlod(_WavesPattern,float4(TRANSFORM_TEX(o.uv0, _WavesPattern),0.0,0));
                float3 _UsePattern_var = lerp( node_8158, pow(_WavesPattern_var.rgb,_PatternPower), _UsePattern );
                float3 node_1112 = (node_8158*_UsePattern_var);
                v.vertex.xyz += (saturate((lerp( node_1112, ((node_8158+_UsePattern_var)*node_1112), _Turbulence )*0.5+0.5))*v.normal*_WavesHigh);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                float Tessellation(TessVertex v){
                    return _TessellationValue;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
