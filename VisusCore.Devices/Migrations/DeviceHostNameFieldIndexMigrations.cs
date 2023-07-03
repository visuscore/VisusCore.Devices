using Lombiq.HelpfulLibraries.OrchardCore.Data;
using OrchardCore.Data.Migration;
using VisusCore.AidStack.OrchardCore.Extensions;
using VisusCore.Devices.Core.Models;
using YesSql.Sql;

namespace VisusCore.Devices.Migrations;

public class DeviceHostNameFieldIndexMigrations : DataMigration
{
    public int Create()
    {
        SchemaBuilder.CreateMapIndexTable<DeviceHostNameFieldIndex>(table => table
            .MapContentFieldIndex()
            .Column(
                model => model.Value,
                column => column
                    .Nullable()
                    .WithLength(DeviceHostNameFieldIndex.MaxHostNameLength))
        );

        SchemaBuilder.AlterIndexTable<DeviceHostNameFieldIndex>(table => table
            .CreateIndex(
                $"IDX_{nameof(DeviceHostNameFieldIndex)}_{MapIndexExtensions.DocumentId}",
                MapIndexExtensions.DocumentId,
                nameof(DeviceHostNameFieldIndex.ContentItemId),
                nameof(DeviceHostNameFieldIndex.ContentItemVersionId),
                nameof(DeviceHostNameFieldIndex.Published),
                nameof(DeviceHostNameFieldIndex.Latest)));

        SchemaBuilder.AlterIndexTable<DeviceHostNameFieldIndex>(table => table
            .CreateIndex(
                $"IDX_{nameof(DeviceHostNameFieldIndex)}_{MapIndexExtensions.DocumentId}_{nameof(DeviceHostNameFieldIndex.ContentType)}",
                MapIndexExtensions.DocumentId,
                nameof(DeviceHostNameFieldIndex.ContentType),
                nameof(DeviceHostNameFieldIndex.ContentPart),
                nameof(DeviceHostNameFieldIndex.ContentField),
                nameof(DeviceHostNameFieldIndex.Published),
                nameof(DeviceHostNameFieldIndex.Latest)));

        SchemaBuilder.AlterIndexTable<DeviceHostNameFieldIndex>(table => table
            .CreateIndex(
                $"IDX_{nameof(DeviceHostNameFieldIndex)}_{MapIndexExtensions.DocumentId}_{nameof(DeviceHostNameFieldIndex.Value)}",
                MapIndexExtensions.DocumentId,
                nameof(DeviceHostNameFieldIndex.Value),
                nameof(DeviceHostNameFieldIndex.Published),
                nameof(DeviceHostNameFieldIndex.Latest)));

        return 1;
    }
}
