using Hexa.NET.ImGui;

namespace Biohazard.BioRand.RE7.REFrameworkPlugins;
public partial class REFPlugin
{
    private static void OnImGuiDrawUi()
    {
        if (!IsInitialized) return;

        if (ImGui.TreeNode("BioRand 7"))
        {
            ImGui.TreePop();
        }
    }
}
