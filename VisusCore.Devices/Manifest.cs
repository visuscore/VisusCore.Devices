using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "VisusCore Devices",
    Author = "VisusCore",
    Version = "0.0.1",
    Description = "Generic device utilities.",
    Category = "VisusCore",
    Website = "https://github.com/visuscore/VisusCore.Devices",
    Dependencies = new[]
    {
        "OrchardCore.ContentFields",
        "OrchardCore.ContentFields.Indexing.SQL",
    }
)]
