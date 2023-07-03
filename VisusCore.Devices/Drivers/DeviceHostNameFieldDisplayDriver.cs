using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using VisusCore.Devices.Core.Fields;
using VisusCore.Devices.Core.Settings;
using VisusCore.Devices.ViewModels;

namespace VisusCore.Devices.Drivers;

public class DeviceHostNameFieldDisplayDriver : ContentFieldDisplayDriver<DeviceHostNameField>
{
    private readonly IStringLocalizer T;

    public DeviceHostNameFieldDisplayDriver(IStringLocalizer<DeviceHostNameFieldDisplayDriver> localizer) =>
        T = localizer;

    public override IDisplayResult Display(DeviceHostNameField field, BuildFieldDisplayContext fieldDisplayContext) =>
        Initialize<DeviceHostNameFieldDisplayViewModel>(
            GetDisplayShapeType(fieldDisplayContext),
            model =>
            {
                model.Value = field.Value;

                model.Field = field;
                model.Part = fieldDisplayContext.ContentPart;
                model.PartFieldDefinition = fieldDisplayContext.PartFieldDefinition;
            })
            .Location("Detail", "Content")
            .Location("Summary", "Content");

    public override IDisplayResult Edit(DeviceHostNameField field, BuildFieldEditorContext context) =>
        Initialize<DeviceHostNameFieldEditViewModel>(
            GetEditorShapeType(context),
            model =>
            {
                model.Value = field.Value;

                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
            });

    public override async Task<IDisplayResult> UpdateAsync(DeviceHostNameField field, IUpdateModel updater, UpdateFieldEditorContext context)
    {
        if (await updater.TryUpdateModelAsync(field, Prefix, model => model.Value))
        {
            var settings = context.PartFieldDefinition.GetSettings<DeviceHostNameFieldSettings>();
            if (settings.Required && string.IsNullOrWhiteSpace(field.Value))
            {
                updater.ModelState.AddModelError(
                    Prefix,
                    nameof(field.Value),
                    T["A value is required for {0}.", context.PartFieldDefinition.DisplayName()]);
            }
        }

        return await EditAsync(field, context);
    }
}
