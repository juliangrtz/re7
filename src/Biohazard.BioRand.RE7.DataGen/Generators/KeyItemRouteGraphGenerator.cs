using Biohazard.BioRand.RE7.DataGen.Commands;
using Biohazard.BioRand.RE7.Modifiers;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal class KeyItemRouteGraphGenerator : IFileGenerator {
    public string Id => "key_item_route_graph";
    public string FileName => "key_item_route_graph.png";

    public object Generate(GenerateCommand.GenerateSettings settings) {
        var diagram = KeyItemLocationModifier.GenerateRouteGraphDiagram();
        return KeyItemRouteGraphImageRenderer.Render(diagram);
    }
}