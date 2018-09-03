using Views.MainGame;

namespace Services
{
    public class BuildManagerService
    {
        /// <summary>
        /// Turret to build
        /// </summary>
        private TurretBluePrint _turretToBuild;

        public TurretBluePrint TurretToBuild
        {
            get
            {
                _selectedNode = null;
                return _turretToBuild;
            }
            set { _turretToBuild = value; }
        }

        /// <summary>
        /// Selected node
        /// </summary>
        private NodeView _selectedNode;

        public NodeView SelectedNode
        {
            get
            {
                _turretToBuild = null;
                return _selectedNode;
            }
            set { _selectedNode = value; }
        }
    }
}