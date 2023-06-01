using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RayFire
{
    [System.Serializable]
    public class RFPoolingParticles
    {
        public bool enable;
        public int capacity;
        
        // Hidden
        public bool          inProgress;
        int                  rate;
        List<ParticleSystem> list;
        ParticleSystem       inst; 
        Transform            root;
        GameObject           host;
        ParticleSystem       ps;

        // Constructor
        public RFPoolingParticles()
        {
            enable   = true;
            capacity = 60;
            rate = 2;
            list = new List<ParticleSystem>();
        }

        /// /////////////////////////////////////////////////////////
        /// Methods
        /// /////////////////////////////////////////////////////////

        // Create pool root
        public void CreatePoolRoot (Transform manTm)
        {
            // Already has pool root
            if (root != null)
                return;
            
            GameObject poolGo = new GameObject ("Pool_Particles");
            root          = poolGo.transform;
            root.position = manTm.position;
            root.parent   = manTm;
        }

        // Create pool object
        public void CreateInstance (Transform manTm)
        {
            // Return if not null
            if (inst != null)
                return;

            // Create pool instance
            inst = CreateParticleInstance();

            // Set tm
            inst.transform.position = manTm.position;
            inst.transform.rotation = manTm.rotation;
            inst.transform.parent   = root;
        }

        // Create pool object
        public ParticleSystem CreateParticleInstance()
        {
            // Create root
            host = new GameObject("Instance");
            host.SetActive (false);

            // Particle system
            ps = host.AddComponent<ParticleSystem>();
            
            // Stop for further properties set
            ps.Stop();
            
            return ps;
        }
        
        // Get pool object
        public ParticleSystem GetPoolObject (Transform manTm)
        {
            ParticleSystem scr;
            if (list.Count > 0)
            {
                scr = list[list.Count - 1];
                list.RemoveAt (list.Count - 1);
            }
            else
                scr = CreatePoolObject (manTm);

            return scr;
        }

        // Create pool object
        ParticleSystem CreatePoolObject (Transform manTm)
        {
            // Create instance if null
            if (inst == null)
                CreateInstance (manTm);

            // Create
            return Object.Instantiate (inst, root);
        }

        // Keep full pool 
        public IEnumerator StartPoolingCor (Transform manTm)
        {
            WaitForSeconds delay = new WaitForSeconds (0.53f);

            // Pooling loop
            inProgress = true;
            while (enable == true)
            {
                // Create if not enough
                if (list.Count < capacity)
                    for (int i = 0; i < rate; i++)
                        list.Add (CreatePoolObject (manTm));

                // Wait next frame
                yield return delay;
            }
            inProgress = false;
        }
    }

    [System.Serializable]
    public class RFPoolingFragment
    {
        public bool enable;
        public int capacity;
        
        // Hidden
        public bool               inProgress;
        public List<RayfireRigid> list;
        int                       rate;
        RayfireRigid              inst;
        Transform                 root;
        GameObject                go;
        MeshFilter                mf;
        MeshRenderer              mr;
        RayfireRigid              rg;
        Rigidbody                 rb;

        // Constructor
        public RFPoolingFragment()
        {
            enable   = true;
            capacity = 60;
            rate = 2;
            list = new List<RayfireRigid>();
        }

        /// /////////////////////////////////////////////////////////
        /// Methods
        /// /////////////////////////////////////////////////////////

        // Create pool root
        public void CreatePoolRoot (Transform manTm)
        {
            // Already has pool root
            if (root != null)
                return;
            
            GameObject poolGo = new GameObject ("Pool_Fragments");
            root          = poolGo.transform;
            root.position = manTm.position;
            root.parent   = manTm;
        }

        // Create pool object
        public void CreateInstance (Transform manTm)
        {
            // Return if not null
            if (inst != null)
                return;

            // Create pool instance
            inst = CreateRigidInstance();

            // Set tm
            inst.transForm.position = manTm.position;
            inst.transForm.rotation = manTm.rotation;
            inst.transForm.parent   = root;
        }

        // Create pool object
        public RayfireRigid CreateRigidInstance()
        {
            go = new GameObject ("Instance");
            go.SetActive (false);
            
            mf                        = go.AddComponent<MeshFilter>();
            mr                        = go.AddComponent<MeshRenderer>();
            rg                        = go.AddComponent<RayfireRigid>();
            rb                        = go.AddComponent<Rigidbody>();
            rb.interpolation          = RayfireMan.inst.interpolation;
            rb.collisionDetectionMode = RayfireMan.inst.meshCollision;
            rg.initialization         = RayfireRigid.InitType.AtStart;
            rg.transForm              = go.transform;
            rg.meshFilter             = mf;
            rg.meshRenderer           = mr;
            rg.physics.rigidBody      = rb;

            return rg;
        }

        // Get pool object
        public RayfireRigid GetPoolObject (Transform manTm)
        {
            RayfireRigid scr;
            if (list != null && list.Count > 0)
            {
                scr = list[list.Count - 1];
                list.RemoveAt (list.Count - 1);
            }
            else
                scr = CreatePoolObject (manTm);

            return scr;
        }

        // Create pool object
        RayfireRigid CreatePoolObject (Transform manTm)
        {
            // Create instance if null
            if (inst == null)
                CreateInstance (manTm);

            // Create
            return Object.Instantiate (inst, root);
        }

        // Keep full pool 
        public IEnumerator StartPoolingCor (Transform manTm)
        {
            WaitForSeconds delay = new WaitForSeconds (0.5f);

            // Pooling loop
            inProgress = true;
            while (enable == true)
            {
                // Create if not enough
                if (list.Count < capacity)
                    for (int i = 0; i < rate; i++)
                        list.Add (CreatePoolObject (manTm));

                // Wait next frame
                yield return delay;
            }
            inProgress = false;
        }
    }
}
