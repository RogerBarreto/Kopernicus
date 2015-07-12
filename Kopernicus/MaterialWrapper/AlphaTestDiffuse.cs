// Material wrapper generated by shader translator tool
using System;
using System.Reflection;
using UnityEngine;

namespace Kopernicus
{
    namespace MaterialWrapper
    {
        public class AlphaTestDiffuse : Material
        {
            // Internal property ID tracking object
            protected class Properties
            {
                // Return the shader for this wrapper
                private const string shaderName = "Transparent/Cutout/Diffuse";
                public static Shader shader
                {
                    get { return Shader.Find (shaderName); }
                }

                // Main Color, default = (1,1,1,1)
                public const string colorKey = "_Color";
                public int colorID { get; private set; }

                // Base (RGB) Trans (A), default = "white" {}
                public const string mainTexKey = "_MainTex";
                public int mainTexID { get; private set; }

                // Alpha cutoff, default = 0.5
                public const string cutoffKey = "_Cutoff";
                public int cutoffID { get; private set; }

                // Singleton instance
                private static Properties singleton = null;
                public static Properties Instance
                {
                    get
                    {
                        // Construct the singleton if it does not exist
                        if(singleton == null)
                            singleton = new Properties();
            
                        return singleton;
                    }
                }

                private Properties()
                {
                    colorID = Shader.PropertyToID(colorKey);
                    mainTexID = Shader.PropertyToID(mainTexKey);
                    cutoffID = Shader.PropertyToID(cutoffKey);
                }
            }

            // Main Color, default = (1,1,1,1)
            public Color color
            {
                get { return GetColor (Properties.Instance.colorID); }
                set { SetColor (Properties.Instance.colorID, value); }
            }

            // Base (RGB) Trans (A), default = "white" {}
            public Texture2D mainTex
            {
                get { return GetTexture (Properties.Instance.mainTexID) as Texture2D; }
                set { SetTexture (Properties.Instance.mainTexID, value); }
            }

            public Vector2 mainTexScale
            {
                get { return GetTextureScale (Properties.mainTexKey); }
                set { SetTextureScale (Properties.mainTexKey, value); }
            }

            public Vector2 mainTexOffset
            {
                get { return GetTextureOffset (Properties.mainTexKey); }
                set { SetTextureOffset (Properties.mainTexKey, value); }
            }

            // Alpha cutoff, default = 0.5
            public float cutoff
            {
                get { return GetFloat (Properties.Instance.cutoffID); }
                set { SetFloat (Properties.Instance.cutoffID, Mathf.Clamp(value,0f,1f)); }
            }

            public AlphaTestDiffuse() : base(Properties.shader)
            {
            }

            public AlphaTestDiffuse(string contents) : base(contents)
            {
                base.shader = Properties.shader;
            }

            public AlphaTestDiffuse(Material material) : base(material)
            {
                // Throw exception if this material was not the proper material
                if (material.shader.name != Properties.shader.name)
                    throw new InvalidOperationException("Type Mismatch: Transparent/Cutout/Diffuse shader required");
            }

        }
    }
}
