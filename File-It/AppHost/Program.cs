var builder = DistributedApplication.CreateBuilder(args);

var fileservice = builder.AddProject<Projects.FileServiceAPI>("fileservice");
var userservice = builder.AddProject<Projects.UserServiceAPI>("userservice");

builder.Build().Run();
