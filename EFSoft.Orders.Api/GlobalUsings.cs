global using System.Diagnostics.CodeAnalysis;

global using EFSoft.Orders.Api.Configuration;
global using EFSoft.Orders.Application.Commands.Parameters;
global using EFSoft.Orders.Application.Queries.Parameters;
global using EFSoft.Orders.Application.Queries.Results;
global using EFSoft.Orders.Application.RepositoryContracts;
global using EFSoft.Orders.Infrastructure.DBContexts;
global using EFSoft.Orders.Infrastructure.Repositories;
global using EFSoft.Shared.Cqrs.Command;
global using EFSoft.Shared.Cqrs.DependencyInjection;
global using EFSoft.Shared.Cqrs.Query;
global using EFSoft.Shared.ServiceBus.DependencyInjection;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
