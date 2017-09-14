using System.Collections.Generic;
using MyRogueLike.rules;

namespace MyRogueLike
{
    public class RenderManager: IUpdater
    {
        public List<IUpdateRenderer> UpdateRenderers;
        public List<IInitialRenderer> InitialRenderers;

        public RenderManager(GeneralManager gm)
        {
            UpdateRenderers = new List<IUpdateRenderer>();
        }

        public void AddUpdateRenderer(IUpdateRenderer renderer)
        {
            UpdateRenderers.Add(renderer);
        }

        public void AddInitialRenderer(IInitialRenderer renderer)
        {
            InitialRenderers.Add(renderer);
        }

        public void InitialRender()
        {
            foreach (var renderer in InitialRenderers)
            {
                renderer.GameRender();
            }
        }

        public void ManageUpdate()
        {
            foreach (var renderer in UpdateRenderers)
            {
                renderer.GameRender();
            }
        }
    }
}