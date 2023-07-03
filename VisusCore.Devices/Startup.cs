using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Data;
using OrchardCore.Data.Migration;
using OrchardCore.Indexing;
using OrchardCore.Modules;
using VisusCore.AidStack.OrchardCore.Extensions;
using VisusCore.Devices.Core.Fields;
using VisusCore.Devices.Core.Models;
using VisusCore.Devices.Drivers;
using VisusCore.Devices.Indexing;
using VisusCore.Devices.Migrations;
using VisusCore.Devices.Models;

namespace VisusCore.Devices;

public class Startup : StartupBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddDataMigration<DeviceHostNameFieldMigrations>();
        services.AddContentPart<DevicePart>();
        services.AddDataMigration<DevicePartMigrations>();
        services.AddDataMigration<DevicePartIndexMigrations>();
        services.AddScopedContentPartIndexProvider<
            DevicePartIndexProvider,
            DevicePart,
            DevicePartIndex>();

        services.AddContentField<DeviceHostNameField>()
            .UseDisplayDriver<DeviceHostNameFieldDisplayDriver>();
        services.AddScoped<IContentPartFieldDefinitionDisplayDriver, DeviceHostNameFieldSettingsDisplayDriver>();
        services.AddScoped<IContentFieldIndexHandler, DeviceHostNameFieldIndexHandler>();
        services.AddDataMigration<DeviceHostNameFieldIndexMigrations>();
        services.AddScoped<IScopedIndexProvider, DeviceHostNameFieldIndexProvider>();
    }
}
