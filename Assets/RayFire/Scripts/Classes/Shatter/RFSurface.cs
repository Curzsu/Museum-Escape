using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RayFire
{
    [System.Serializable]
    public class RFSurface
    {
        [FormerlySerializedAs ("innerMaterial")]
        public Material iMat;
        [FormerlySerializedAs ("outerMaterial")]
        public Material oMat;
        [FormerlySerializedAs ("mappingScale")]
        public float    mScl;
        public bool    uvE;
        public Vector2 uvC;
        public bool    cE;
        public Color   cC;
        
        // static public Material[] newMaterials;
                    
        /// /////////////////////////////////////////////////////////
        /// Constructor
        /// /////////////////////////////////////////////////////////
         
        // Constructor
        public RFSurface()
        {
            iMat = null;
            mScl = 0.1f;
            oMat = null;
            uvE  = false;
        }

        // Copy from
        public void CopyFrom(RFSurface interior)
        {
            iMat = interior.iMat;
            mScl = interior.mScl;
            oMat = interior.oMat;
            uvE  = interior.uvE;
            uvC  = interior.uvC;
            cE   = interior.cE;
            cC   = interior.cC;
        }

        /// /////////////////////////////////////////////////////////
        /// Methods
        /// /////////////////////////////////////////////////////////
        
        // Set material to fragment by it's interior properties and parent material
        public static void SetMaterial(List<RFDictionary> origSubMeshIdsRF, Material[] sharedMaterials, RFSurface interior, MeshRenderer targetRend, int i, int amount)
        {
            if (origSubMeshIdsRF != null && origSubMeshIdsRF.Count == amount)
            {
                Material[] newMaterials = new Material[origSubMeshIdsRF[i].values.Count];
                
                //System.Array.Clear (newMaterials, );
                //newMaterials.
                //newMaterials = null;
                //newMaterials = new Material[origSubMeshIdsRF[i].values.Count];
                
                for (int j = 0; j < origSubMeshIdsRF[i].values.Count; j++)
                {
                    int matId = origSubMeshIdsRF[i].values[j];
                    if (matId < sharedMaterials.Length)
                    {
                        if (interior.oMat == null)
                            newMaterials[j] = sharedMaterials[matId];
                        else
                            newMaterials[j] = interior.oMat;
                    }
                    else
                        newMaterials[j] = interior.iMat;
                }
                
                targetRend.sharedMaterials = newMaterials;
                //newMaterials               = null;
            }
        }

        // Get inner faces sub mesh id
        public static int SetInnerSubId(RayfireRigid scr)
        {
            // No inner material
            if (scr.materials.iMat == null) 
                return 0;
            
            // Get materials
            Material[] mats = scr.skinnedMeshRend != null 
                ? scr.skinnedMeshRend.sharedMaterials 
                : scr.meshRenderer.sharedMaterials;
            
            // Get outer id if outer already has it
            for (int i = 0; i < mats.Length; i++)
                if (mats[i] == scr.materials.iMat)
                    return i;
            
            return -1;
        }
        
        // Get inner faces sub mesh id
        public static int SetInnerSubId(RayfireShatter scr)
        {
            // No inner material
            if (scr.material.iMat == null) 
                return 0;
            
            // Get materials
            Material[] mats = scr.skinnedMeshRend != null 
                ? scr.skinnedMeshRend.sharedMaterials 
                : scr.meshRenderer.sharedMaterials;
            
            // Get outer id if outer already has it
            for (int i = 0; i < mats.Length; i++)
                if (mats[i] == scr.material.iMat)
                    return i;
            
            return -1;
        }
    }
}

