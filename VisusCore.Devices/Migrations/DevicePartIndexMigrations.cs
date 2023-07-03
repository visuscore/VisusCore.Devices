using OrchardCore.Data.Migration;
using VisusCore.Devices.Core.Models;
using YesSql.Sql;

namespace VisusCore.Devices.Migrations;

public class DevicePartIndexMigrations : DataMigration
{
    public int Create()
    {
        SchemaBuilder.CreateMapIndexTable<DevicePartIndex>(table => table
            .MapContentPartIndex()
            .Column(model => model.Enabled));

        return 1;
    }
}
