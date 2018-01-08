using System.Collections.Generic;
using Turbo.Plugins;

namespace Turbo.Plugins.Jack.Extensions
{
    public static class RenderControllerExtension
    {
        private static readonly Dictionary<string, IUiElement> uiElementCache;

        static RenderControllerExtension()
        {
            uiElementCache = new Dictionary<string, IUiElement>();
        }

        private static IUiElement GetCachedElement(IRenderController controller, string name)
        {
            if (!uiElementCache.ContainsKey(name) || uiElementCache[name] == null)
            {
                uiElementCache[name] = controller.GetUiElement(name);
            }

            return uiElementCache[name];
        }

        public static IUiElement InventorySidePaneUiElement(this IRenderController controller)
        {
            return GetCachedElement(controller, "Root.NormalLayer.inventory_side_pane_container");
        }

        public static IUiElement ChatEditLineUiElement(this IRenderController controller)
        {
            return GetCachedElement(controller, "Root.NormalLayer.chatentry_dialog_backgroundScreen.chatentry_content.chat_editline");
        }

        public static IUiElement WaypointMapUiElement(this IRenderController controller)
        {
            return GetCachedElement(controller, "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer");
        }

        public static IUiElement WaypointMapActListUiElement(this IRenderController controller)
        {
            return GetCachedElement(controller, "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.ActList");
        }

        public static IUiElement WaypointMapInstructionsUiElement(this IRenderController controller)
        {
            return GetCachedElement(controller, "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.instructions");
        }

        public static IUiElement WaypointMapWorldMapUiElement(this IRenderController controller)
        {
            return GetCachedElement(controller, "Root.NormalLayer.WaypointMap_main.LayoutRoot.OverlayContainer.WorldMap");
        }
    }
}