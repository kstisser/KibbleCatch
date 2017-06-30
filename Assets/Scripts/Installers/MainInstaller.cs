using UnityEngine;
using Zenject;

namespace KibbleSpace
{
    //Installer for Scene Context
    public class MainInstaller : MonoInstaller<MainInstaller>
    {
        public GameObject Dog;
        public GameObject KibblePrefab;

        public override void InstallBindings()
        {
            
        }

    }
}